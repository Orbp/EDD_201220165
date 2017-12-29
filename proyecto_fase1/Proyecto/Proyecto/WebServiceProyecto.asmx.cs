using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Web.UI.WebControls;

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
        static Matriz TableroInicial = null;
        static Matriz TableroActual = null;
        static ListaTopJuegosGanados topjuegosg = null;
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
        public string LUsuarios()
        {
           /* arbol.LimpiarDDLUsuarios();
            usuarios = arbol.DevolverUsuarios(arbol.GetRaiz());*/
            return arbol.DevolverUsuarios(arbol.GetRaiz());
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
            TableroActual = new Matriz();
            while (linea != null)
            {
                if (!linea.Contains("jugador,") && linea != "")
                {
                    string[] datos = linea.Split(',');
                    string idjugador = datos[0];
                    char columna = char.Parse(datos[1]);
                    int fila = int.Parse(datos[2]);
                    string idnave = datos[3];
                    int nivel;
                    int vida;
                    int ataque;
                    int alcance;
                    int movimiento;
                    if (datos[4].Contains("1"))
                    {
                        if (idnave.Contains("Neosatelite") || idnave.Contains("neosatelite"))
                        {
                            nivel = 3;
                            vida = 10;
                            ataque = 2;
                            alcance = 0;
                            movimiento = 6;
                            TableroActual.Insertar(fila, columna, nivel, movimiento, alcance, ataque, vida, idnave, idjugador);
                        }
                        else if (idnave.Contains("Bombardero") || idnave.Contains("bombardero"))
                        {
                            nivel = 2;
                            vida = 10;
                            ataque = 5;
                            alcance = 0;
                            movimiento = 7;
                            TableroActual.Insertar(fila, columna, nivel, movimiento, alcance, ataque, vida, idnave, idjugador);
                        }
                        else if (idnave.Contains("Caza") || idnave.Contains("caza"))
                        {
                            nivel = 2;
                            vida = 20;
                            ataque = 2;
                            alcance = 1;
                            movimiento = 9;
                            TableroActual.Insertar(fila, columna, nivel, movimiento, alcance, ataque, vida, idnave, idjugador);
                        }
                        else if (idnave.Contains("Helicoptero") || idnave.Contains("helicoptero"))
                        {
                            nivel = 2;
                            vida = 15;
                            ataque = 3;
                            alcance = 1;
                            movimiento = 9;
                            TableroActual.Insertar(fila, columna, nivel, movimiento, alcance, ataque, vida, idnave, idjugador);
                        }
                        else if (idnave.Contains("Fragata") || idnave.Contains("fragata"))
                        {
                            nivel = 1;
                            vida = 10;
                            ataque = 3;
                            alcance = 4;
                            movimiento = 5;
                            TableroActual.Insertar(fila, columna, nivel, movimiento, alcance, ataque, vida, idnave, idjugador);
                        }
                        else if (idnave.Contains("Crucero") || idnave.Contains("crucero"))
                        {
                            nivel = 1;
                            vida = 15;
                            ataque = 3;
                            alcance = 1;
                            movimiento = 6;
                            TableroActual.Insertar(fila, columna, nivel, movimiento, alcance, ataque, vida, idnave, idjugador);
                        }
                        else if (idnave.Contains("Submarino") || idnave.Contains("submarino"))
                        {
                            nivel = 0;
                            vida = 10;
                            ataque = 2;
                            alcance = 1;
                            movimiento = 5;
                            TableroActual.Insertar(fila, columna, nivel, movimiento, alcance, ataque, vida, idnave, idjugador);
                        }
                    }
                    else
                    {
                        if (idnave.Contains("Neosatelite") || idnave.Contains("neosatelite"))
                        {
                            nivel = 3;
                            vida = 0;
                            ataque = 2;
                            alcance = 0;
                            movimiento = 6;
                            TableroActual.Insertar(fila, columna, nivel, movimiento, alcance, ataque, vida, idnave, idjugador);
                        }
                        else if (idnave.Contains("Bombardero") || idnave.Contains("bombardero"))
                        {
                            nivel = 2;
                            vida = 0;
                            ataque = 5;
                            alcance = 0;
                            movimiento = 7;
                            TableroActual.Insertar(fila, columna, nivel, movimiento, alcance, ataque, vida, idnave, idjugador);
                        }
                        else if (idnave.Contains("Caza") || idnave.Contains("caza"))
                        {
                            nivel = 2;
                            vida = 0;
                            ataque = 2;
                            alcance = 1;
                            movimiento = 9;
                            TableroActual.Insertar(fila, columna, nivel, movimiento, alcance, ataque, vida, idnave, idjugador);
                        }
                        else if (idnave.Contains("Helicoptero") || idnave.Contains("helicoptero"))
                        {
                            nivel = 2;
                            vida = 0;
                            ataque = 3;
                            alcance = 1;
                            movimiento = 9;
                            TableroActual.Insertar(fila, columna, nivel, movimiento, alcance, ataque, vida, idnave, idjugador);
                        }
                        else if (idnave.Contains("Fragata") || idnave.Contains("fragata"))
                        {
                            nivel = 1;
                            vida = 0;
                            ataque = 3;
                            alcance = 4;
                            movimiento = 5;
                            TableroActual.Insertar(fila, columna, nivel, movimiento, alcance, ataque, vida, idnave, idjugador);
                        }
                        else if (idnave.Contains("Crucero") || idnave.Contains("crucero"))
                        {
                            nivel = 1;
                            vida = 0;
                            ataque = 3;
                            alcance = 1;
                            movimiento = 6;
                            TableroActual.Insertar(fila, columna, nivel, movimiento, alcance, ataque, vida, idnave, idjugador);
                        }
                        else if (idnave.Contains("Submarino") || idnave.Contains("submarino"))
                        {
                            nivel = 0;
                            vida = 0;
                            ataque = 2;
                            alcance = 1;
                            movimiento = 5;
                            TableroActual.Insertar(fila, columna, nivel, movimiento, alcance, ataque, vida, idnave, idjugador);
                        }
                    }
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
        public bool Validar(string nickname, string password)
        {
            if (arbol.ExisteUsuario(nickname, password))
            {
                return true;
            }
            return false;
        }

        [WebMethod]
        public bool Llamadaagraficar(string tipo, string ruta)
        {
            if (tipo == "u" && !arbol.ArbolVacio())
            {
                Graficar g = new Graficar(ruta);
                if (arbol.espejo)
                {
                    arbol.Espejo(arbol);
                }
                g.GraficarArbol(arbol, "normal");
                return true;
            }
            else if (tipo == "ue" && !arbol.ArbolVacio())
            {
                if (!arbol.espejo)
                {
                    arbol.Espejo(arbol);
                }
                Graficar g = new Graficar(ruta);
                g.GraficarArbol(arbol, "espejo");
                return true;
            }
            else if (tipo == "ta" && TableroActual != null)
            {
                Graficar g = new Graficar(ruta);
                g.GraficarTableroActual(TableroActual);
                return true;
            }
            else if (tipo == "tia" && TableroInicial != null)
            {
                Graficar g = new Graficar(ruta);
                g.GraficarTableroInicial(TableroInicial, "admin");
                return true;
            }
            else if (tipo.Contains("ta,") && TableroActual != null)
            {
                Graficar g = new Graficar(ruta);
                g.GraficarTableroInicial(TableroActual, tipo.Split(',')[1]);
                return true;
            }
            else if (tipo.Contains("ti,") && TableroInicial != null)
            {
                Graficar g = new Graficar(ruta);
                g.GraficarTableroInicial(TableroInicial, tipo.Split(',')[1]);
                return true;
            }
            else if (tipo == "ud" && TableroActual != null)
            {
                Graficar g = new Graficar(ruta);
                g.GraficarMuertos(TableroActual, true);
                return true;
            }
            else if (tipo == "us" && TableroActual != null)
            {
                Graficar g = new Graficar(ruta);
                g.GraficarMuertos(TableroActual, false);
                return true;
            }
            else if (tipo == "topj" && !arbol.ArbolVacio())
            {
                topjuegosg = new ListaTopJuegosGanados();
                arbol.listajuegosg(arbol.GetRaiz(), topjuegosg);
                Graficar g = new Graficar(ruta);
                g.GraficarTopJugadoresJuegos(topjuegosg);
                return true;
            }
            else if (tipo == "topu" && !arbol.ArbolVacio())
            {
                ListaTopUnidadesDestruidas list = new ListaTopUnidadesDestruidas();
                arbol.listaunidadesdes(arbol.GetRaiz(), list);
                Graficar g = new Graficar(ruta);
                g.GraficarTopUniDes(list);
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

        [WebMethod]
        public void InsertarJuego(string jugador1, string jugador2, int unidadesdes, int unidadessob, int unidadesdest, bool gano)
        {
            arbol.Insertarenlistajuegos(jugador1, jugador2, unidadesdes, unidadessob, unidadesdest, gano);
            arbol.Insertarenlistajuegos(jugador2, jugador1, unidadesdes, unidadessob, unidadesdest, !gano);
        }

        [WebMethod]
        public string DevolverListajuegos(string jugador)
        {
            return arbol.DevolverJuegos(jugador);
        }

        [WebMethod]
        public void BorrardeListaJuegos(string jugador1, string jugador2, int unidadesdes, int unidadessob, int unidadesdest)
        {
            arbol.BorrarJuegos(jugador1, jugador2, unidadesdes, unidadessob, unidadesdest);
        }

        [WebMethod]
        public string DevolverDatosJuego(string jugador1, string jugador2, int unidadesdes, int unidadessob, int unidadesdest)
        {
            return arbol.DevDatosJuego(jugador1, jugador2, unidadesdes, unidadessob, unidadesdest);
        }

        [WebMethod]
        public void ModificarDatosJuego(string jugador1, string oponenteantiguo, string oponentenuevo, int unidadesdesant, int unidadesdesnue, int unidadessobant, int unidadessobnue, int unidadesdestant, int unidadesdestnue)
        {
            if (oponentenuevo != oponenteantiguo || unidadesdesant != unidadesdesnue || unidadessobant != unidadessobnue || unidadesdestant != unidadesdestnue)
            {
                arbol.ModificarDatosJuego(jugador1, oponenteantiguo, oponentenuevo, unidadesdesant, unidadesdesnue, unidadessobant, unidadessobnue, unidadesdestant, unidadesdestnue);
            }
        }

        [WebMethod]
        public ArbolUsuarios GenerarArbolEspejo()
        {
            return arbol.Espejo(arbol);
        }

        [WebMethod]
        public void InicializarMatrizInicial()
        {
            if (TableroInicial == null)
            {
                TableroInicial = new Matriz();
            }
        }

        [WebMethod]
        public bool ExisteNodo(int nivel, char columna, int fila)
        {
            NodoMatriz aux = null;
            if (nivel == 0)
            {
                aux = TableroInicial.ExisteNodo(TableroInicial.enfnivel0, TableroInicial.encnivel0, fila, columna);
            }
            else if (nivel == 1)
            {
                aux = TableroInicial.ExisteNodo(TableroInicial.enfnivel1, TableroInicial.encnivel1, fila, columna);
            }
            else if (nivel == 2)
            {
                aux = TableroInicial.ExisteNodo(TableroInicial.enfnivel2, TableroInicial.encnivel2, fila, columna);
            }
            else if (nivel == 3)
            {
                aux = TableroInicial.ExisteNodo(TableroInicial.enfnivel3, TableroInicial.encnivel3, fila, columna);
            }
            if (aux == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        [WebMethod]
        public void InsertarTablero(int fila, char columna, int nivel, int movimiento, int alcance, int ataque, int vida, string idunidad, string idjugador)
        {
            TableroInicial.Insertar(fila, columna, nivel, movimiento, alcance, ataque, vida, idunidad, idjugador);
        }
    }
}
