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
                        referencia.CargarJuegoActual(pathguardar + nombrearchivo);
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
    }
}