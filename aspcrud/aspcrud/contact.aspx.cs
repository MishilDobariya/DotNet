using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace aspcrud
{
    public partial class contact : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=mishil-patel\sqlexpress;Initial Catalog=crud;Integrated Security=True;Pooling=False");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                btndelete.Enabled = false;
                FillGridView();
            }
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            clear();
        }
        public void clear() {
            hId.Value = "";
            txtname.Text = txtaddress.Text = txtmobile.Text = "";
            lblerror.Text = lblsuccess.Text = "";
            btnsave.Text = "Save";
            btndelete.Enabled = false;
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("ContactCreateOrUpdate",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id",(hId.Value==""?0:Convert.ToInt32(hId.Value)));
            cmd.Parameters.AddWithValue("@Name",txtname.Text.Trim());
            cmd.Parameters.AddWithValue("@Address",txtaddress.Text.Trim());
            cmd.Parameters.AddWithValue("@Mobile",txtmobile.Text.Trim());
            cmd.ExecuteNonQuery();
            con.Close();
            string Id = hId.Value;
            clear();
            if (Id == "")
            {
                lblsuccess.Text = "Saved";
            }
            else {
                lblsuccess.Text = "Updated";
            }
            FillGridView();
        }

        void FillGridView() {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("ContactViewAll",con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            GridContact.DataSource = dt;
            GridContact.DataBind();
        }

        protected void lnk_OnClick(object sender, EventArgs e) {
            int Id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("ContactViewById", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Id",Id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            hId.Value = Id.ToString();
            txtname.Text = dt.Rows[0]["Name"].ToString();
            txtaddress.Text = dt.Rows[0]["Address"].ToString();
            txtmobile.Text = dt.Rows[0]["Mobile"].ToString();
            btnsave.Text = "Update";
            btndelete.Enabled = true;
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("ContactDeleteById",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id",Convert.ToInt32(hId.Value));
            cmd.ExecuteNonQuery();
            con.Close();
            clear();
            FillGridView();
            lblsuccess.Text = "Deleted"; 
        }
    }
}