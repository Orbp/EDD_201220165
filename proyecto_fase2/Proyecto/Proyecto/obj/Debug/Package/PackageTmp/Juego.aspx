<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Juego.aspx.cs" Inherits="Proyecto.Juego" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <center><h1>NAVAL WARS</h1></center>
    <form id="form1" runat="server">
        <div style="float:left">
            <asp:Panel ID="Panel1" runat="server" Width="459px" style="margin-top: 0px" Height="485px">
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            <asp:Label ID="Label1" runat ="server">Tablero</asp:Label>
            <br />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            <br />
            <asp:Image ID="TableroNivel0" runat="server" Height="429px" Width="448px" style="margin-left: 8px" />
            &nbsp;
            <br />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            <br />
                &nbsp; &nbsp;
                        
        </asp:Panel>
        </div>
    
        <div style="float:left; width: 535px; height: 485px;">
            <asp:Panel ID="panel2" runat="server" Height="482px">
                <br />
                <center>
                    <asp:Label runat="server">Movimiento de unidades</asp:Label>
                </center>
                <br />
                <center>
                    <asp:Label runat="server">Pieza:</asp:Label>
                    &nbsp;<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </center>
                <br />
                <center>
                    &nbsp; Poscion inicial
                    <br />
                    <asp:Label runat="server">Fila:</asp:Label>
                    <asp:TextBox ID="TextBox3" runat="server" Width="124px"></asp:TextBox>
                    &nbsp;
                    <asp:Label runat="server">Columna:</asp:Label>
                    &nbsp;<asp:TextBox ID="TextBox4" runat="server" Width="131px"></asp:TextBox>
                    <br />
                    Posicion final<br /> Fila:
                    <asp:TextBox ID="TextBox5" runat="server" Width="119px"></asp:TextBox>
                    &nbsp;Columna:&nbsp;
                    <asp:TextBox ID="TextBox6" runat="server" Width="121px"></asp:TextBox>
                    <br />
                    <br />
                </center>
                <center>
                    <asp:Button ID="Button1" runat="server" Text="Mover" OnClick="Button1_Click"/>
                </center>
                <br />
                <center>
                    <asp:Label runat="server">Ataque de unidades</asp:Label>
                </center>
                <br />
                <center>
                    <asp:Label runat="server">Pieza:</asp:Label>
                    &nbsp;
                    <asp:DropDownList ID="ddlpiezaataque" runat="server"></asp:DropDownList>
                </center>
                <br />
                <center>
                    <asp:Label runat="server">Fila:</asp:Label>
                    &nbsp;
                    <asp:DropDownList ID="ddlfilaataque" runat="server"></asp:DropDownList>
                    &nbsp;
                    &nbsp;
                    <asp:Label runat ="server">Columna:</asp:Label>
                    &nbsp;
                    <asp:DropDownList ID="ddlcolumnaataque" runat="server"></asp:DropDownList>
                </center>
                <br />
                <center>
                    <asp:Button ID="Button2" runat="server" Text="Atacar" />
                </center>
            </asp:Panel>
        </div>
        <div style="float:left; width: 460px; height: 481px;">
            &nbsp;
            <asp:Label runat="server">Consola:</asp:Label>
            <br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server" Height="418px" ReadOnly="True" Rows="50" Width="450px"></asp:TextBox>
        </div>
    </form>
</body>
</html>
