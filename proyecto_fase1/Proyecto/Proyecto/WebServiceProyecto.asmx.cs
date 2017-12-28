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
        public static string usuario1;
        public static string usuario2;
        public static int numerodenavesnivel1;
        public static int numerodenavesnivel2;
        public static int numerodenavesnivel3;
        public static int numerodenavesnivel4;
        public static int tamx;
        public static int tamy;
        public static int tipo;
        public static string tiempoenminutos;

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
        public void SetDatosJuego(string pusuario1, string pusuario2, int pnivel1, int pnivel2, int pnivel3, int pnivel4, int ptamx, int ptamy, int ptipo, string ptiempo)
        {
            usuario1 = pusuario1;
            usuario2 = pusuario2;
            numerodenavesnivel1 = pnivel1;
            numerodenavesnivel2 = pnivel2;
            numerodenavesnivel3 = pnivel3;
            numerodenavesnivel4 = pnivel4;
            tamx = ptamx;
            tamy = ptamy;
            tipo = ptipo;
            tiempoenminutos = ptiempo;
        }

        [WebMethod]
        public string GetUsuario1()
        {
            return usuario1;
        }

        [WebMethod]
        public string GetUsuario2()
        {
            return usuario2;
        }

        [WebMethod]
        public int GetNumeroNivel1()
        {
            return numerodenavesnivel1;
        }

        [WebMethod]
        public int GetNumeroNivel2()
        {
            return numerodenavesnivel2;
        }

        [WebMethod]
        public int GetNumeroNivel3()
        {
            return numerodenavesnivel3;
        }

        [WebMethod]
        public int GetNumeroNivel4()
        {
            return numerodenavesnivel4;
        }

        [WebMethod]
        public int GetTamX()
        {
            return tamx;
        }

        [WebMethod]
        public int GetTamY()
        {
            return tamy;
        }

        [WebMethod]
        public int GetTipoJuego()
        {
            return tipo;
        }

        [WebMethod]
        public string GetTiempo()
        {
            return tiempoenminutos;
        }

        [WebMethod]
        public string CargarJuegoActual(string ruta)
        {
            StreamReader sr = new StreamReader(ruta);
            string linea = "";
            while (linea != null)
            {
                if(!linea.Contains("Nickname1,") && sr.ReadLine() == null)
                {
                    return linea;
                }
                linea = sr.ReadLine();
            }
            sr.Close();
            return "";
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
