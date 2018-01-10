using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Proyecto
{
    public partial class Juego : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Nombre"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                ServiceReference1.WebServiceProyectoSoapClient sr = new ServiceReference1.WebServiceProyectoSoapClient();
                if (sr.GetUsuario1() == Session["Nombre"].ToString() || sr.GetUsuario2() == Session["Nombre"].ToString())
                {
                    TableroNivel0.ImageUrl = "/images/tableroinicial" + Session["Nombre"].ToString() + ".jpg";
                }
                //Response.AppendHeader("Refresh", "30; URL = Juego.aspx");
                if (sr.GetTipoJuego() == 1 || sr.GetTipoJuego() == 3)
                {
                    string ganador = sr.ObtenerGanador(sr.GetUsuario1());
                    if (ganador.Length > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('El ganador fue " + sr.GetUsuario2() + "');", true);
                        Response.Redirect("Inicio.aspx");
                    }
                    ganador = sr.ObtenerGanador(sr.GetUsuario2());
                    if (ganador.Length > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('El ganador fue " + sr.GetUsuario1() + "');", true);
                        Response.Redirect("Inicio.aspx");
                    }
                }
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebServiceProyectoSoapClient sr = new ServiceReference1.WebServiceProyectoSoapClient();

            if (TextBox2.Text.ToString().Length > 0 && TextBox3.Text.ToString().Length > 0 && TextBox4.Text.Length > 0 && TextBox5.Text.ToString().Length > 0 && TextBox6.Text.ToString().Length > 0)
            {

                if (sr.EsMiTurno(Session["Nombre"].ToString()))
                {
                    string idnave = TextBox2.Text.ToString();
                    int filainicial = 0;
                    char columnainicial;
                    int filafinal;
                    char columnafinal;
                    filainicial = int.Parse(TextBox3.Text.ToString());
                    columnainicial = char.Parse(TextBox4.Text.ToString());
                    filafinal = int.Parse(TextBox5.Text.ToString());
                    columnafinal = char.Parse(TextBox6.Text.ToString());
                    int nivel = 0;
                    if (idnave.Contains("Submarino"))
                    {
                        nivel = 0;
                    }
                    else if (idnave.Contains("Crucero") || idnave.Contains("Fragata"))
                    {
                        nivel = 1;
                    }
                    else if (idnave.Contains("Bombardero") || idnave.Contains("Caza") || idnave.Contains("Helicoptero"))
                    {
                        nivel = 2;
                    }
                    else if (idnave.Contains("Neosatelite"))
                    {
                        nivel = 3;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('No existe ese tipo de nave');", true);
                    }

                    //criptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('" + sr.ExistePieza(nivel, columnainicial, filafinal, idnave, Session["Nombre"].ToString()) + sr.ExisteNodoMov(nivel, columnafinal, filafinal) + "');", true);
                    if (sr.ExistePieza(nivel, columnainicial, filainicial, idnave, Session["Nombre"].ToString()) && sr.ExisteNodoMov(nivel, columnafinal, filafinal) == false)
                    {
                        if (sr.ValidarMovimiento(idnave, filainicial, columnainicial, filafinal, columnafinal))
                        {
                            if (sr.Mover(nivel, filainicial, columnainicial, filafinal, columnafinal))
                            {
                                if (sr.GetUsuario1() == Session["Nombre"].ToString() || sr.GetUsuario2() == Session["Nombre"].ToString())
                                {
                                    sr.Llamadaagraficar("tiu," + Session["Nombre"].ToString(), "C:\\Reportes\\");
                                    string pathdestino = Server.MapPath("/images/");
                                    string pathob = @"C:\\Reportes";
                                    string archivofuente = System.IO.Path.Combine(pathob, "tableroinicial" + Session["Nombre"].ToString() + ".jpg");
                                    string archivodestino = System.IO.Path.Combine(pathdestino, "tableroinicial" + Session["Nombre"].ToString() + ".jpg");
                                    System.IO.File.Copy(archivofuente, archivodestino, true);
                                    TableroNivel0.ImageUrl = "/images/tableroinicial" + Session["Nombre"].ToString() + ".jpg";
                                    TextBox2.Text = "";
                                    TextBox3.Text = "";
                                    TextBox4.Text = "";
                                    TextBox5.Text = "";
                                    TextBox6.Text = "";
                                    string consola = TextArea1.Value.ToString();
                                    sr.SetConsola("Unidad: " + idnave + ", paso de la fila: " + filainicial + " y columna: " + columnainicial + " a la fila: " + filafinal + " y columna: " + columnafinal + "\n");
                                    TextArea1.Value = "";
                                    TextArea1.Value = sr.GetConsola();
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('No se pudo mover la pieza');", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('La pieza ingresada no se puede mover a esa poscion');", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('No existe una pieza con el id ingresado');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('No es su turno, por favor espere');", true);
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox7.Text.Length > 0 && TextBox8.Text.Length > 0 && TextBox9.Text.Length > 0 && TextBox10.Text.Length > 0 && TextBox11.Text.Length > 0 && TextBox12.Text.Length > 0)
            {
                ServiceReference1.WebServiceProyectoSoapClient sr = new ServiceReference1.WebServiceProyectoSoapClient();
                if (sr.EsMiTurno(Session["Nombre"].ToString()))
                {
                    string idnave = TextBox7.Text.ToString();
                    int filainicio = int.Parse(TextBox8.Text.ToString());
                    char columnainicio = char.Parse(TextBox9.Text.ToString());
                    int filafinal = int.Parse(TextBox10.Text.ToString());
                    char columnafinal = char.Parse(TextBox11.Text.ToString());
                    int nivelfinal = int.Parse(TextBox12.Text.ToString());
                    int nivel = 0;
                    if (idnave.Contains("Submarino"))
                    {
                        nivel = 0;
                    }
                    else if (idnave.Contains("Crucero") || idnave.Contains("Fragata"))
                    {
                        nivel = 1;
                    }
                    else if (idnave.Contains("Bombardero") || idnave.Contains("Caza") || idnave.Contains("Helicoptero"))
                    {
                        nivel = 2;
                    }
                    else if (idnave.Contains("Neosatelite"))
                    {
                        nivel = 3;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('No existe ese tipo de nave');", true);
                    }

                    if (sr.ExistePieza(nivel, columnainicio, filainicio, idnave, Session["Nombre"].ToString()))
                    {
                        if (sr.ExisteNodoMov(nivelfinal, columnafinal, filafinal))
                        {
                            if (sr.ValidarAtaque(idnave, nivel, filainicio, columnainicio, nivelfinal, filafinal, columnafinal))
                            {
                                if (sr.Atacar(nivel, filainicio, columnainicio, nivelfinal, filafinal, columnafinal))
                                {
                                    sr.Llamadaagraficar("tiu," + Session["Nombre"].ToString(), "C:\\Reportes\\");
                                    string pathdestino = Server.MapPath("/images/");
                                    string pathob = @"C:\\Reportes";
                                    string archivofuente = System.IO.Path.Combine(pathob, "tableroinicial" + Session["Nombre"].ToString() + ".jpg");
                                    string archivodestino = System.IO.Path.Combine(pathdestino, "tableroinicial" + Session["Nombre"].ToString() + ".jpg");
                                    System.IO.File.Copy(archivofuente, archivodestino, true);
                                    TableroNivel0.ImageUrl = "/images/tableroinicial" + Session["Nombre"].ToString() + ".jpg";
                                    TextBox7.Text = TextBox8.Text = TextBox9.Text = TextBox10.Text = TextBox11.Text = TextBox12.Text = "";
                                    string consola = TextArea1.Value.ToString();
                                    sr.SetConsola("Unidad: " + idnave + " ataco desde fila: " + filainicio + " y columna: " + columnainicio + " a la Unidad: " + idnave + " que esta en fila: " + filafinal + " y columna: " + columnafinal + "\n");
                                    TextArea1.Value = "";
                                    TextArea1.Value = sr.GetConsola();
                                    if (sr.GetTipoJuego() == 1 || sr.GetTipoJuego() == 3)
                                    {
                                        string ganador = sr.ObtenerGanador(Session["Nombre"].ToString());
                                        if (ganador.Length > 0)
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('El ganador fue " + Session["Nombre"] + "');", true);
                                            sr.FinalizarPartida(sr.GetUsuario1() + "vs." + sr.GetUsuario2());
                                            Response.Redirect("Inicio.aspx");
                                        }
                                    }
                                }
                                else if (sr.Atacardondenohaynada(nivel, filainicio, columnainicio, nivelfinal, filafinal, columnafinal))
                                {
                                    TextBox7.Text = TextBox8.Text = TextBox9.Text = TextBox10.Text = TextBox11.Text = TextBox12.Text = "";
                                    string consola = TextArea1.Value.ToString();
                                    sr.SetConsola("Unidad: " + idnave + " ataco desde fila: " + filainicio + " y columna: " + columnainicio + " a la fila: " + filafinal + " y columna: " + columnafinal + " pero no se encuentra ninguna unidad en esa posicion.\n");
                                    TextArea1.Value = "";
                                    TextArea1.Value = sr.GetConsola();
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('La unidad con la que desea atacar no puede atacar');", true);
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('No se puede atacar en esa posicion con la nave ingresada');", true);
                            }
                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('No existe una nave con ese nombre en la posicion inidcada');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('No es su turno, por favor espere');", true);
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebServiceProyectoSoapClient sr = new ServiceReference1.WebServiceProyectoSoapClient();
            sr.SetTurnoActual(Session["Nombre"].ToString());
            sr.FinallizarTurno(Session["Nombre"].ToString());
            if (Session["Nombre"].ToString() == sr.GetUsuario1())
            {
                string consola = TextArea1.Value.ToString();
                sr.SetConsola("Turno actual: " + sr.GetUsuario2() + "\n");
                TextArea1.Value = "";
                TextArea1.Value = sr.GetConsola();
            }
            else
            {
                string consola = TextArea1.Value.ToString();
                sr.SetConsola("Turno actual: " + sr.GetUsuario2() + "\n");
                TextArea1.Value = "";
                TextArea1.Value = sr.GetConsola();
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebServiceProyectoSoapClient sr = new ServiceReference1.WebServiceProyectoSoapClient();
            if (sr.EsMiTurno(Session["Nombre"].ToString()))
            {
                sr.Llamadaagraficar("tiu," + Session["Nombre"].ToString(), "C:\\Reportes\\");
                string pathdestino = Server.MapPath("/images/");
                string pathob = @"C:\\Reportes";
                string archivofuente = System.IO.Path.Combine(pathob, "tableroinicial" + Session["Nombre"].ToString() + ".jpg");
                string archivodestino = System.IO.Path.Combine(pathdestino, "tableroinicial" + Session["Nombre"].ToString() + ".jpg");
                System.IO.File.Copy(archivofuente, archivodestino, true);
                TableroNivel0.ImageUrl = "/images/tableroinicial" + Session["Nombre"].ToString() + ".jpg";
                //TextBox7.Text = TextBox8.Text = TextBox9.Text = TextBox10.Text = TextBox11.Text = TextBox12.Text = "";
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            ServiceReference1.WebServiceProyectoSoapClient sr = new ServiceReference1.WebServiceProyectoSoapClient();
            if (sr.GetUsuario1() == Session["Nombre"].ToString() || sr.GetUsuario2() == Session["Nombre"].ToString())
            {
                //TextBox1.Text = sr.GetConsola();
                sr.Llamadaagraficar("tiu," + Session["Nombre"].ToString(), "C:\\Reportes\\");
                string pathdestino = Server.MapPath("/images/");
                string pathob = @"C:\\Reportes";
                string archivofuente = System.IO.Path.Combine(pathob, "tableroinicial" + Session["Nombre"].ToString() + ".jpg");
                string archivodestino = System.IO.Path.Combine(pathdestino, "tableroinicial" + Session["Nombre"].ToString() + ".jpg");
                System.IO.File.Copy(archivofuente, archivodestino, true);
                TableroNivel0.ImageUrl = "/images/tableroinicial" + Session["Nombre"].ToString() + ".jpg";
                
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

        protected void Timer2_Tick(object sender, EventArgs e)
        {
            ServiceReference1.WebServiceProyectoSoapClient sr = new ServiceReference1.WebServiceProyectoSoapClient();
            TextArea1.Value = "";
            TextArea1.Value = sr.GetConsola();
        }
    }
}