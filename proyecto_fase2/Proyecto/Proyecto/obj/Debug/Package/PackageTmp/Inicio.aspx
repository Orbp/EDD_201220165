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
                <asp:FileUpload ID="FileUpload5" runat="server" ></asp:FileUpload>
                &nbsp;
                <asp:Button ID="Button27" runat="server" Text="Cargar archivo de Contactos" OnClick="Button27_Click" />
            </center>
            <br />
            <center>
                Indice para el historial&nbsp;<asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
&nbsp;&nbsp<asp:Label runat="server" Text="Ordenar por:"></asp:Label>
                &nbsp;<asp:DropDownList ID="DropDownList8" runat="server">
                    <asp:ListItem>Coordenada X</asp:ListItem>
                    <asp:ListItem>Coordenada Y</asp:ListItem>
                    <asp:ListItem>Unidad Atacante</asp:ListItem>
                    <asp:ListItem>Resultado(Daño, eliminacion del objetivo)</asp:ListItem>
                    <asp:ListItem>Tipo de Unidad Dañada</asp:ListItem>
                    <asp:ListItem>Emisor</asp:ListItem>
                    <asp:ListItem>Receptor</asp:ListItem>
                    <asp:ListItem>Fecha</asp:ListItem>
                    <asp:ListItem>Numero de ataque</asp:ListItem>
                </asp:DropDownList>
                &nbsp;<asp:Button ID="Button30" runat="server" OnClick="Button30_Click" Text="Guardar indice para el historial" />
                &nbsp;

                <asp:FileUpload ID="FileUpload7" runat="server" Enabled="False"></asp:FileUpload>
                &nbsp;
                <asp:Button ID="Button31" runat="server" Text="Cargar Archivo de Historial" Enabled="False" OnClick="Button31_Click" />
            </center>
            <br />
            <center>
                <asp:Button ID="Button6" runat="server" Text="Reportes" OnClick="Button6_Click" />
            </center>
            <br />
            <center>
                <asp:DropDownList ID="DropDownList1" runat="server" Visible="False">
                    <asp:ListItem>Usuarios</asp:ListItem>
                    <asp:ListItem>Usuarios Modo Espejo</asp:ListItem>
                    <asp:ListItem>Tablero actual</asp:ListItem>
                    <asp:ListItem>Tablero Inicial</asp:ListItem>
                    <asp:ListItem>Unidades Sobrevivientes</asp:ListItem>
                    <asp:ListItem>Unidades Destruidas</asp:ListItem>
                    <asp:ListItem>Top 10 Jugadores con mas juegos ganados</asp:ListItem>
                    <asp:ListItem>Top 10 Jugadores con mayor porcentaje de unidades destruidas</asp:ListItem>
                    <asp:ListItem>Contactos</asp:ListItem>
                    <asp:ListItem>Historial Cargado</asp:ListItem>
                    <asp:ListItem>Dispersion de usuarios</asp:ListItem>
                </asp:DropDownList>
            </center>
            <br />
            <center>
                <asp:Button ID="Button7" runat="server" Visible="False" Text="Mostrar" OnClick="Button7_Click" />
                &nbsp;<asp:DropDownList ID="DropDownList7" runat="server" OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged" Visible="False">
                </asp:DropDownList>
                &nbsp;<asp:Button ID="Button32" runat="server" OnClick="Button32_Click" Text="Mostrar Contactos" Visible="False" />
            </center>
            <br />
            <div>
                <center>
                    <asp:Image ID="Image1" runat="server" Visible="False" />
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
            <br />
            <br />
            <center>
                <asp:Button ID="Button13" runat="server" Visible="true" Text="Editar Juegos" OnClick="Button13_Click" />
                <br />
                <br />
                <asp:Button ID="Button14" runat="server" Visible="false" Text="Agregar Juegos" OnClick="Button14_Click" />
                &nbsp;
                <asp:Button ID="Button16" runat="server" Visible="false" Text="Eliminar Juegos" OnClick="Button16_Click" />
                &nbsp;
                <asp:Button ID="Button19" runat="server" Visible="false" Text="Modificar Juegos" OnClick="Button19_Click" />
                <br />
                <asp:Label ID="Label6" runat="server" Text="Jugador base: " Visible="false"></asp:Label>
                &nbsp;
                <asp:DropDownList ID="ddljugadorbase" runat="server" Visible="False">
                </asp:DropDownList>
                <br />
                <asp:Label ID="Label7" runat="server" Text="Oponente:" Visible="false"></asp:Label>
                &nbsp;
                <asp:DropDownList ID="Jugador2" runat="server" Visible="False">
                </asp:DropDownList>
                &nbsp;
                <asp:Button ID="Button17" runat="server" Visible="false" Text="Mostrar Juegos" OnClick="Button17_Click" />
                <asp:Button ID="Button21" runat="server" Text="Mostrar Juegos"  Visible="false " OnClick="Button21_Click"/>
                <br />
                <asp:Label ID="Label8" runat="server" Text="Unidades Desplegadas: " Visible="false"></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtunides" runat="server" Visible="false">1</asp:TextBox>
                <asp:DropDownList ID="DropDownList3" runat="server" Visible ="false">
                    <asp:ListItem>Jugador Base-Oponente-Unidades Desplegadas-Unidades Sobrevivientes-Unidades Destruidas</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Label ID="Label9" runat="server" Text="Unidades Sobrevivientes:" Visible="false"></asp:Label>
                &nbsp;<asp:TextBox ID="txtunisob" runat="server" Visible="false">2</asp:TextBox>
                &nbsp;
                <asp:Button ID="Button18" runat="server" Visible="false" Text="Borrar" OnClick="Button18_Click" />
                &nbsp;
                <asp:Button ID="Button20" runat="server" Text="Seleccionar" Visible="false" OnClick="Button20_Click" />
                <br />
                <asp:Label ID="Label10" runat="server" Text="Unidades Destruidas:" Visible="false"></asp:Label>
                &nbsp;<asp:TextBox ID="txtunidest" runat="server" Visible="false">3</asp:TextBox>
                <asp:Label ID="Label12" runat="server" Text="Jugador Base:" Visible="false"></asp:Label>
                &nbsp;
                <asp:Label ID="Label13" runat="server" Text="" Visible="false"></asp:Label>
                <br />
                <asp:Label ID="Label11" runat="server" Text="Victoria jugador base" Visible="false"></asp:Label>
                &nbsp;
                <asp:DropDownList ID="DropDownList2" runat="server" Visible="False">
                    <asp:ListItem>si</asp:ListItem>
                    <asp:ListItem>no</asp:ListItem>
                </asp:DropDownList>
                &nbsp;<asp:Button ID="Button15" runat="server" OnClick="Button15_Click" Text="Guardar" Visible="false" />
                <asp:Label ID="Label14" runat="server" Text="Oponente: " Visible="false"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" Visible="false">4</asp:TextBox>
                <br />
                <asp:Label ID="Label15" runat="server" Text="Numero de Naves Desplegadas:" Visible="false"></asp:Label>
                &nbsp;
                <asp:TextBox ID="TextBox3" runat="server" Visible="false"></asp:TextBox>
                <br />
                <center>
                <asp:TextBox ID="txtindice" runat="server"></asp:TextBox>
                &nbsp
                <asp:Button ID="Button28" runat="server" Text="Guardar indice para el historial" />
                &nbsp;
                <asp:FileUpload ID="FileUpload6" runat="server"></asp:FileUpload>
                &nbsp;
                <asp:Button ID="Button29" runat="server" Text="Cargar Archivo de Historial" />
            </center>
                <asp:Label ID="Label16" runat="server" Text="Numero de Naves Sobrevivientes:" Visible="false"></asp:Label>
                &nbsp;
                <asp:TextBox ID="TextBox4" runat="server" Visible="false"></asp:TextBox>
                <br />
                <asp:Label ID="Label17" runat="server" Text="Numero de Naves Destruidas:" Visible="false"></asp:Label>
                &nbsp;
                <asp:TextBox ID="TextBox5" runat="server" Visible="false"></asp:TextBox>
                <br />
                <asp:Button runat="server" Text="Guardar" Visible="false" ID="Button22" OnClick="Button22_Click"></asp:Button>
            </center>
        </asp:Panel>
    </div>
    <div>
        <asp:Panel ID="PanelCliente" runat="server">
            <center style="margin-left: 40px">
                
                <br />
                
                <asp:Button ID="Button23" runat="server" OnClick="Button23_Click" Text="Mostrar Tablero Cargado" />
                &nbsp;
                <asp:Button ID="Button24" runat="server" Text="Mostrar Tablero Inicial" OnClick="Button24_Click" />
                &nbsp;
                <asp:Button ID="Button25" runat="server" Text="Llenar Tablero Inicial" OnClick="Button25_Click" />
                &nbsp;<asp:Button ID="Button33" runat="server" Enabled="False" OnClick="Button33_Click" Text="Jugar" />
                <br />
                <asp:Image ID="Image2" runat="server" Visible="false" />
                <asp:Label ID="Label18" runat="server" Text="Columna: " Visible="false"></asp:Label>
&nbsp;&nbsp;<asp:DropDownList ID="DropDownList4" runat="server" Visible="false">
                </asp:DropDownList>
                <br />
                <asp:Label ID="Label19" runat="server" Text="Fila: " Visible="false"></asp:Label>
&nbsp;&nbsp;<asp:DropDownList ID="DropDownList5" runat="server" Visible="false">
                </asp:DropDownList>
                <br />
                <asp:Label ID="Label20" runat="server" Text="Tipo: " Visible="false"></asp:Label>
&nbsp;
                <asp:DropDownList ID="DropDownList6" runat="server" Visible="false">
                </asp:DropDownList>
                <br />
                <asp:Label ID="Label21" runat="server" Text="Id de la unidad: " Visible="false"></asp:Label>
                <asp:TextBox ID="TextBox6" Visible="false" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="Button26" runat="server" Text="Insertar" Visible ="false" OnClick="Button26_Click" />
            </center>
        </asp:Panel>
    </div>
        <br />
    <div>
        <center>
            <asp:Button ID="Button1" runat="server" Text="Cerrar Sesion" OnClick="Button1_Click" />
            <asp:Label ID="Label22" runat="server" Text="Label"></asp:Label>
        </center>
    </div>
    </form>
</body>
</html>
