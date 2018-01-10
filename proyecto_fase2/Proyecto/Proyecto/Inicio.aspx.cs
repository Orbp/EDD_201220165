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
        static bool ubase = false;
        static bool pasoau = false;
        static bool pasoau2 = false;

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
                //localhost.WebServiceProyecto referencia = new localhost.WebServiceProyecto();
                ServiceReference1.WebServiceProyectoSoapClient referencia = new ServiceReference1.WebServiceProyectoSoapClient();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('" + Session["Nombre"].ToString() + "');", true);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('" + referencia.GetUsuario1() + "," + referencia.GetUsuario2() + "');", true);
                if (Session["Nombre"].ToString().CompareTo(referencia.GetUsuario1()) == 0 && !pasoau)
                {
                    usuario = Session["Nombre"].ToString();
                    tamax = referencia.GetTamX();
                    tamay = referencia.GetTamY();
                    numnivel1 = referencia.GetNumeroNivel1();
                    Session["J1numnivel1"] = numnivel1;
                    numnivel2 = referencia.GetNumeroNivel2();
                    Session["J1numnivel2"] = numnivel2;
                    numnivel3 = referencia.GetNumeroNivel3();
                    Session["J1numnivel3"] = numnivel3;
                    numnivel4 = referencia.GetNumeroNivel4();
                    Session["J1numnivel4"] = numnivel1;
                    tipo = referencia.GetTipoJuego();
                    tiempo = referencia.GetTiempo();
                    ubase = true;
                    pasoau = true;
                    if(referencia.GetTipoJuego() == 3)
                    {
                        Session["J1Base"] = 1;
                    }
                }
                if(Session["Nombre"].ToString().CompareTo(referencia.GetUsuario2()) == 0 && !pasoau2)
                {
                    usuario = Session["Nombre"].ToString();
                    tamax = referencia.GetTamX();
                    tamay = referencia.GetTamY();
                    numnivel1 = referencia.GetNumeroNivel1();
                    Session["J2numnivel1"] = numnivel1;
                    numnivel2 = referencia.GetNumeroNivel2();
                    Session["J2numnivel2"] = numnivel2;
                    numnivel3 = referencia.GetNumeroNivel3();
                    Session["J2numnivel3"] = numnivel3;
                    numnivel4 = referencia.GetNumeroNivel4();
                    Session["J2numnivel4"] = numnivel4;
                    tipo = referencia.GetTipoJuego();
                    tiempo = referencia.GetTiempo();
                    ubase = false;
                    pasoau2 = true;
                    if (referencia.GetTipoJuego() == 3)
                    {
                        Session["J2Base"] = 1;
                    }
                }

                if(Session["Nombre"].ToString().CompareTo(referencia.GetUsuario1()) != 0 && Session["Nombre"].ToString().CompareTo(referencia.GetUsuario2()) != 0 && !pasoau)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('El juego actual no esta configurado para este nickname');", true);
                }

                

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('J1" + Session["J1numnivel2"] + "J2" + Session["J2numnivel2"] + "');", true);
                PanelAdmin.Visible = false;
                PanelCliente.Visible = true;
                Label22.Text = Session["Nombre"].ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["Nombre"] = null;
            pasoau = false;
            pasoau2 = false;
            Response.Redirect("Login.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            bool extension = false;
            //localhost.WebServiceProyecto referencia = new localhost.WebServiceProyecto();
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
                        if (referencia.GetTiempo() != "")
                        {
                            DropDownList8.Items.Add("Tiempo");
                        }
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
            //localhost.WebServiceProyecto referencia = new localhost.WebServiceProyecto();
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
            //localhost.WebServiceProyecto referencia = new localhost.WebServiceProyecto();
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
            //localhost.WebServiceProyecto referencia = new localhost.WebServiceProyecto();
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
                //localhost.WebServiceProyecto sr = new localhost.WebServiceProyecto();
                ServiceReference1.WebServiceProyectoSoapClient sr = new ServiceReference1.WebServiceProyectoSoapClient();
                if (sr.Llamadaagraficar("u", "C:\\Reportes"))
                {
                    string imagen = ObtenerImagen("C:\\Reportes\\arbol.jpg");
                    if (imagen != "")
                    {
                        Image1.ImageUrl = imagen;
                        Image1.Visible = true;
                        string pathdestino = Server.MapPath("/images/");
                        string pathob = @"C:\\Reportes";
                        string archivofuente = System.IO.Path.Combine(pathob, "arbol.jpg");
                        string archivodestino = System.IO.Path.Combine(pathdestino, "arbol.jpg");
                        System.IO.File.Copy(archivofuente, archivodestino, true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('El arbol de usuarios se encuentra vacio');", true);
                }
            }
            else if(this.DropDownList1.SelectedValue.ToString().CompareTo("Usuarios Modo Espejo") == 0)
            {
                //localhost.WebServiceProyecto sr = new localhost.WebServiceProyecto();
                ServiceReference1.WebServiceProyectoSoapClient sr = new ServiceReference1.WebServiceProyectoSoapClient();
                if (sr.Llamadaagraficar("ue", "C:\\Reportes\\"))
                {
                    string imagen = ObtenerImagen("C:\\Reportes\\arbolespejo.jpg");
                    if (imagen != "")
                    {
                        Image1.ImageUrl = imagen;
                        Image1.Visible = true;
                        string pathdestino = Server.MapPath("/images/");
                        string pathob = @"C:\\Reportes";
                        string archivofuente = System.IO.Path.Combine(pathob, "arbolespejo.jpg");
                        string archivodestino = System.IO.Path.Combine(pathdestino, "arbolespejo.jpg");
                        System.IO.File.Copy(archivofuente, archivodestino, true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('El arbol de usuarios se encuentra vacio');", true);
                }
            }
            else if (this.DropDownList1.SelectedValue.ToString().CompareTo("Tablero actual") == 0)
            {
                //localhost.WebServiceProyecto sr = new localhost.WebServiceProyecto();
                ServiceReference1.WebServiceProyectoSoapClient sr = new ServiceReference1.WebServiceProyectoSoapClient();
                if (sr.Llamadaagraficar("ta", "C:\\Reportes\\"))
                {
                    string imagen = ObtenerImagen("C:\\Reportes\\tableroactual.jpg");
                    if (imagen != "")
                    {

                        Image1.ImageUrl = imagen;
                        Image1.Visible = true;
                        string pathdestino = Server.MapPath("/images/");
                        string pathob = @"C:\\Reportes";
                        string archivofuente = System.IO.Path.Combine(pathob, "tableroactual.jpg");
                        string archivodestino = System.IO.Path.Combine(pathdestino, "tableroactual.jpg");
                        System.IO.File.Copy(archivofuente, archivodestino, true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('La matriz del tablero actual se encuentra vacia');", true);
                }
            }
            else if (DropDownList1.SelectedValue.ToString().CompareTo("Tablero Inicial") == 0)
            {
                //localhost.WebServiceProyecto sr = new localhost.WebServiceProyecto();
                ServiceReference1.WebServiceProyectoSoapClient sr = new ServiceReference1.WebServiceProyectoSoapClient();
                if (sr.Llamadaagraficar("tia", "C:\\Reportes\\"))
                {
                    string imagen = ObtenerImagen("C:\\Reportes\\tableroinicial.jpg");
                    if (imagen != "")
                    {
                        Image1.ImageUrl = imagen;
                        Image1.Visible = true;
                        string pathdestino = Server.MapPath("/images/");
                        string pathob = @"C:\\Reportes";
                        string archivofuente = System.IO.Path.Combine(pathob, "tableroinicialadmin.jpg");
                        string archivodestino = System.IO.Path.Combine(pathdestino, "tableroinicialadmin.jpg");
                        System.IO.File.Copy(archivofuente, archivodestino, true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('La matriz del tablero inicial se encuentra vacia');", true);
                }
            }
            else if (DropDownList1.SelectedValue.ToString().CompareTo("Unidades Sobrevivientes") == 0)
            {
                //localhost.WebServiceProyecto sr = new localhost.WebServiceProyecto();
                ServiceReference1.WebServiceProyectoSoapClient sr = new ServiceReference1.WebServiceProyectoSoapClient();
                if (sr.Llamadaagraficar("us", "C:\\Reportes\\"))
                {
                    string imagen = ObtenerImagen("C:\\Reportes\\tablerodevivos.jpg");
                    if (imagen != "")
                    {
                        Image1.ImageUrl = imagen;
                        Image1.Visible = true;
                        string pathdestino = Server.MapPath("/images/");
                        string pathob = @"C:\\Reportes";
                        string archivofuente = System.IO.Path.Combine(pathob, "tablerodevivos.jpg");
                        string archivodestino = System.IO.Path.Combine(pathdestino, "tablerodevivos.jpg");
                        System.IO.File.Copy(archivofuente, archivodestino, true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('La matriz del tablero actual se encuentra vacia');", true);
                }
            }
            else if (DropDownList1.SelectedValue.ToString().CompareTo("Unidades Destruidas") == 0)
            {
                //localhost.WebServiceProyecto sr = new localhost.WebServiceProyecto();
                ServiceReference1.WebServiceProyectoSoapClient sr = new ServiceReference1.WebServiceProyectoSoapClient();
                if (sr.Llamadaagraficar("ud", "C:\\Reportes\\"))
                {
                    string imagen = ObtenerImagen("C:\\Reportes\\tablerodemuertos.jpg");
                    if (imagen != "")
                    {
                        Image1.ImageUrl = imagen;
                        Image1.Visible = true;
                        string pathdestino = Server.MapPath("/images/");
                        string pathob = @"C:\\Reportes";
                        string archivofuente = System.IO.Path.Combine(pathob, "tablerodemuertos.jpg");
                        string archivodestino = System.IO.Path.Combine(pathdestino, "tablerodemuertos.jpg");
                        System.IO.File.Copy(archivofuente, archivodestino, true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('La matriz del tablero actual se encuentra vacia');", true);
                }
            }
            else if (DropDownList1.SelectedValue.ToString().CompareTo("Top 10 Jugadores con mas juegos ganados") == 0)
            {
                //localhost.WebServiceProyecto sr = new localhost.WebServiceProyecto();
                ServiceReference1.WebServiceProyectoSoapClient sr = new ServiceReference1.WebServiceProyectoSoapClient();
                if (sr.Llamadaagraficar("topj", "C:\\Reportes\\"))
                {
                    string imagen = ObtenerImagen("C:\\Reportes\\top10.jpg");
                    if (imagen != "")
                    {
                        Image1.ImageUrl = imagen;
                        Image1.Visible = true;
                        string pathdestino = Server.MapPath("/images/");
                        string pathob = @"C:\\Reportes";
                        string archivofuente = System.IO.Path.Combine(pathob, "top10.jpg");
                        string archivodestino = System.IO.Path.Combine(pathdestino, "top10.jpg");
                        System.IO.File.Copy(archivofuente, archivodestino, true);
                    }
                }
            }
            else if (DropDownList1.SelectedValue.ToString().CompareTo("Contactos") == 0)
            {
                DropDownList7.Items.Clear();
                ServiceReference1.WebServiceProyectoSoapClient referencia = new ServiceReference1.WebServiceProyectoSoapClient();
                string[] datos = referencia.LUsuarios().Split(',');
                for (int i = 0; i < datos.Length; i++)
                {
                    if (datos[i].Length != 0)
                    {
                        DropDownList7.Items.Add(datos[i]);
                    }
                }
                Button32.Visible = DropDownList7.Visible = true;
            }else if(DropDownList1.SelectedValue.ToString().CompareTo("Historial Cargado") == 0)
            {
                ServiceReference1.WebServiceProyectoSoapClient referencia = new ServiceReference1.WebServiceProyectoSoapClient();
                if(referencia.Llamadaagraficar("hc", "C:\\Reportes\\"))
                {
                    string imagen = ObtenerImagen("C:\\Reportes\\historial.jpg");
                    if (imagen != "")
                    {
                        Image1.ImageUrl = imagen;
                        Image1.Visible = true;
                        string pathdestino = Server.MapPath("/images/");
                        string pathob = @"C:\\Reportes";
                        string archivofuente = System.IO.Path.Combine(pathob, "historial.jpg");
                        string archivodestino = System.IO.Path.Combine(pathdestino, "historial.jpg");
                        System.IO.File.Copy(archivofuente, archivodestino, true);
                    }
                }
            }else if(DropDownList1.SelectedValue.ToString().CompareTo("Dispersion de usuarios") ==  0)
            {
                ServiceReference1.WebServiceProyectoSoapClient referencia = new ServiceReference1.WebServiceProyectoSoapClient();
                if (referencia.ExportaraHash())
                {
                    if (referencia.Llamadaagraficar("th", ""))
                    {
                        string imagen = ObtenerImagen("C:\\Reportes\\tablahash.jpg");
                        if (imagen != "")
                        {
                            Image1.ImageUrl = imagen;
                            Image1.Visible = true;
                            string pathdestino = Server.MapPath("/images/");
                            string pathob = @"C:\\Reportes";
                            string archivofuente = System.IO.Path.Combine(pathob, "tablahash.jpg");
                            string archivodestino = System.IO.Path.Combine(pathdestino, "tablahash.jpg");
                            System.IO.File.Copy(archivofuente, archivodestino, true);
                        }
                        
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('El arbol de usuarios se encuentra vacio');", true);
                }

            }
            else if (DropDownList1.SelectedValue.ToString().CompareTo("Historial de partida actual") == 0)
            {
                ServiceReference1.WebServiceProyectoSoapClient sr = new ServiceReference1.WebServiceProyectoSoapClient();
                if (sr.Llamadaagraficar("ha", "C:\\Reportes"))
                {
                    string imagen = ObtenerImagen("C:\\Reportes\\historial.jpg");
                    if (imagen != "")
                    {
                        Image1.ImageUrl = imagen;
                        Image1.Visible = true;
                        string pathdestino = Server.MapPath("/images/");
                        string pathob = @"C:\\Reportes";
                        string archivofuente = System.IO.Path.Combine(pathob, "historial.jpg");
                        string archivodestino = System.IO.Path.Combine(pathdestino, "historial.jpg");
                        System.IO.File.Copy(archivofuente, archivodestino, true);
                    }
                }
            }
            else if (DropDownList1.SelectedValue.ToString().CompareTo("Top 10 Jugadores con mas contactos") == 0)
            {
                ServiceReference1.WebServiceProyectoSoapClient sr = new ServiceReference1.WebServiceProyectoSoapClient();
                if (sr.Llamadaagraficar("topc", "C:\\Reportes"))
                {
                    string imagen = ObtenerImagen("C:\\Reportes\\topc.jpg");
                    if (imagen != "")
                    {
                        Image1.ImageUrl = imagen;
                        Image1.Visible = true;
                        string pathdestino = Server.MapPath("/images/");
                        string pathob = @"C:\\Reportes";
                        string archivofuente = System.IO.Path.Combine(pathob, "topc.jpg");
                        string archivodestino = System.IO.Path.Combine(pathdestino, "topc.jpg");
                        System.IO.File.Copy(archivofuente, archivodestino, true);
                    }
                }
            }
            else if (DropDownList1.SelectedValue.ToString().CompareTo("Top 10 Jugadores con mas unidades destruidas") == 0)
            {
                ServiceReference1.WebServiceProyectoSoapClient sr = new ServiceReference1.WebServiceProyectoSoapClient();
                if (sr.Llamadaagraficar("topud", "C:\\Reportes"))
                {
                    string imagen = ObtenerImagen("C:\\Reportes\\topud.jpg");
                    if (imagen != "")
                    {
                        Image1.ImageUrl = imagen;
                        Image1.Visible = true;
                        string pathdestino = Server.MapPath("/images/");
                        string pathob = @"C:\\Reportes";
                        string archivofuente = System.IO.Path.Combine(pathob, "topud.jpg");
                        string archivodestino = System.IO.Path.Combine(pathdestino, "topud.jpg");
                        System.IO.File.Copy(archivofuente, archivodestino, true);
                    }
                }
            }
            else if (DropDownList1.SelectedValue.ToString().CompareTo("Juego con mas ataques realizados") == 0)
            {
                ServiceReference1.WebServiceProyectoSoapClient sr = new ServiceReference1.WebServiceProyectoSoapClient();
                if (sr.Llamadaagraficar("hmas", "C:\\Reportes"))
                {
                    string imagen = ObtenerImagen("C:\\Reportes\\historial.jpg");
                    if (imagen != "")
                    {
                        Image1.ImageUrl = imagen;
                        Image1.Visible = true;
                        string pathdestino = Server.MapPath("/images/");
                        string pathob = @"C:\\Reportes";
                        string archivofuente = System.IO.Path.Combine(pathob, "historial.jpg");
                        string archivodestino = System.IO.Path.Combine(pathdestino, "historial.jpg");
                        System.IO.File.Copy(archivofuente, archivodestino, true);
                    }
                }
            }
            else if (DropDownList1.SelectedValue.ToString().CompareTo("Juego con menos ataques realizados") == 0)
            {
                ServiceReference1.WebServiceProyectoSoapClient sr = new ServiceReference1.WebServiceProyectoSoapClient();
                if (sr.Llamadaagraficar("hmenos", "C:\\Reportes"))
                {
                    string imagen = ObtenerImagen("C:\\Reportes\\historial.jpg");
                    if (imagen != "")
                    {
                        Image1.ImageUrl = imagen;
                        Image1.Visible = true;
                        string pathdestino = Server.MapPath("/images/");
                        string pathob = @"C:\\Reportes";
                        string archivofuente = System.IO.Path.Combine(pathob, "historial.jpg");
                        string archivodestino = System.IO.Path.Combine(pathdestino, "historial.jpg");
                        System.IO.File.Copy(archivofuente, archivodestino, true);
                    }
                }
            }
            else
            {
                //localhost.WebServiceProyecto sr = new localhost.WebServiceProyecto();
                ServiceReference1.WebServiceProyectoSoapClient sr = new ServiceReference1.WebServiceProyectoSoapClient();
                if (sr.Llamadaagraficar("topu", "C:\\Reportes"))
                {
                    string imagen = ObtenerImagen("C:\\Reportes\\top10u.jpg");
                    if (imagen != "")
                    {
                        Image1.ImageUrl = imagen;
                        Image1.Visible = true;
                        string pathdestino = Server.MapPath("/images/");
                        string pathob = @"C:\\Reportes";
                        string archivofuente = System.IO.Path.Combine(pathob, "top10u.jpg");
                        string archivodestino = System.IO.Path.Combine(pathdestino, "top10u.jpg");
                        System.IO.File.Copy(archivofuente, archivodestino, true);
                    }
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
            //localhost.WebServiceProyecto referencia = new localhost.WebServiceProyecto();
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
            //localhost.WebServiceProyecto referencia = new localhost.WebServiceProyecto();
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
            //localhost.WebServiceProyecto referencia = new localhost.WebServiceProyecto();
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
            //localhost.WebServiceProyecto referencia = new localhost.WebServiceProyecto();
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
            //localhost.WebServiceProyecto referencia = new localhost.WebServiceProyecto();
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
            //localhost.WebServiceProyecto referencia = new localhost.WebServiceProyecto();
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
            //localhost.WebServiceProyecto referencia = new localhost.WebServiceProyecto();
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
            //localhost.WebServiceProyecto referencia = new localhost.WebServiceProyecto();
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
            //localhost.WebServiceProyecto referencia = new localhost.WebServiceProyecto();
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
            //localhost.WebServiceProyecto referencia = new localhost.WebServiceProyecto();
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
                //localhost.WebServiceProyecto referencia = new localhost.WebServiceProyecto();
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
            //localhost.WebServiceProyecto referencia = new localhost.WebServiceProyecto();
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
            //localhost.WebServiceProyecto sr = new localhost.WebServiceProyecto();
            ServiceReference1.WebServiceProyectoSoapClient sr = new ServiceReference1.WebServiceProyectoSoapClient();
            if (sr.Llamadaagraficar("ta," + Session["Nombre"].ToString(), "C:\\Reportes"))
            {
                string imagen = ObtenerImagen("C:\\Reportes\\tableroinicial" + Session["Nombre"].ToString() + ".jpg");
                if (imagen != "")
                {
                    Image2.ImageUrl = imagen;
                    Image2.Visible = true;
                    string pathdestino = Server.MapPath("/images/");
                    string pathob = @"C:\\Reportes";
                    string archivofuente = System.IO.Path.Combine(pathob, "tableroinicial" + Session["Nombre"].ToString() + ".jpg");
                    string archivodestino = System.IO.Path.Combine(pathdestino, "tableroinicial" + Session["Nombre"].ToString() + ".jpg");
                    System.IO.File.Copy(archivofuente, archivodestino, true);
                }
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
            //localhost.WebServiceProyecto sr = new localhost.WebServiceProyecto();

            if (sr.Llamadaagraficar("ti," + Session["Nombre"], "C:\\Reportes"))
            {
                string imagen = ObtenerImagen("C:\\Reportes\\tableroinicial" + Session["Nombre"].ToString() + ".jpg");
                if (imagen != "")
                {
                    
                    Image2.Visible = true;
                    string pathdestino = Server.MapPath("/images/");
                    string pathob = @"C:\\Reportes";
                    string archivofuente = System.IO.Path.Combine(pathob, "tableroinicial" + Session["Nombre"].ToString() + ".jpg");
                    string archivodestino = System.IO.Path.Combine(pathdestino, "tableroinicial" + Session["Nombre"].ToString() + ".jpg");
                    System.IO.File.Copy(archivofuente, archivodestino, true);
                    Image2.ImageUrl = "/images/tableroinicial" + Session["Nombre"].ToString() + ".jpg"; ;
                }
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
            ServiceReference1.WebServiceProyectoSoapClient sr = new ServiceReference1.WebServiceProyectoSoapClient();
           // ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('J1" + Session["J1numnivel2"] + "J2" + Session["J2numnivel2"] + "');", true);
            if ((Session["Nombre"].ToString() == sr.GetUsuario1() && (Session["J1numnivel1"].ToString() != "0" || Session["J1numnivel2"].ToString() != "0" || Session["J1numnivel3"].ToString() != "0" || Session["J1numnivel4"].ToString() != "0")) || (Session["Nombre"].ToString() == sr.GetUsuario2() && (Session["J2numnivel1"].ToString() != "0" || Session["J2numnivel2"].ToString() != "0" || Session["J2numnivel3"].ToString() != "0" || Session["J2numnivel4"].ToString() != "0")))
            {
                for (int i = 65; i < 65 + tamax; i++)
                {
                    DropDownList4.Items.Add(((char)i).ToString());
                }
                
                if (Session["Nombre"].ToString().CompareTo(sr.GetUsuario1()) == 0)
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
                if (sr.GetTipoJuego() == 3)
                {
                    if ((Session["Nombre"].ToString() == sr.GetUsuario1() && Session["J1Base"].ToString() != "0") || (Session["Nombre"].ToString() == sr.GetUsuario2() && Session["J2Base"].ToString() != "0"))
                    {
                        DropDownList6.Items.Add("Base");
                    }
                }
                if ((Session["Nombre"].ToString() == sr.GetUsuario1() && Session["J1numnivel1"].ToString() != "0") || (Session["Nombre"].ToString() == sr.GetUsuario2() && Session["J2numnivel1"].ToString() != "0"))
                {
                    DropDownList6.Items.Add("Submarino");
                }
                if ((Session["Nombre"].ToString() == sr.GetUsuario1() && Session["J1numnivel2"].ToString() != "0") || (Session["Nombre"].ToString() == sr.GetUsuario2() && Session["J2numnivel2"].ToString() != "0"))
                {
                    DropDownList6.Items.Add("Crucero");
                    DropDownList6.Items.Add("Fragata");
                }
                if ((Session["Nombre"].ToString() == sr.GetUsuario1() && Session["J1numnivel3"].ToString() != "0") || (Session["Nombre"].ToString() == sr.GetUsuario2() && Session["J2numnivel3"].ToString() != "0"))
                {
                    DropDownList6.Items.Add("Bombardero");
                    DropDownList6.Items.Add("Caza");
                    DropDownList6.Items.Add("Helicoptero de combate");
                }
                if ((Session["Nombre"].ToString() == sr.GetUsuario1() && Session["J1numnivel4"].ToString() != "0") || (Session["Nombre"].ToString() == sr.GetUsuario2() && Session["J2numnivel4"].ToString() != "0"))
                {
                    DropDownList6.Items.Add("Neosatelite");
                }
                ServiceReference1.WebServiceProyectoSoapClient refer = new ServiceReference1.WebServiceProyectoSoapClient();
                //localhost.WebServiceProyecto refer = new localhost.WebServiceProyecto();
                refer.InicializarMatrizInicial();
                if ((Session["Nombre"].ToString() == sr.GetUsuario1() && Session["J1numnivel1"].ToString() == "0" && Session["J1numnivel2"].ToString() == "0" && Session["J1numnivel3"].ToString() == "0" && Session["J1numnivel4"].ToString() == "0") || (Session["Nombre"].ToString() == sr.GetUsuario2() && Session["J2numnivel1"].ToString() == "0" && Session["J2numnivel2"].ToString() == "0" && Session["J2numnivel3"].ToString() == "0" && Session["J2numnivel4"].ToString() == "0"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Ya no se pueden ingresar mas unidades');", true);
                    Button25.Enabled = false;
                    Label18.Visible = DropDownList4.Visible = Label19.Visible = DropDownList5.Visible = Label20.Visible = DropDownList6.Visible = Label21.Visible = TextBox6.Visible = Button26.Visible = true;
                    Button33.Enabled = true;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Ya no se pueden ingresar mas unidades');", true);
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
            else if (idnave == "Base")
            {
                nivel = 1;
                mov = 0;
                alcance = 0;
                ataque = 0;
                vida = 1;
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
            //localhost.WebServiceProyecto sr = new localhost.WebServiceProyecto();
            ServiceReference1.WebServiceProyectoSoapClient sr = new ServiceReference1.WebServiceProyectoSoapClient();
            if (!sr.ExisteNodo(nivel, columna, fila))
            {
                sr.InsertarTablero(fila, columna, nivel, mov, alcance, ataque, vida, idnave, Session["Nombre"].ToString());
                Label18.Visible = DropDownList4.Visible = Label19.Visible = DropDownList5.Visible = Label20.Visible = DropDownList6.Visible = Label21.Visible = TextBox6.Visible = Button26.Visible = false;
                if (idnave.Contains("Submarino"))
                {
                    if (Session["Nombre"].ToString().CompareTo(sr.GetUsuario1()) == 0 && int.Parse(Session["J1numnivel1"].ToString()) > 0)
                    {
                        numnivel1 = int.Parse(Session["J1numnivel1"].ToString());
                        numnivel1 -= 1;
                        Session["J1numnivel1"] = numnivel1;
                    }
                    else if (Session["Nombre"].ToString() == sr.GetUsuario2() && int.Parse(Session["J2numnivel1"].ToString()) > 0)
                    {
                        numnivel1 = int.Parse(Session["J2numnivel1"].ToString());
                        numnivel1 -= 1;
                        Session["J2numnivel1"] = numnivel1;
                    }
                    
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('J1" + Session["J1numnivel1"] + "J2" + Session["J2numnivel1"] + "');", true);
                }
                else if (idnave.Contains("Crucero") || idnave.Contains("Fragata"))
                {
                    if (Session["Nombre"].ToString() == sr.GetUsuario1() && int.Parse(Session["J1numnivel2"].ToString()) > 0)
                    {
                        numnivel1 = int.Parse(Session["J1numnivel2"].ToString());
                        numnivel1 -= 1;
                        Session["J1numnivel2"] = numnivel1;
                    }
                    else if (Session["Nombre"].ToString() == sr.GetUsuario2() && int.Parse(Session["J2numnivel2"].ToString()) > 0)
                    {
                        numnivel1 = int.Parse(Session["J2numnivel2"].ToString());
                        numnivel1 -= 1;
                        Session["J2numnivel2"] = numnivel1;
                    }

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('J1" + Session["J1numnivel2"] + "J2" + Session["J2numnivel2"] + "');", true);
                }
                else if (idnave.Contains("Bombardero") || idnave.Contains("Caza") || idnave.Contains("Helicoptero"))
                {
                    if (Session["Nombre"].ToString() == sr.GetUsuario1() && int.Parse(Session["J1numnivel3"].ToString()) > 0)
                    {
                        numnivel1 = int.Parse(Session["J1numnivel3"].ToString());
                        numnivel1 -= 1;
                        Session["J1numnivel3"] = numnivel1;
                    }
                    else if (Session["Nombre"].ToString() == sr.GetUsuario2() && int.Parse(Session["J2numnivel3"].ToString()) > 0)
                    {
                        numnivel1 = int.Parse(Session["J2numnivel3"].ToString());
                        numnivel1 -= 1;
                        Session["J2numnivel3"] = numnivel1;
                    }

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('J1" + Session["J1numnivel3"] + "J2" + Session["J2numnivel3"] + "');", true);
                }
                else if (idnave.Contains("Neosatelite"))
                {
                    if (Session["Nombre"].ToString() == sr.GetUsuario1() && int.Parse(Session["J1numnivel4"].ToString()) > 0)
                    {
                        numnivel1 = int.Parse(Session["J1numnivel4"].ToString());
                        numnivel1 -= 1;
                        Session["J1numnivel4"] = numnivel1;
                    }
                    else if (Session["Nombre"].ToString() == sr.GetUsuario2() && int.Parse(Session["J2numnivel4"].ToString()) > 0)
                    {
                        numnivel1 = int.Parse(Session["J2numnivel4"].ToString());
                        numnivel1 -= 1;
                        Session["J2numnivel4"] = numnivel1;
                    }

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('J1" + Session["J1numnivel4"] + "J2" + Session["J2numnivel4"] + "');", true);
                }
                else
                {
                    if (sr.GetTipoJuego() == 3)
                    {
                        if (Session["Nombre"].ToString() == sr.GetUsuario1() && Session["J1Base"].ToString() != "0")
                        {
                            Session["J1Base"] = 0;
                        }
                        if (Session["Nombre"].ToString() == sr.GetUsuario2() && Session["J2Base"].ToString() != "0")
                        {
                            Session["J2Base"] = 0;
                        }
                    }
                }
                if(Session["Nombre"].ToString() == sr.GetUsuario1())
                {
                    if (Session["J1numnivel1"].ToString() == "0" && Session["J1numnivel2"].ToString() == "0" && Session["J1numnivel3"].ToString() == "0" && Session["J1numnivel4"].ToString() == "0")
                    {
                        if (sr.GetTipoJuego() == 3 && Session["J1Base"].ToString() == "0")
                        {
                            Button25.Enabled = false;
                            Button33.Enabled = true;
                        }
                        else if (sr.GetTipoJuego() != 3)
                        {
                            Button25.Enabled = false;
                            Button33.Enabled = true;
                        }
                    }
                }
                else if (Session["Nombre"].ToString() == sr.GetUsuario2())
                {
                    if (Session["J2numnivel1"].ToString() == "0" && Session["J2numnivel2"].ToString() == "0" && Session["J2numnivel3"].ToString() == "0" && Session["J2numnivel4"].ToString() == "0")
                    {
                        if (sr.GetTipoJuego() == 3 && Session["J2Base"].ToString() == "0")
                        {
                            Button25.Enabled = false;
                            Button33.Enabled = true;
                        }
                        else if (sr.GetTipoJuego() != 3)
                        {
                            Button25.Enabled = false;
                            Button33.Enabled = true;
                        }
                    }
                }
                
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Ya existe una unidad en esa posicion');", true);
            }
        }

        protected void Button30_Click(object sender, EventArgs e)
        {
            if (this.TextBox7.Text.ToString().Length != 0)
            {
                this.FileUpload7.Enabled = true;
                this.Button31.Enabled = true;
                ServiceReference1.WebServiceProyectoSoapClient referencia = new ServiceReference1.WebServiceProyectoSoapClient();
                referencia.IniciarArbolCargado(int.Parse(TextBox7.Text.ToString()), DropDownList8.SelectedValue.ToString());
                DropDownList8.Enabled = false;
                TextBox7.Enabled = false;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Debe escribir un indice para poder cargar el archivo del historial de partidas');", true);
            }
        }

        protected void Button27_Click(object sender, EventArgs e)
        {
            bool extension = false;
            //localhost.WebServiceProyecto referencia = new localhost.WebServiceProyecto();
            ServiceReference1.WebServiceProyectoSoapClient referencia = new ServiceReference1.WebServiceProyectoSoapClient();

            if (FileUpload5.HasFile)
            {
                string nombrearchivo = FileUpload5.PostedFile.FileName;
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
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('" + pathguardar + "');", true);
                        FileUpload5.PostedFile.SaveAs(pathguardar + nombrearchivo);
                        if (!referencia.CargarContactos(pathguardar + nombrearchivo))
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('No se ha cargado ningun archivo de usuarios');", true);
                        }
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

        protected void DropDownList7_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void Button32_Click(object sender, EventArgs e)
        {
            string us = DropDownList7.SelectedValue.ToString();
            ServiceReference1.WebServiceProyectoSoapClient sr = new ServiceReference1.WebServiceProyectoSoapClient();
            if (sr.Llamadaagraficar("cont," + us, "C:\\Reportes"))
            {
                string imagen = ObtenerImagen("C:\\Reportes\\contactos.jpg");
                if (imagen != "")
                {
                    Image1.ImageUrl = imagen;
                    Image1.Visible = true;
                    string pathdestino = Server.MapPath("/images/");
                    string pathob = @"C:\\Reportes";
                    string archivofuente = System.IO.Path.Combine(pathob, "contactos.jpg");
                    string archivodestino = System.IO.Path.Combine(pathdestino, "contactos.jpg");
                    System.IO.File.Copy(archivofuente, archivodestino, true);
                }
                
                DropDownList7.Visible = Button32.Visible = false;
            }
        }

        protected void Button31_Click(object sender, EventArgs e)
        {
            bool extension = false;
            //localhost.WebServiceProyecto referencia = new localhost.WebServiceProyecto();
            ServiceReference1.WebServiceProyectoSoapClient referencia = new ServiceReference1.WebServiceProyectoSoapClient();

            if (FileUpload7.HasFile)
            {
                string nombrearchivo = FileUpload7.PostedFile.FileName;
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
                        FileUpload7.PostedFile.SaveAs(pathguardar + nombrearchivo);
                        if (!referencia.CargarHistorial(pathguardar + nombrearchivo, DropDownList8.SelectedValue.ToString()))
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Hubo un problema al cargar el archivo de historial');", true);
                        }
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

        public string ObtenerImagen(string ruta)
        {
            try
            {
                byte[] imagen = File.ReadAllBytes(ruta);
                string auximagen = Convert.ToBase64String(imagen);
                return string.Format("data:image/jpg;base64,{0}", auximagen);
            }
            catch (IOException e)
            {
                return "";
            }
        }

        protected void Button33_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebServiceProyectoSoapClient sr = new ServiceReference1.WebServiceProyectoSoapClient();
            sr.JugadorListo(Session["Nombre"].ToString());
            if (sr.DosJugadoresListos())
            {
                sr.Llamadaagraficar("tiu," + Session["Nombre"].ToString(), "C:\\Reportes\\");
                string pathdestino = Server.MapPath("/images/");
                string pathob = @"C:\\Reportes";
                string archivofuente = System.IO.Path.Combine(pathob, "tableroinicial" + Session["Nombre"].ToString() + ".jpg");
                string archivodestino = System.IO.Path.Combine(pathdestino, "tableroinicial" + Session["Nombre"].ToString() + ".jpg");
                System.IO.File.Copy(archivofuente, archivodestino, true);
                sr.SetPrimerTurno();
                sr.InicializarArbol();
                if (sr.GetConsola().Length == 0)
                {
                    sr.SetConsola("Turno actual: " + sr.GetUsuario1() + "\n");
                }
                
                Response.Redirect("Juego.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('El otro jugador aun no termina de colocar sus piezas, por favor pulse el boton en un momento');", true);
            }
        }
    }
}