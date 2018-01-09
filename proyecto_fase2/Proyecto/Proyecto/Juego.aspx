<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Juego.aspx.cs" Inherits="Proyecto.Juego" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <center><h1>NAVAL WARS</h1></center>
        <div style="float:left">
            <asp:Panel ID="Panel1" runat="server" Width="590px" style="margin-top: 0px" Height="590px">
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            <asp:Label ID="Label1" runat ="server">Tablero</asp:Label>
            <br />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            <br />
            <asp:Image ID="TableroNivel0" runat="server" Height="534px" Width="571px" style="margin-left: 8px" />
            &nbsp;
            <br />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            <br />
                &nbsp; &nbsp;
                        
        </asp:Panel>
            </div>
        
    
        <div style="float:left;">
            <asp:Panel ID="panel2" runat="server" Height="590px" Width="590px">
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
                    &nbsp;<asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                </center>
                <br />
                <center>
                    &nbsp; Poscion inicial
                    <br />
                    <asp:Label runat="server">Fila:</asp:Label>
                    <asp:TextBox ID="TextBox8" runat="server" Width="124px"></asp:TextBox>
                    &nbsp;
                    <asp:Label runat="server">Columna:</asp:Label>
                    &nbsp;<asp:TextBox ID="TextBox9" runat="server" Width="131px"></asp:TextBox>
                    <br />
                    Posicion final<br /> Fila:
                    <asp:TextBox ID="TextBox10" runat="server" Width="119px"></asp:TextBox>
                    &nbsp;Columna:&nbsp;
                    <asp:TextBox ID="TextBox11" runat="server" Width="121px"></asp:TextBox>
                    &nbsp;Nivel:&nbsp;
                    <asp:TextBox ID="TextBox12" runat="server" Width="121px"></asp:TextBox>

                    <br />
                    <br />
                </center>
                <br />
                <center>
                    <asp:Button ID="Button2" runat="server" Text="Atacar" OnClick="Button2_Click" />
                </center>
            </asp:Panel>
        </div>

        <div style="float:left; height: 590px;">
            <asp:Panel ID ="panel3" runat ="server" Height="590px" Width="590px">
                <asp:Label ID="Label2" runat="server">Consola:</asp:Label>
            <br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server" Height="489px" ReadOnly="True" Rows="50" Width="543px"></asp:TextBox>
        
            </asp:Panel>
            
        </div>
    </form>
</body>
</html>
