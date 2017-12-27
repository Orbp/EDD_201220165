using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;

namespace Proyecto
{
    /// <summary>
    /// Descripción breve de WebServiceProyecto
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceProyecto : System.Web.Services.WebService
    {

        static ArbolUsuarios arbol = new ArbolUsuarios();

        [WebMethod]
        public void IniciarArbol()
        {
            arbol = new ArbolUsuarios();
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public void CargarJuegoActual(string ruta)
        {
            StreamReader sr = new StreamReader(ruta);
            string linea = "";
            while (linea != null)
            {
                if(!linea.Contains("Nickname1,"))
                {
                    string[] datos = linea.Split(',');
                }
                linea = sr.ReadLine();
            }
            sr.Close();
        }

        [WebMethod]
        public void CargarJuegos(string ruta)
        {
            StreamReader sr = new StreamReader(ruta);
            string linea = "";
            while (linea != null)
            {
                if (!linea.Contains("Usuario Base,"))
                {
                    string[] datos = linea.Split(',');
                    if (arbol.ExisteUsuario(datos[0]) && arbol.ExisteUsuario(datos[1]))
                    {
                        bool auxgano;
                        if(datos[5] == "1")
                        {
                            auxgano = true;
                        }
                        else
                        {
                            auxgano = false;
                        }
                        arbol.Insertarenlistajuegos(datos[0], datos[1], int.Parse(datos[2]), int.Parse(datos[3]), int.Parse(datos[4]), auxgano);
                        arbol.Insertarenlistajuegos(datos[1], datos[0], int.Parse(datos[2]), int.Parse(datos[3]), int.Parse(datos[4]), !auxgano);
                    }
                }
                linea = sr.ReadLine();
            }
            sr.Close();
        }

        [WebMethod]
        public void CargarTablero(string ruta)
        {
            StreamReader sr = new StreamReader(ruta);
            string linea = "";
            while (linea != null)
            {
                if (!linea.Contains("jugador,"))
                {
                    string[] datos = linea.Split(',');

                }
                linea = sr.ReadLine();
            }
            sr.Close();
        }

        [WebMethod]
        public bool CargarUsuarios(string ruta)
        {
            StreamReader sr = new StreamReader(ruta);
            string linea = "";
            while (linea != null)
            {
                
                if (!linea.Contains("Nickname,") && linea.CompareTo("") != 0)
                {
                    string[] datos = linea.Split(',');                
                    bool aux;
                    if (datos[3].CompareTo("1") == 0)
                    {
                        aux = true;
                    }
                    else
                    {
                        aux = false;
                    }
                    if (arbol.GetRaiz() == null)
                    {
                        arbol.SetRaiz(new NodoArbol(datos[0], datos[1], datos[2], aux));
                    }
                    else
                    {
                        arbol.Insertar(arbol.GetRaiz(), datos[0], datos[1], datos[2], aux);
                    }
                    
                }
                linea = sr.ReadLine();
            }
            sr.Close();
            if (linea == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod]
        public bool BuscarUsuario(string pnickname)
        {
            if (arbol.ExisteUsuario(pnickname))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        [WebMethod]
        public bool Llamadaagraficar(string tipo, string ruta)
        {
            if (tipo == "u" && !arbol.ArbolVacio())
            {
                Graficar g = new Graficar(ruta);
                g.GraficarArbol(arbol);
                return true;
            }
            return false;
        }

        [WebMethod]
        public string Devolverusuario(string pnickname)
        {
            string aux = "";
            NodoArbol aux1 = arbol.GetUsuario(pnickname);
            if (aux1 != null)
            {
                aux += aux1.GetNickname() + ",";
                aux += aux1.GetPassword() + ",";
                aux += aux1.GetCorreo();
            }
            return aux;
        }

        [WebMethod]
        public void ModificarUsuarios(string pnickname, string password, string correo)
        {
            NodoArbol aux = arbol.GetRaiz();
            while (aux != null)
            {
                if (aux.GetNickname() == pnickname)
                {
                    aux.SetPassword(password);
                    aux.SetCorreo(correo);
                    aux.SetConectado(aux.GetConectado());
                }
                if (aux.GetNickname().CompareTo(pnickname) > 0)
                {
                    aux = aux.GetHijoIzquierdo();
                }
                else
                {
                    aux = aux.GetHijoDerecho();
                }
            }
        }

        [WebMethod]
        public bool ModificarNicknameUsuarios(string pnicknameantiguo, string pnicknamenuevo, string password, string correo)
        {
            NodoArbol aux = arbol.GetRaiz();
            if (!arbol.ExisteUsuario(pnicknamenuevo))
            {
                while (aux != null)
                {
                    if (aux.GetNickname() == pnicknameantiguo)
                    {
                        bool con = aux.GetConectado();
                        EliminarUsuarios(pnicknameantiguo);
                        arbol.Insertar(arbol.GetRaiz(), pnicknamenuevo, password, correo, con);
                    }
                    if (aux.GetNickname().CompareTo(pnicknameantiguo) > 0)
                    {
                        aux = aux.GetHijoIzquierdo();
                    }
                    else
                    {
                        aux = aux.GetHijoDerecho();
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod]
        public bool EliminarUsuarios(string pnickname)
        {
            if (arbol.EliminarUsuario(pnickname))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
