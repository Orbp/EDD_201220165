<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Proyecto.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Inicio</title>
</head>
<body>
    <center><h1>NAVAL WARS</h1></center>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="PanelAdmin" runat="server">
            <center>
                <asp:FileUpload ID="FileUpload1" runat="server" />
                &nbsp;
                <asp:Button ID="Button2" runat="server" Text="Cargar archivo de juego actual" OnClick="Button2_Click" />
            </center>
            <br />
            <center>
                <asp:FileUpload ID="FileUpload2" runat="server" />
                &nbsp;
                <asp:Button ID="Button3" runat="server" Text="Cargar archivo de juegos" OnClick="Button3_Click" />
            </center>
            <br />
            <center>
                <asp:FileUpload ID="FileUpload3" runat="server" />
                &nbsp;
                <asp:Button ID="Button4" runat="server" Text="Cargar archivo de tableros" OnClick="Button4_Click" />
            </center>
            <br />
            <center>
                <asp:FileUpload ID="FileUpload4" runat="server" />
                &nbsp;
                <asp:Button ID="Button5" runat="server" Text="Cargar archivo de usuarios" OnClick="Button5_Click" />
            </center>
            <br />
            <center>
                <asp:Button ID="Button6" runat="server" Text="Reportes" OnClick="Button6_Click" />
            </center>
            <br />
            <center>
                <asp:DropDownList ID="DropDownList1" runat="server" Visible="False">
                    <asp:ListItem>Usuarios</asp:ListItem>
                    <asp:ListItem>Tablero</asp:ListItem>
                </asp:DropDownList>
            </center>
            <br />
            <center>
                <asp:Button ID="Button7" runat="server" Visible="False" Text="Mostrar" OnClick="Button7_Click" />
            </center>
            <br />
            <div>
                <center>
                    <asp:Image ID="Image1" runat="server" Height="328px" Visible="False" Width ="500px"/>
                </center>
            </div>
            <br />
            <center>
                <asp:Button ID="Button8" runat="server" Visible="true" Text="Editar Usuarios" OnClick="Button8_Click" style="height: 29px" />
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" Text="Ingrese el usuario a editar:" Visible ="false"></asp:Label>
                &nbsp
                <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
                &nbsp
                <asp:Button ID="Button9" runat="server" Visible="false" Text="Buscar" OnClick="Button9_Click"/>
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" Text="Nickname: " Visible="false"></asp:Label>
                &nbsp
                <asp:TextBox ID="txtNick" runat ="server" Visible="false"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label3" runat="server" Text="Contraseña: " Visible="false"></asp:Label>
                &nbsp
                <asp:TextBox ID="txtpass" runat ="server" Visible="false"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label4" runat="server" Text="Correo: " Visible="false"></asp:Label>
                &nbsp
                <asp:TextBox ID="txtcorreo" runat ="server" Visible="false"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="button10" runat="server" Visible="false" Text="Guardar" OnClick="button10_Click"/>
                <br />
                <br />
            </center>
            <center>
                <asp:Button ID="button11" runat="server" Visible="true" Text="Eliminar Usuario" OnClick="button11_Click" />
                <br />
                <br />
                <asp:Label ID="Label5" runat ="server" Visible="false" Text="Ingrese el usuario a eliminar: "></asp:Label>
                &nbsp
                <asp:TextBox ID="txtelinick" runat ="server" Visible="false"></asp:TextBox>
                &nbsp
                <asp:Button ID="Button12" runat ="server" Visible ="false" Text="Eliminar" OnClick="Button12_Click" />
            </center>
        </asp:Panel>
    </div>
    <div>
        <asp:Panel ID="PanelCliente" runat="server">
            <center>
                
            </center>
        </asp:Panel>
    </div>
        <br />
    <div>
        <center>
            <asp:Button ID="Button1" runat="server" Text="Cerrar Sesion" OnClick="Button1_Click" />
        </center>
    </div>
    </form>
</body>
</html>
