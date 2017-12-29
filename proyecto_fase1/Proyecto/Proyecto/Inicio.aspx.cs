using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Proyecto
{
    public partial class Inicio : System.Web.UI.Page
    {
        private static int tamax;
        private static int tamay;
        private static int numnivel1;
        private static int numnivel2;
        private static int numnivel3;
        private static int numnivel4;
        private static int tipo;
        private static string tiempo = "";
        private static string usuario = ""; 
        private bool ubase = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                this.form1.Attributes.Add("autocomplete", "off");
            }

            if (Session["Nombre"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if (Session["Nombre"].ToString().CompareTo("admin") == 0)
            {
                PanelAdmin.Visible = true;
                PanelCliente.Visible = false;
            }
            else
            {
                ServiceReference1.WebServiceProyectoSoapClient referencia = new ServiceReference1.WebServiceProyectoSoapClient();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('" + Session["Nombre"].ToString() + "');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('" + referencia.GetUsuario1() + "," + referencia.GetUsuario2() + "');", true);
                if (Session["Nombre"].ToString().CompareTo(referencia.GetUsuario1()) == 0)
                {
                    usuario = Session["Nombre"].ToString();
                    tamax = referencia.GetTamX();
                    tamay = referencia.GetTamY();
                    numnivel1 = referencia.GetNumeroNivel1();
                    numnivel2 = referencia.GetNumeroNivel2();
                    numnivel3 = referencia.GetNumeroNivel3();
                    numnivel4 = referencia.GetNumeroNivel4();
                    tipo = referencia.GetTipoJuego();
                    tiempo = referencia.GetTiempo();
                    if(Session["Nombre"].ToString().CompareTo(referencia.GetUsuario1()) == 0)
                    {
                        ubase = true;
                    }
                    else
                    {
                        ubase = false;
                    }
                }
                else if(Session["Nombre"].ToString().CompareTo(referencia.GetUsuario2()) == 0)
                {
                    usuario = Session["Nombre"].ToString();
                    tamax = referencia.GetTamX();
                    tamay = referencia.GetTamY();
                    numnivel1 = referencia.GetNumeroNivel1();
                    numnivel2 = referencia.GetNumeroNivel2();
                    numnivel3 = referencia.GetNumeroNivel3();
                    numnivel4 = referencia.GetNumeroNivel4();
                    tipo = referencia.GetTipoJuego();
                    tiempo = referencia.GetTiempo();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('El juego actual no esta configurado para este nickname');", true);
                }
                PanelAdmin.Visible = false;
                PanelCliente.Visible = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["Nombre"] = null;
            Response.Redirect("Login.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            bool extension = false;
            ServiceReference1.WebServiceProyectoSoapClient referencia = new ServiceReference1.WebServiceProyectoSoapClient();

            if (FileUpload1.HasFile)
            {
                string nombrearchivo = FileUpload1.PostedFile.FileName;
                string extensionarchivo = Path.GetExtension(nombrearchivo).ToLower();
                if (extensionarchivo.Contains(".csv"))
                {
                    extension = true;
                }
                if (extension)
                {
                    try
                    {
                        string pathguardar = Server.MapPath("~/temp/");
                        FileUpload1.PostedFile.SaveAs(pathguardar + nombrearchivo);
                        string dat = referencia.CargarJuegoActual(pathguardar + nombrearchivo);
                        string[] datos = dat.Split(',');
                        referencia.SetDatosJuego(datos[0], datos[1], int.Parse(datos[2]), int.Parse(datos[3]), int.Parse(datos[4]), int.Parse(datos[5]), int.Parse(datos[6]), int.Parse(datos[7]), int.Parse(datos[8]), datos[9]);
                    }
                    catch (IOException ex)
                    {
                        
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('La extension del archivo no es la correcta');", true);
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            bool extension = false;
            ServiceReference1.WebServiceProyectoSoapClient referencia = new ServiceReference1.WebServiceProyectoSoapClient();

            if (FileUpload2.HasFile)
            {
                string nombrearchivo = FileUpload2.PostedFile.FileName;
                string extensionarchivo = Path.GetExtension(nombrearchivo).ToLower();
                if (extensionarchivo.Contains(".csv"))
                {
                    extension = true;
                }
                if (extension)
                {
                    try
                    {
                        string pathguardar = Server.MapPath("~/temp/");
                        FileUpload2.PostedFile.SaveAs(pathguardar + nombrearchivo);
                        referencia.CargarJuegos(pathguardar + nombrearchivo);
                    }
                    catch (IOException ex)
                    {

                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('La extension del archivo no es la correcta');", true);
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            bool extension = false;
            ServiceReference1.WebServiceProyectoSoapClient referencia = new ServiceReference1.WebServiceProyectoSoapClient();

            if (FileUpload3.HasFile)
            {
                string nombrearchivo = FileUpload3.PostedFile.FileName;
                string extensionarchivo = Path.GetExtension(nombrearchivo).ToLower();
                if (extensionarchivo.Contains(".csv"))
                {
                    extension = true;
                }
                if (extension)
                {
                    try
                    {
                        string pathguardar = Server.MapPath("~/temp/");
                        FileUpload3.PostedFile.SaveAs(pathguardar + nombrearchivo);
                        referencia.CargarTablero(pathguardar + nombrearchivo);   
                    }
                    catch (IOException ex)
                    {

                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('La extension del archivo no es la correcta');", true);
                }
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            bool extension = false;
            ServiceReference1.WebServiceProyectoSoapClient referencia = new ServiceReference1.WebServiceProyectoSoapClient();

            if (FileUpload4.HasFile)
            {
                string nombrearchivo = FileUpload4.PostedFile.FileName;
                string extensionarchivo = Path.GetExtension(nombrearchivo).ToLower();
                if (extensionarchivo.Contains(".csv"))
                {
                    extension = true;
                }
                if (extension)
                {
                    try
                    {
                        string pathguardar = Server.MapPath("~/temp/");
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('" + pathguardar + "');", true);
                        FileUpload4.PostedFile.SaveAs(pathguardar + nombrearchivo);
                        referencia.CargarUsuarios(pathguardar + nombrearchivo);
                    }
                    catch (IOException ex)
                    {

                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('La extension del archivo no es la correcta');", true);
                }
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            if (this.DropDownList1.SelectedValue.ToString().CompareTo("Usuarios") == 0)
            {
                ServiceReference1.WebServiceProyectoSoapClient sr = new ServiceReference1.WebServiceProyectoSoapClient();
                if (sr.Llamadaagraficar("u", Server.MapPath("/images")))
                {
                    string path = Server.MapPath("/images");
                    path += "\\arbol.jpg";
                    this.Image1.ImageUrl = "/images/arbol.jpg";
                    this.Image1.AlternateText = "Imagen no disponible";
                    this.Image1.Visible = true;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('El arbol de usuarios se encuentra vacio');", true);
                }
            }
            else if(this.DropDownList1.SelectedValue.ToString().CompareTo("Usuarios Modo Espejo") == 0)
            {
                ServiceReference1.WebServiceProyectoSoapClient sr = new ServiceReference1.WebServiceProyectoSoapClient();
                if (sr.Llamadaagraficar("ue", Server.MapPath("/images")))
                {
                    string path = Server.MapPath("/images");
                    path += "\\arbolespejo.jpg";
                    this.Image1.ImageUrl = "/images/arbolespejo.jpg";
                    this.Image1.Visible = true;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('El arbol de usuarios se encuentra vacio');", true);
                }
            }
            else if (this.DropDownList1.SelectedValue.ToString().CompareTo("Tablero actual") == 0)
            {
                ServiceReference1.WebServiceProyectoSoapClient sr = new ServiceReference1.WebServiceProyectoSoapClient();
                if (sr.Llamadaagraficar("ta", Server.MapPath("/images")))
                {
                    string path = Server.MapPath("/images");
                    path += "\\tableroactual.jpg";
                    this.Image1.ImageUrl = "/images/tableroactual.jpg";
                    this.Image1.Visible = true;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('La matriz del tablero actual se encuentra vacia');", true);
                }
            }
            else if (DropDownList1.SelectedValue.ToString().CompareTo("Tablero Inicial") == 0)
            {
                ServiceReference1.WebServiceProyectoSoapClient sr = new ServiceReference1.WebServiceProyectoSoapClient();
                if (sr.Llamadaagraficar("tia", Server.MapPath("/images")))
                {
                    string path = Server.MapPath("/images");
                    path += "\\tableroinicial.jpg";
                    this.Image1.ImageUrl = "/images/tableroinicial.jpg";
                    Image1.Visible = true;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('La matriz del tablero inicial se encuentra vacia');", true);
                }
            }
            else if (DropDownList1.SelectedValue.ToString().CompareTo("Unidades Sobrevivientes") == 0)
            {
                ServiceReference1.WebServiceProyectoSoapClient sr = new ServiceReference1.WebServiceProyectoSoapClient();
                if (sr.Llamadaagraficar("us", Server.MapPath("/images")))
                {
                    string path = Server.MapPath("/images");
                    path += "\\tablerodevivos.jpg";
                    Image1.ImageUrl = "/images/tablerodevivos.jpg";
                    Image1.Visible = true;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('La matriz del tablero actual se encuentra vacia');", true);
                }
            }
            else if (DropDownList1.SelectedValue.ToString().CompareTo("Unidades Destruidas") == 0)
            {
                ServiceReference1.WebServiceProyectoSoapClient sr = new ServiceReference1.WebServiceProyectoSoapClient();
                if (sr.Llamadaagraficar("ud", Server.MapPath("/images")))
                {
                    string path = Server.MapPath("/images");
                    path += "\\tablerodemuertos.jpg";
                    Image1.ImageUrl = "/images/tablerodemuertos.jpg";
                    Image1.Visible = true;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('La matriz del tablero actual se encuentra vacia');", true);
                }
            }
            else if (DropDownList1.SelectedValue.ToString().CompareTo("Top 10 Jugadores con mas juegos ganados") == 0)
            {
                ServiceReference1.WebServiceProyectoSoapClient sr = new ServiceReference1.WebServiceProyectoSoapClient();
                if (sr.Llamadaagraficar("topj", Server.MapPath("/images")))
                {
                    string path = Server.MapPath("/images");
                    path += "\\top10.jpg";
                    Image1.ImageUrl = "/images/top10.jpg";
                    Image1.Visible = true;
                }
            }
            else
            {
                ServiceReference1.WebServiceProyectoSoapClient sr = new ServiceReference1.WebServiceProyectoSoapClient();
                if (sr.Llamadaagraficar("topu", Server.MapPath("/images")))
                {
                    string path = Server.MapPath("/images");
                    path += "\\top10u.jpg";
                    Image1.ImageUrl = "/images/top10u.jpg";
                    Image1.Visible = true;
                }
            }
            
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            this.DropDownList1.Visible = true;
            this.Button7.Visible = true;
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            this.TextBox1.Visible = true;
            this.Label1.Visible = true;
            this.Button9.Visible = true;
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebServiceProyectoSoapClient referencia = new ServiceReference1.WebServiceProyectoSoapClient();
            if (this.TextBox1.Text.Length != 0)
            {
                if (!referencia.BuscarUsuario(this.TextBox1.Text))
                {
                    this.TextBox1.Enabled = false;
                    string datosusuario = referencia.Devolverusuario(this.TextBox1.Text);
                    if (datosusuario.CompareTo("") != 0)
                    {
                        string[] datos = datosusuario.Split(',');
                        txtNick.Text = datos[0];
                        txtpass.Text = datos[1];
                        txtcorreo.Text = datos[2];
                        this.button10.Visible = this.Label2.Visible = this.Label3.Visible = this.Label4.Visible = txtcorreo.Visible = txtNick.Visible = txtpass.Visible = true;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('El usuario no existe');", true);
                    this.TextBox1.Enabled = true;
                }
            }
        }

        protected void button10_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebServiceProyectoSoapClient referencia = new ServiceReference1.WebServiceProyectoSoapClient();
            if (txtNick.Text.Length != 0 && txtpass.Text.Length != 0 && txtcorreo.Text.Length != 0)
            {
                if (txtNick.Text.CompareTo(TextBox1.Text) == 0)
                {
                    referencia.ModificarUsuarios(txtNick.Text, txtpass.Text, txtpass.Text);
                    this.Label1.Visible = this.TextBox1.Visible = this.Button9.Visible = this.button10.Visible = this.Label2.Visible = this.Label3.Visible = this.Label4.Visible = txtcorreo.Visible = txtNick.Visible = txtpass.Visible = false;
                    TextBox1.Enabled = true;
                    TextBox1.Text = txtpass.Text = txtNick.Text = txtcorreo.Text = "";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Usuario Modificado con exito');", true);
                }
                else
                {
                    if (referencia.ModificarNicknameUsuarios(TextBox1.Text, txtNick.Text, txtpass.Text, txtcorreo.Text))
                    {
                        this.Label1.Visible = this.TextBox1.Visible = this.Button9.Visible = this.button10.Visible = this.Label2.Visible = this.Label3.Visible = this.Label4.Visible = txtcorreo.Visible = txtNick.Visible = txtpass.Visible = false;
                        TextBox1.Enabled = true;
                        TextBox1.Text = txtpass.Text = txtNick.Text = txtcorreo.Text = "";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Usuario Modificado con exito');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('El nombre de usuario ya existe');", true);
                    }
                }
            }
        }

        protected void button11_Click(object sender, EventArgs e)
        {
            this.Label5.Visible = this.txtelinick.Visible = this.Button12.Visible = true;
        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebServiceProyectoSoapClient referencia = new ServiceReference1.WebServiceProyectoSoapClient();
            if (txtelinick.Text.Length != 0)
            {
                if (referencia.EliminarUsuarios(txtelinick.Text))
                {
                    this.Label5.Visible = this.txtelinick.Visible = this.Button12.Visible = false;
                    txtelinick.Text = "";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Eliminacion exitosa');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('No se pudo eliminar el usuario deseado');", true);
                }
            }
        }

        protected void Button14_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebServiceProyectoSoapClient referencia = new ServiceReference1.WebServiceProyectoSoapClient();
            this.Label6.Text = "Jugador Base:";
            this.ddljugadorbase.Items.Clear();
            this.Jugador2.Items.Clear();
            this.Label6.Visible = this.Label7.Visible = this.Label8.Visible = this.Label9.Visible = this.Label10.Visible = this.Label11.Visible = true;
            this.ddljugadorbase.Visible = this.Jugador2.Visible = this.txtunides.Visible = this.txtunisob.Visible = this.txtunidest.Visible = this.DropDownList2.Visible = true;
            this.Button15.Visible = true;
            this.Button17.Visible = this.DropDownList3.Visible = this.Button18.Visible = false;
            Button21.Visible = DropDownList3.Visible = Button20.Visible = Button21.Visible = Label12.Visible = Label13.Visible = Label14.Visible = TextBox2.Visible = false;
            Label15.Visible = TextBox3.Visible = Label16.Visible = TextBox4.Visible = Label17.Visible = TextBox5.Visible = false;
            string[] datos = referencia.LUsuarios().Split(',');
            for (int i = 0; i < datos.Length; i++)
            {
                if (datos[i].Length != 0)
                {
                    ddljugadorbase.Items.Add(datos[i]);
                    Jugador2.Items.Add(datos[i]);
                }
            }
        }

        protected void Button15_Click(object sender, EventArgs e)
        {
            string jugadorbase = ddljugadorbase.SelectedItem.Text.ToString();
            string oponente = Jugador2.SelectedItem.Text.ToString();
            int unidadesdesp = int.Parse(txtunides.Text);
            int unidadessobr = int.Parse(txtunisob.Text);
            int unidadesdest = int.Parse(txtunidest.Text);
            bool gano;
            if (DropDownList2.SelectedItem.Text.ToString().CompareTo("si") == 0)
            {
                gano = true;
            }
            else
            {
                gano = false;
            }
            ServiceReference1.WebServiceProyectoSoapClient referencia = new ServiceReference1.WebServiceProyectoSoapClient();
            referencia.InsertarJuego(jugadorbase, oponente, unidadesdesp, unidadessobr, unidadesdest, gano);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Juego agregado');", true);
            this.Label6.Visible = this.Label7.Visible = this.Label8.Visible = this.Label9.Visible = this.Label10.Visible = this.Label11.Visible = false;
            this.ddljugadorbase.Visible = this.Jugador2.Visible = this.txtunides.Visible = this.txtunisob.Visible = this.txtunidest.Visible = this.DropDownList2.Visible = false;
            this.Button15.Visible = this.Button14.Visible = this.Button16.Visible = false;
        }

        protected void Button13_Click(object sender, EventArgs e)
        {
            this.Button14.Visible = this.Button16.Visible = Button19.Visible = true;
        }

        protected void Button16_Click(object sender, EventArgs e)
        {
            this.Label6.Text = "Jugador del que se desea eliminar:";
            this.Label6.Visible = this.ddljugadorbase.Visible = this.Button17.Visible = true;
            this.Label7.Visible = this.Jugador2.Visible = this.Label8.Visible = this.txtunides.Visible = this.Label9.Visible = this.txtunisob.Visible = this.Label10.Visible = this.txtunidest.Visible = this.Label11.Visible = this.DropDownList2.Visible = this.Button15.Visible = false;
            Button21.Visible = DropDownList3.Visible = Button20.Visible = Label12.Visible = Label13.Visible = Button18.Visible = Label14.Visible = TextBox2.Visible = false;
            Label15.Visible = TextBox3.Visible = Label16.Visible = TextBox4.Visible = Label17.Visible = TextBox5.Visible = Button22.Visible = false;
            ddljugadorbase.Items.Clear();
            DropDownList3.Items.Clear();
            ServiceReference1.WebServiceProyectoSoapClient referencia = new ServiceReference1.WebServiceProyectoSoapClient();
            string[] datos = referencia.LUsuarios().Split(',');
            for (int i = 0; i < datos.Length; i++)
            {
                if (datos[i].Length != 0)
                {
                    ddljugadorbase.Items.Add(datos[i]);
                }
            }
        }

        protected void Button17_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebServiceProyectoSoapClient referencia = new ServiceReference1.WebServiceProyectoSoapClient();
            string[] datos = referencia.DevolverListajuegos(ddljugadorbase.SelectedItem.Text).Split('\n');
            for (int i = 0; i < datos.Length; i++)
            {
                if (datos[i].Length != 0)
                {
                    DropDownList3.Items.Add(datos[i]);
                }
            }
            DropDownList3.Visible = this.Button18.Visible = true;
        }

        protected void Button18_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebServiceProyectoSoapClient referencia = new ServiceReference1.WebServiceProyectoSoapClient();
            if (DropDownList3.SelectedItem.Text.ToString().Contains("Jugador Base-"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Debe seleccionar un juego');", true);
            }
            else
            {
                string[] datos = DropDownList3.SelectedItem.ToString().Split('-');
                referencia.BorrardeListaJuegos(datos[0], datos[1], int.Parse(datos[2]), int.Parse(datos[3]), int.Parse(datos[4]));
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Juego borrado con exito');", true);
                this.Button14.Visible = this.Button16.Visible = this.Label6.Visible = this.ddljugadorbase.Visible = this.Button17.Visible = this.DropDownList3.Visible = this.Button18.Visible = false;
            }
        }

        protected void Button19_Click(object sender, EventArgs e)
        {
            ddljugadorbase.Items.Clear();
            this.Label6.Text = "Jugador al que se desea modificar juego";
            Label6.Visible = true;
            ddljugadorbase.Visible = true;
            Button21.Visible = true;
            Label7.Visible = Jugador2.Visible = Button17.Visible = Label8.Visible = txtunides.Visible = DropDownList3.Visible = Label9.Visible = txtunisob.Visible = false;
            Button18.Visible = Button20.Visible = Label10.Visible = txtunidest.Visible = Label12.Visible = Label13.Visible = Label11.Visible = DropDownList2.Visible = false;
            Button15.Visible = Label14.Visible = TextBox2.Visible = Label15.Visible = TextBox3.Visible = Label16.Visible = TextBox4.Visible = Label17.Visible = false;
            TextBox5.Visible = Button22.Visible = false;
            ServiceReference1.WebServiceProyectoSoapClient referencia = new ServiceReference1.WebServiceProyectoSoapClient();
            string[] datos = referencia.LUsuarios().Split(',');
            for (int i = 0; i < datos.Length; i++)
            {
                if (datos[i].Length != 0)
                {
                    ddljugadorbase.Items.Add(datos[i]);
                }
            }
            
        }

        protected void Button21_Click(object sender, EventArgs e)
        {
            this.Button20.Visible = true;
            DropDownList3.Items.Clear();
            ServiceReference1.WebServiceProyectoSoapClient referencia = new ServiceReference1.WebServiceProyectoSoapClient();
            DropDownList3.Items.Add("Jugador Base-Oponente-Unidades Desplegadas-Unidades Sobrevivientes-Unidades Destruidas");
            string[] datos = referencia.DevolverListajuegos(ddljugadorbase.SelectedItem.Text).Split('\n');
            for (int i = 0; i < datos.Length; i++)
            {
                if (datos[i].Length != 0)
                {
                    DropDownList3.Items.Add(datos[i]);
                }
            }
            DropDownList3.Visible = true;
        }

        protected void Button20_Click(object sender, EventArgs e)
        {
            if (DropDownList3.SelectedItem.ToString().Contains("Jugador Base-"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Debe seleccionar un juego para modificar');", true);
            }
            else
            {
                Button14.Visible = Button16.Visible = Button19.Visible = Label6.Visible = ddljugadorbase.Visible = Button21.Visible = DropDownList3.Visible = Button20.Visible = false;
                Label12.Visible = Label13.Visible = Label14.Visible = TextBox2.Visible = Label15.Visible = TextBox3.Visible = Label16.Visible = TextBox4.Visible = true;
                Label17.Visible = TextBox5.Visible = Button22.Visible = true;
                Label6.Visible = ddljugadorbase.Visible = Button21.Visible = DropDownList3.Visible = Button20.Visible = true;
                ServiceReference1.WebServiceProyectoSoapClient referencia = new ServiceReference1.WebServiceProyectoSoapClient();
                string[] datos = DropDownList3.SelectedItem.ToString().Split('-');
                string[] datosjuego = referencia.DevolverDatosJuego(datos[0], datos[1], int.Parse(datos[2]), int.Parse(datos[3]), int.Parse(datos[4])).Split(',');
                Label12.Visible = Label13.Visible = Label14.Visible = TextBox2.Visible = Label15.Visible = TextBox3.Visible = Label16.Visible = TextBox4.Visible = Label17.Visible = TextBox5.Visible = Button22.Visible = true;
                Label3.Text = datosjuego[0];
                TextBox2.Text = datosjuego[1];
                TextBox3.Text = datosjuego[2];
                TextBox4.Text = datosjuego[3];
                TextBox5.Text = datosjuego[4];
            }
        }

        protected void Button22_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebServiceProyectoSoapClient referencia = new ServiceReference1.WebServiceProyectoSoapClient();
            string[] datos = DropDownList3.SelectedItem.ToString().Split('-');
            string[] datosjuego = referencia.DevolverDatosJuego(datos[0], datos[1], int.Parse(datos[2]), int.Parse(datos[3]), int.Parse(datos[4])).Split(',');
            string jugadorbase = datosjuego[0];
            string oponenteantiguo = datosjuego[1];
            int unidadesdes = int.Parse(datosjuego[2]);
            int unidadessob = int.Parse(datosjuego[3]);
            int unidadesdest = int.Parse(datosjuego[4]);
            referencia.ModificarDatosJuego(jugadorbase, oponenteantiguo, TextBox2.Text.ToString(), unidadesdes, int.Parse(TextBox3.Text.ToString()), unidadessob, int.Parse(TextBox4.Text.ToString()), unidadesdest, int.Parse(TextBox5.Text.ToString()));
            Button14.Visible = Button16.Visible = Button19.Visible = Label6.Visible = ddljugadorbase.Visible = Button21.Visible = DropDownList3.Visible = Button20.Visible = false;
            Label12.Visible = Label13.Visible = Label14.Visible = TextBox2.Visible = Label15.Visible = TextBox3.Visible = Label16.Visible = TextBox4.Visible = false;
            Label17.Visible = TextBox5.Visible = Button22.Visible = false;
            Label6.Visible = ddljugadorbase.Visible = Button21.Visible = DropDownList3.Visible = Button20.Visible = false;
        }

        protected void Button23_Click(object sender, EventArgs e)
        {
            Label18.Visible = DropDownList4.Visible = Label19.Visible = DropDownList5.Visible = Label20.Visible = DropDownList6.Visible = Label21.Visible = TextBox6.Visible = Button26.Visible = false;
            ServiceReference1.WebServiceProyectoSoapClient sr = new ServiceReference1.WebServiceProyectoSoapClient();
            if (sr.Llamadaagraficar("ta,"+Session["Nombre"], Server.MapPath("/images")))
            {
                string path = Server.MapPath("/images");
                path += "\\tableroinicial.jpg";
                Image2.ImageUrl = "/images/tableroinicial.jpg";
                Image2.Visible = true;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('La matriz del tablero actual se encuentra vacia');", true);
            } 
        }

        protected void Button24_Click(object sender, EventArgs e)
        {
            Label18.Visible = DropDownList4.Visible = Label19.Visible = DropDownList5.Visible = Label20.Visible = DropDownList6.Visible = Label21.Visible = TextBox6.Visible = Button26.Visible = false;
            ServiceReference1.WebServiceProyectoSoapClient sr = new ServiceReference1.WebServiceProyectoSoapClient();
            if (sr.Llamadaagraficar("ti," + Session["Nombre"], Server.MapPath("/images")))
            {
                string path = Server.MapPath("/images");
                path += "\\tableroinicial.jpg";
                Image2.ImageUrl = "/images/tableroinicial.jpg";
                Image2.Visible = true;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('La matriz del tablero inicial se encuentra vacia');", true);
            }
        }

        protected void Button25_Click(object sender, EventArgs e)
        {
            DropDownList4.Items.Clear();
            DropDownList5.Items.Clear();
            DropDownList6.Items.Clear();
            TextBox6.Text = "";
            Image2.Visible = false;
            Label18.Visible = DropDownList4.Visible = Label19.Visible = DropDownList5.Visible = Label20.Visible = DropDownList6.Visible = Label21.Visible = TextBox6.Visible = Button26.Visible = true;
            if (numnivel1 > 0 || numnivel2 > 0 || numnivel3 > 0 || numnivel4 > 0)
            {
                for (int i = 65; i < 65 + tamax; i++)
                {
                    DropDownList4.Items.Add(((char)i).ToString());
                }
                if (ubase)
                {
                    for (int i = 1; i < tamay / 2; i++)
                    {
                        DropDownList5.Items.Add(i.ToString());
                    }
                }
                else
                {
                    for (int i = tamay / 2; i < tamay; i++)
                    {
                        DropDownList5.Items.Add(i.ToString());
                    }
                }

                if (numnivel1 > 0)
                {
                    DropDownList6.Items.Add("Submarino");
                }
                if (numnivel2 > 0)
                {
                    DropDownList6.Items.Add("Crucero");
                    DropDownList6.Items.Add("Fragata");
                }
                if (numnivel3 > 0)
                {
                    DropDownList6.Items.Add("Bombardero");
                    DropDownList6.Items.Add("Caza");
                    DropDownList6.Items.Add("Helicoptero de combate");
                }
                if(numnivel4 > 0)
                {
                    DropDownList6.Items.Add("Neosatelite");
                }
                ServiceReference1.WebServiceProyectoSoapClient refer = new ServiceReference1.WebServiceProyectoSoapClient();
                refer.InicializarMatrizInicial();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "aler('Ya no se pueden ingresar mas unidades');", true);
            }
        }

        protected void Button26_Click(object sender, EventArgs e)
        {
            char columna = char.Parse(DropDownList4.SelectedValue.ToString());
            int fila = int.Parse(DropDownList5.SelectedValue.ToString());
            string idnave = DropDownList6.SelectedValue.ToString();
            int nivel;
            int mov;
            int alcance;
            int ataque;
            int vida;
            if (idnave == "Submarino")
            {
                nivel = 0;
                mov = 5;
                alcance = 1;
                ataque = 2;
                vida = 10;
            }
            else if (idnave == "Crucero" || idnave == "Fragata")
            {
                nivel = 1;
                if(idnave =="Crucero")
                {
                    mov = 6;
                    alcance = 1;
                    ataque = 3;
                    vida = 15;
                }
                else
                {
                    mov = 5;
                    alcance = 4;
                    ataque = 3;
                    vida = 10;
                }
            }
            else if (idnave == "Bombardero" || idnave == "Caza" || idnave.Contains("Helicoptero"))
            {
                nivel = 2;
                if(idnave == "Bombardero")
                {
                    mov = 7;
                    alcance = 0;
                    ataque = 5;
                    vida = 10;
                }
                else if(idnave == "Caza")
                {
                    mov = 9;
                    alcance = 1;
                    ataque = 2;
                    vida = 20;
                }
                else
                {
                    mov = 9;
                    alcance = 1;
                    ataque = 3;
                    vida = 15;
                }
            }
            else
            {
                nivel = 3;
                mov = 6;
                alcance = 0;
                ataque = 2;
                vida = 10;
            }
            idnave += TextBox6.Text;
            ServiceReference1.WebServiceProyectoSoapClient sr = new ServiceReference1.WebServiceProyectoSoapClient();
            if (!sr.ExisteNodo(nivel, columna, fila))
            {
                sr.InsertarTablero(fila, columna, nivel, mov, alcance, ataque, vida, idnave, Session["Nombre"].ToString());
                Label18.Visible = DropDownList4.Visible = Label19.Visible = DropDownList5.Visible = Label20.Visible = DropDownList6.Visible = Label21.Visible = TextBox6.Visible = Button26.Visible = false;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Ya existe una unidad en esa posicion');", true);
            }
        }
    }
}