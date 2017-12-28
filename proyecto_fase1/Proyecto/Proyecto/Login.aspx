<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Proyecto.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
</head>
<body>
    <center><h1>NAVAL WARS</h1></center>
    <form id="form1" runat="server">
    <div>
        <center>
            <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate">
            </asp:Login>
        </center>
    </div>
    </form>
</body>
</html>
