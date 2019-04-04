<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebService.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="txtA" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtA" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
            ControlToValidate="txtA" ErrorMessage="RegularExpressionValidator" 
            ValidationExpression="^[0-9]+"></asp:RegularExpressionValidator>
        <br />
        <asp:TextBox ID="txtB" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="txtB" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="txtB" ErrorMessage="RegularExpressionValidator" 
            ValidationExpression="^[0-9]+"></asp:RegularExpressionValidator>
        <br />
        <asp:Button ID="btnadd" runat="server" onclick="btnadd_Click" Text="Add" />
        <asp:Button ID="btnsub" runat="server" onclick="btnsub_Click" Text="Sub" />
        <asp:Button ID="btnmul" runat="server" onclick="btnmul_Click" Text="Mul" />
        <asp:Button ID="btndiv" runat="server" onclick="btndiv_Click" Text="Div" />
        <br />
        <asp:Label ID="lblresult" runat="server" Text="Result"></asp:Label>
    
    </div>
    </form>
</body>
</html>
