using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Proyecto;
using System.IO;

namespace WebService
{
    /// <summary>
    /// Descripción breve de WebServiceProyecto.
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
        static Matriz TableroJuegoActual = null;
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
        static string formaor;
        static int index;
        public static string tiempoenminutos;
        static ArbolHistorial historialcargado;
        static ArbolHistorial historialactual;
        static TablaHashUsuarios tabla;
        static bool jugador1listo = false;
        static bool jugador2listo = false;
        static string turnoactual = "";

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
        public void SetTurnoActual(string usuario)
        {
            if (turnoactual == "")
            {
                SetPrimerTurno();
            }
            else if (turnoactual == usuario && usuario == usuario1)
            {
                turnoactual = usuario2;
            }
            else
            {
                turnoactual = usuario1;
            }
        }

        [WebMethod]
        public void SetPrimerTurno()
        {
            turnoactual = usuario1;
        }

        [WebMethod]
        public bool EsMiTurno(string usuario)
        {
            if (turnoactual == usuario)
            {
                return true;
            }
            return false;
        }

        [WebMethod]
        public void JugadorListo(string usuario)
        {
            if (usuario == usuario1)
            {
                jugador1listo = true;
            }
            else if (usuario2 == usuario)
            {
                jugador2listo = true;
            }
        }

        [WebMethod]
        public bool DosJugadoresListos()
        {
            return jugador1listo && jugador2listo;
        }

        [WebMethod]
        public void IniciarArbolCargado(int indice, string forma)
        {
            historialcargado = new ArbolHistorial(indice);
            index = indice;
            formaor = forma;
        }

        [WebMethod]
        public void InicializarArbol()
        {
            historialactual = new ArbolHistorial(index);
        }

        [WebMethod]
        public string LUsuarios()
        {

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
            if (tipo == 1 || tipo == 2)
            {
                tiempoenminutos = "";
            }
            else
            {
                tiempoenminutos = ptiempo;
            }
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
            string lineaanterior = "";
            while (linea != null)
            {
                lineaanterior = linea;
                linea = sr.ReadLine();
            }
            
            sr.Close();
            return lineaanterior;
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
                        if (datos[5] == "1")
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
        public bool CargarContactos(string ruta)
        {
            if (!arbol.ArbolVacio())
            {
                StreamReader sr = new StreamReader(ruta);
                string linea = "";
                while (linea != null)
                {

                    if (!linea.Contains("\"Usuario padre\",") && linea.CompareTo("") != 0)
                    {
                        string[] datos = linea.Split(',');

                        if (arbol.ExisteUsuario(datos[0]))
                        {
                            arbol.InsertarContacto(datos[0], datos[1], datos[2], datos[3]);
                            NodoArbol aux = arbol.GetUsuario(datos[0]);
                            if (aux.GetContactos().GetRaiz() == null)
                            {
                                if (arbol.ExisteUsuario(datos[1]))
                                {
                                    aux.GetContactos().SetRaiz(new NodoAVL(arbol.GetUsuario(datos[1])));
                                }
                                else
                                {
                                    aux.GetContactos().SetRaiz(new NodoAVL(datos[1], datos[2], datos[3]));
                                }
                            }
                            else
                            {
                                if (arbol.ExisteUsuario(datos[1]))
                                {
                                    aux.GetContactos().Insertar(arbol.GetUsuario(datos[1]));
                                }
                                else
                                {
                                    aux.GetContactos().Insertar(datos[1], datos[2], datos[3]);
                                }
                            }

                        }
                    }
                    linea = sr.ReadLine();
                }
                sr.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod]
        public bool ExportaraHash()
        {
            if (!arbol.ArbolVacio())
            {
                tabla = new TablaHashUsuarios();
                arbol.ExportaraHash(tabla, arbol.GetRaiz());
                return true;
            }
            return false;
        }

        [WebMethod]
        public bool CargarHistorial(string ruta, string forma)
        {
            StreamReader sr = new StreamReader(ruta);
            string linea = "";
            while (linea != null)
            {
                if (linea.CompareTo("Coordenada X,Coordenada Y,Unidad Atacante,Resultado (golpe = 0 eliminacion de objetivo = 1),Unidad Atacada,Emisor,Receptor,Fecha,Tiempo Restante,numero de ataque") != 0 )
                {
                    if (linea.CompareTo("") != 0)
                    {
                        string[] datos = linea.Split(',');
                        DatosNodoHistoria datos1 = new DatosNodoHistoria();
                        datos1.SetCoordenadaX(datos[0]);
                        datos1.SetCoordenadaY(datos[1]);
                        datos1.SetUnidadatacante(datos[2]);
                        datos1.SetResultado(datos[3]);
                        datos1.SetTipoUnidadesDan(datos[4]);
                        datos1.SetEmisor(datos[5]);
                        datos1.SetReceptor(datos[6]);
                        datos1.SetFecha(Convert.ToDateTime(datos[7]));
                        string[] tiempo = datos[8].Split(':');
                        string auxtiempo = tiempo[0] + tiempo[1];
                        datos1.SetTiempo(int.Parse(auxtiempo));
                        datos1.SetNumerodeataque(int.Parse(datos[9]));
                        if (forma == "Coordenada X")
                        {
                            if (historialcargado.InsertarHistorialCoordenadaX(datos1))
                            {
                                System.Diagnostics.Debug.WriteLine("entro");
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine("no entro");
                            }
                        }
                        else if (forma == "Coordenada Y")
                        {
                            historialcargado.InsertarHistorialCoordenadaY(datos1);
                        }
                        else if (forma == "Unidad Atacante")
                        {
                            historialcargado.InsertarHistorialUnidadAtacante(datos1);
                        }
                        else if (forma == "Resultado(Daño, eliminacion del objetivo)")
                        {
                            historialcargado.InsertarHistorialResultado(datos1);
                        }
                        else if (forma == "Tipo de Unidad Dañada")
                        {
                            historialcargado.InsertarHistorialUnidadDan(datos1);
                        }
                        else if (forma == "Emisor")
                        {
                            historialcargado.InsertarHistorialEmisor(datos1);
                        }
                        else if (forma == "Receptor")
                        {
                            historialcargado.InsertarHistorialReceptor(datos1);
                        }
                        else if (forma == "Fecha")
                        {
                            historialcargado.InsertarHistorialFecha(datos1);
                        }
                        else if (forma == "Numero de ataque")
                        {
                            historialcargado.InsertarHistorialNumerodetiro(datos1);
                        }
                        else
                        {
                            historialcargado.InsertarHistorialTiempo(datos1);
                        }
                    }
                }
                historialcargado.Mostrar(historialcargado.GetNodoEntrada());
                linea = sr.ReadLine();
            }
            sr.Close();
            return true;
        }

        [WebMethod]
        public bool BuscarUsuario(string pnickname)
        {
            if (arbol.ExisteUsuario(pnickname))
            {
                return false;
            }
            return true;
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
            else if (tipo.Contains("tiu,") && TableroJuegoActual != null)
            {
                Graficar g = new Graficar(ruta);
                g.GraficarTableroInicial(TableroJuegoActual, tipo.Split(',')[1]);
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
            else if (tipo.Contains("cont,") && !arbol.ArbolVacio())
            {
                Graficar g = new Graficar(ruta);
                string user = tipo.Split(',')[1];
                g.GraficarArbol(arbol.GetUsuario(user).GetContactos());
                user = "";
                return true;
            }
            else if (tipo == "hc" && historialcargado != null)
            {
                Graficar g = new Graficar(ruta);
                g.GraficarHistorial(historialcargado);
                return true;
            }
            else if (tipo == "th" && tabla != null)
            {
                Graficar g = new Graficar("");
                g.GraficarTabla(tabla);
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
            return false;
        }

        [WebMethod]
        public bool EliminarUsuarios(string pnickname)
        {
            if (arbol.EliminarUsuario(pnickname))
            {
                return true;
            }
            return false;
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
                 TableroJuegoActual = new Matriz();
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
            return true;
        }

        [WebMethod]
        public bool ExistePieza(int nivel, char columna, int fila, string pieza, string jugador)
        {
            if (nivel == 0)
            {
                return TableroJuegoActual.ExistePieza(TableroJuegoActual.enfnivel0, TableroJuegoActual.encnivel0, fila, columna, pieza, jugador);
            }
            else if (nivel == 1)
            {
                return TableroJuegoActual.ExistePieza(TableroJuegoActual.enfnivel1, TableroJuegoActual.encnivel1, fila, columna, pieza, jugador);
            }
            else if (nivel == 2)
            {
                return TableroJuegoActual.ExistePieza(TableroJuegoActual.enfnivel2, TableroJuegoActual.encnivel2, fila, columna, pieza, jugador);
            }
            else
            {
                return TableroJuegoActual.ExistePieza(TableroJuegoActual.enfnivel3, TableroJuegoActual.encnivel3, fila, columna, pieza, jugador);
            }
        }

        [WebMethod]
        public bool ExisteNodoMov(int nivel, char columna, int fila)
        {
            NodoMatriz aux = null;
            if (nivel == 0)
            {
                aux = TableroJuegoActual.ExisteNodo(TableroJuegoActual.enfnivel0, TableroJuegoActual.encnivel0, fila, columna);
            }
            else if (nivel == 1)
            {
                aux = TableroJuegoActual.ExisteNodo(TableroJuegoActual.enfnivel1, TableroJuegoActual.encnivel1, fila, columna);
            }
            else if (nivel == 2)
            {
                aux = TableroJuegoActual.ExisteNodo(TableroJuegoActual.enfnivel2, TableroJuegoActual.encnivel2, fila, columna);
            }
            else if (nivel == 3)
            {
                aux = TableroJuegoActual.ExisteNodo(TableroJuegoActual.enfnivel3, TableroJuegoActual.encnivel3, fila, columna);
            }
            if (aux == null)
            {
                return false;
            }
            return true;
        }

        [WebMethod]
        public bool ValidarMovimiento(string idnave, int fila, char columna, int filadest, char columnadest)
        {
            if (filadest > 0 && filadest <= tamy && columnadest > 64 && columnadest <= tamx + 65)
            {
                int espacios = 0;
                if (filadest > fila)
                {
                    espacios += filadest - fila;
                }
                else
                {
                    espacios += fila - filadest;
                }
                if (columnadest > columna)
                {
                    espacios += columnadest - columna;
                }
                else
                {
                    espacios += columna - columnadest;
                }
                if (idnave.Contains("Submarino") || idnave.Contains("Fragata"))
                {
                    if (espacios <= 5)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (idnave.Contains("Crucero") || idnave.Contains("Neosatelite"))
                {
                    if (espacios <= 6)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (idnave.Contains("Bombardero"))
                {
                    if (espacios <= 7)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (idnave.Contains("Caza") || idnave.Contains("Helicoptero"))
                {
                    if (espacios <= 9)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        [WebMethod]
        public bool ValidarAtaque(string idnave, int nivel, int fila, char columna, int nivelfinal, int filafinal, char columnafinal)
        {
            if (nivelfinal >= 0 && nivelfinal <= 3 && filafinal > 0 && filafinal < tamy && columnafinal > 64 && columnafinal < tamx + 65)
            {
                int espaciosfila = 0;
                int espacioscolumna = 0;
                int espaciosnivel = 0;
                if (filafinal > fila)
                {
                    espaciosfila += filafinal - fila;
                }
                else
                {
                    espaciosfila += fila - filafinal;
                }

                if (columnafinal > columna)
                {
                    espacioscolumna += columnafinal - columna;
                }
                else
                {
                    espacioscolumna += columna - columnafinal;
                }

                if (nivelfinal > nivel)
                {
                    espaciosnivel += nivelfinal - nivel;
                }
                else
                {
                    espaciosnivel += nivel - nivelfinal;
                }
                if ((espaciosnivel != 0 && espacioscolumna == 0 && espaciosfila == 0) || (espaciosnivel == 0 && espacioscolumna != 0 && espaciosfila == 0) || (espaciosnivel == 0 && espacioscolumna == 0 && espaciosfila != 0))
                {
                    if (espaciosfila == 1 || espacioscolumna == 1 || (espaciosnivel == 1 && nivelfinal > nivelfinal))
                    {
                        if (idnave.Contains("Submarino") || idnave.Contains("Crucero") || idnave.Contains("Helicoptero") || idnave.Contains("Caza"))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    if (espaciosnivel == 1 && nivelfinal < nivel)
                    {
                        if (idnave.Contains("Submarino") || idnave.Contains("Crucero") || idnave.Contains("Helicoptero") || idnave.Contains("Caza") || idnave.Contains("Neosatelite") || idnave.Contains("Bombardero"))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    if ((espacioscolumna + espaciosfila + espaciosnivel) >= 2 || (espacioscolumna + espaciosfila + espaciosnivel) <= 6)
                    {
                        if (idnave.Contains("Fragata"))
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
            return false;
        }

        [WebMethod]
        public bool Atacar(int nivel, int fila, char col, int nivelfinal, int filafinal, char columnafinal)
        {
            EncabezadoFila auxenf = null;
            EncabezadosColumna auxenc = null;
            if (nivelfinal == 0)
            {
                auxenc = TableroJuegoActual.encnivel0;
                auxenf = TableroJuegoActual.enfnivel0;
            }
            else if (nivelfinal == 1)
            {
                auxenc = TableroJuegoActual.encnivel1;
                auxenf = TableroJuegoActual.enfnivel1;
            }
            else if (nivelfinal == 2)
            {
                auxenc = TableroJuegoActual.encnivel2;
                auxenf = TableroJuegoActual.enfnivel2;
            }
            else if (nivelfinal == 3)
            {
                auxenc = TableroJuegoActual.encnivel3;
                auxenf = TableroJuegoActual.enfnivel3;
            }
            NodoMatriz auxatacado = TableroJuegoActual.ExisteNodo(auxenf, auxenc, filafinal, columnafinal);
            NodoMatriz auxatacante = TableroJuegoActual.ExisteNodo(auxenf, auxenc, fila, col);
            if (!auxatacante.atacar)
            {
                int ataque = auxatacante.ataque;
                int vida = auxatacado.vidad;
                if (ataque > vida)
                {
                    auxatacado.vidad = 0;
                }
                else
                {
                    auxatacado.vidad = vida - ataque;
                }
                auxatacante.atacar = true;
                return true;
            }
            return false;
        }

        [WebMethod]
        public bool Mover(int nivel, int fila, char col, int filadest, char coldest)
        {
            EncabezadoFila auxenf = null;
            EncabezadosColumna auxenc = null;

            if (nivel == 0)
            {
                auxenc = TableroJuegoActual.encnivel0;
                auxenf = TableroJuegoActual.enfnivel0;
            }
            else if (nivel == 1)
            {
                auxenc = TableroJuegoActual.encnivel1;
                auxenf = TableroJuegoActual.enfnivel1;
            }
            else if (nivel == 2)
            {
                auxenc = TableroJuegoActual.encnivel2;
                auxenf = TableroJuegoActual.enfnivel2;
            }
            else
            {
                auxenc = TableroJuegoActual.encnivel3;
                auxenf = TableroJuegoActual.enfnivel3;
            }

            NodoMatriz aux = TableroJuegoActual.Eliminar(auxenf, auxenc, fila, col);
            if (aux != null && !aux.mover)
            {
                TableroJuegoActual.Insertar(filadest, coldest, nivel, aux.movimiento, aux.alcance, aux.ataque, aux.vidad, aux.idunidad, aux.idjugador);
                aux = TableroJuegoActual.ExisteNodo(auxenf, auxenc, filadest, coldest);
                aux.mover = true;
                return true;
            }

            return false;
        }

        [WebMethod]
        public void InsertarTablero(int fila, char columna, int nivel, int movimiento, int alcance, int ataque, int vida, string idunidad, string idjugador)
        {
            TableroInicial.Insertar(fila, columna, nivel, movimiento, alcance, ataque, vida, idunidad, idjugador);
            TableroJuegoActual.Insertar(fila, columna, nivel, movimiento, alcance, ataque, vida, idunidad, idjugador);
        }
    }
}
