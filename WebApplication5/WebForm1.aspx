<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication5.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="姓名："></asp:Label>
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        </div>
        <asp:Label ID="Label2" runat="server" Text="密码："></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnReg" runat="server" Text="注册" OnClick="btnReg_Click" />
        <asp:Button ID="btnLogin" runat="server" Text="登录" OnClick="btnLogin_Click" style="width: 40px" />
    </form>
</body>
</html>
