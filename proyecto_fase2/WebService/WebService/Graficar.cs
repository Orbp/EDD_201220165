using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Proyecto;

namespace WebService
{
    public class Graficar
    {
        string ruta;
        StreamWriter sw;
        public Graficar(string ruta)
        {
            this.ruta = ruta;
        }

        public void GraficarArbol(ArbolUsuarios arbol, string tipo)
        {

            if (tipo == "normal")
            {
                sw = new StreamWriter(ruta + "\\arbol.dot");
            }
            else
            {
                sw = new StreamWriter(ruta + "\\arbolespejo.dot");
            }
            sw.WriteLine("digraph{");
            sw.WriteLine("node[shape = record];");
            sw.WriteLine("subgraph clusterdatos{");
            sw.WriteLine("label = \"Datos del arbol\"");
            sw.WriteLine("alt[label=\"Altura: " + arbol.Altura(arbol.GetRaiz(), 1) + "\"];");
            sw.WriteLine("niv[label=\"Niveles: " + arbol.AuxAltura(arbol.GetRaiz(), 0, 0) + "\"];");
            sw.WriteLine("hoja[label=\"Numero de nodos hoja: " + arbol.AuxNodosHoja(arbol.GetRaiz(), 0) + "\"];");
            sw.WriteLine("rama[label=\"Numero de nodos rama: " + arbol.AuxNodosRama(arbol.GetRaiz(), 0) + "\"];");
            sw.WriteLine("}");
            sw.WriteLine("subgraph clusterarbol{");
            if (tipo == "normal")
            {
                sw.WriteLine("label = \"Arbol de usuarios \"");
            }
            else
            {
                sw.WriteLine("label = \"Arbol espejo de usuarios\"");
            }
            sw.WriteLine(GraficarNodos(arbol.GetRaiz(), "r"));
            sw.WriteLine(GraficarConexiones(arbol.GetRaiz(), "r"));
            sw.WriteLine("}");
            sw.WriteLine("}");
            sw.Close();
            var comando = "";
            if (tipo == "normal")
            {
                comando = string.Format("dot -Tjpg C:\\Reportes\\arbol.dot -o C:\\Reportes\\arbol.jpg");
            }
            else
            {
                comando = string.Format("dot -Tjpg C:\\Reportes\\arbolespejo.dot -o C:\\Reportes\\arbolespejo.jpg");
            }

            try
            {
                //comando = string.Format("dot - version");
                var informacion = new System.Diagnostics.ProcessStartInfo("cmd", "/C" + comando);
                var proceso = new System.Diagnostics.Process();
                proceso.StartInfo = informacion;
                proceso.Start();
                proceso.WaitForExit();
                string result = proceso.StandardOutput.ReadToEnd();
                
            }
            catch (Exception e)
            {

            }
        }

        

        private string GraficarNodos(NodoArbol raiz, string lugar)
        {
            string aux = "";
            if (raiz != null)
            {
                aux += "au" + lugar + "[label = \"<f0> | <f1> Nickname: " + raiz.GetNickname() + "\\nCorreo: " + raiz.GetCorreo();
                if (raiz.GetConectado())
                {
                    aux += "\\nConectado";
                }
                else
                {
                    aux += "\\nNo Conectado";
                }
                aux += "|<f2> \"];\n";
                if (raiz.GetListaJuegos() != null)
                {
                    aux += GraficarListaJuegos(raiz.GetListaJuegos(), lugar);
                }
            }

            if (raiz.GetHijoIzquierdo() != null)
            {
                aux += GraficarNodos(raiz.GetHijoIzquierdo(), lugar + "i");
            }
            if (raiz.GetHijoDerecho() != null)
            {
                aux += GraficarNodos(raiz.GetHijoDerecho(), lugar + "d");
            }

            return aux;
        }

        public void GraficarArbol(ArbolContactos arbol)
        {

            sw = new StreamWriter(ruta + "\\contactos.dot");
            sw.WriteLine("digraph{");
            sw.WriteLine("node[shape = record];");

            sw.WriteLine("subgraph clusterarbol{");

            sw.WriteLine(GraficarNodos(arbol.GetRaiz(), "r"));
            sw.WriteLine(GraficarConexiones(arbol.GetRaiz(), "r"));
            sw.WriteLine("}");
            sw.WriteLine("}");
            sw.Close();
            var comando = "";

            comando = string.Format("dot -Tjpg {0} -o {1}", ruta + "\\contactos.dot", ruta + "\\contactos.jpg");


            var informacion = new System.Diagnostics.ProcessStartInfo("cmd", "/C" + comando);
            var proceso = new System.Diagnostics.Process();
            proceso.StartInfo = informacion;
            proceso.Start();
            proceso.WaitForExit();
        }

        private string GraficarNodos(NodoAVL raiz, string lugar)
        {
            string aux = "";
            if (raiz != null)
            {
                aux += "au" + lugar + "[label = \"<f0> | <f1> Nickname contacto: " + raiz.GetUsuario() + "\\nCorreo: " + raiz.GetCorreo() + "\\nFe:" + raiz.GetFe() + "|<f2> \"];\n";
                if (raiz.GetHijoIzquierdo() != null)
                {
                    aux += GraficarNodos(raiz.GetHijoIzquierdo(), lugar + "i");
                }
                if (raiz.GetHijoDerecho() != null)
                {
                    aux += GraficarNodos(raiz.GetHijoDerecho(), lugar + "d");
                }
            }



            return aux;
        }

        private string GraficarConexiones(NodoAVL raiz, string lugar)
        {
            string aux = "";
            if (raiz != null)
            {
                if (raiz.GetHijoIzquierdo() != null)
                {
                    aux += "au" + lugar + ":f0->au" + lugar + "i:f1;\n";
                }
                if (raiz.GetHijoDerecho() != null)
                {
                    aux += "au" + lugar + ":f2->au" + lugar + "d:f1;\n";
                }
                if (raiz.GetHijoIzquierdo() != null)
                {
                    aux += GraficarConexiones(raiz.GetHijoIzquierdo(), lugar + "i");
                }
                if (raiz.GetHijoDerecho() != null)
                {
                    aux += GraficarConexiones(raiz.GetHijoDerecho(), lugar + "d");
                }
            }

            return aux;
        }

        public void GraficarTopContactos(TopContactos lista)
        {
            sw = new StreamWriter(ruta + "\\topc.dot");
            sw.WriteLine("digraph{");
            sw.WriteLine("node[shape = record]");
            sw.WriteLine("subgraph clustertop{");
            NodoTopContactos aux = lista.inicio;
            int cont = 0;
            while (aux != null && cont < 10)
            {
                sw.WriteLine("t" + cont + "[label = \"Nombre: " + aux.usuarios + "\\nNumero de contactos: " + aux.numero + "\"];");
                aux = aux.siguiente;
                cont++;
            }
            for (int i = 0; i < cont - 1; i++)
            {
                sw.WriteLine("t" + i + "->t" + (i + 1).ToString());
            }
            sw.WriteLine("}");
            sw.WriteLine("}");
            sw.Close();
            var comando = "";

            comando = string.Format("dot -Tjpg {0} -o {1}", ruta + "\\topc.dot", ruta + "\\topc.jpg");


            var informacion = new System.Diagnostics.ProcessStartInfo("cmd", "/C" + comando);
            var proceso = new System.Diagnostics.Process();
            proceso.StartInfo = informacion;
            proceso.Start();
            proceso.WaitForExit();
        }

        private string GraficarListaJuegos(ListaJuegos lista, string lugar)
        {
            string aux = "";
            NodoListaJuegos aux1 = lista.GetPrimero();
            int cont = 0;
            while (aux1 != null)
            {
                aux += "lj" + lugar + cont.ToString() + "[label = \"Jugador Base: " + aux1.GetJugador() + "\\nOponente: " + aux1.GetOponente() + "\\nUnidades Desplegadas: " + aux1.GetUnidadesDesplegadas().ToString() + "\\nUnidades Sobrevivientes: " + aux1.GetUnidadesSobrevivientes().ToString();
                aux += "\\nUnidades Destruidas: " + aux1.GetUnidadesDestruidas();
                if (aux1.GetGano())
                {
                    aux += "\\nGano la partida\"];\n";
                }
                else
                {
                    aux += "\\nPerdio la partida\"];\n";
                }
                aux1 = aux1.GetSiguiente();
                cont++;
            }

            aux1 = lista.GetPrimero();
            cont = 0;
            while (lista.GetPrimero() != null && aux1 != null && lista.GetPrimero() != lista.GetUltimo())
            {
                if (aux1 == lista.GetPrimero())
                {
                    aux += "lj" + lugar + cont.ToString() + "->lj" + lugar + (cont + 1).ToString() + "\n";
                }
                else if (aux1 == lista.GetUltimo())
                {
                    aux += "lj" + lugar + cont.ToString() + "->lj" + lugar + (cont - 1).ToString() + "\n";
                }
                else
                {
                    aux += "lj" + lugar + cont.ToString() + "->lj" + lugar + (cont + 1).ToString() + "\n";
                    aux += "lj" + lugar + cont.ToString() + "->lj" + lugar + (cont - 1).ToString() + "\n";
                }
                aux1 = aux1.GetSiguiente();
                cont++;
            }
            return aux;
        }

        private string GraficarConexiones(NodoArbol raiz, string lugar)
        {
            string aux = "";
            if (raiz != null)
            {
                if (raiz.GetHijoIzquierdo() != null)
                {
                    aux += "au" + lugar + ":f0->au" + lugar + "i:f1;\n";
                }
                if (raiz.GetHijoDerecho() != null)
                {
                    aux += "au" + lugar + ":f2->au" + lugar + "d:f1;\n";
                }
                if (raiz.GetListaJuegos().GetPrimero() != null)
                {
                    aux += "au" + lugar + ":f1->lj" + lugar + "0;\n";
                }
            }
            if (raiz.GetHijoIzquierdo() != null)
            {
                aux += GraficarConexiones(raiz.GetHijoIzquierdo(), lugar + "i");
            }
            if (raiz.GetHijoDerecho() != null)
            {
                aux += GraficarConexiones(raiz.GetHijoDerecho(), lugar + "d");
            }
            return aux;
        }

        public void GraficarTableroActual(Matriz matriz)
        {
            sw = new StreamWriter(ruta + "\\tableroactual.dot");
            sw.Write("digraph{\n node[shape = record];\n");
            sw.WriteLine("subgraph clustertablero{");
            sw.WriteLine("label = \"Tablero Actual\";");
            GraficarMatriz(matriz);
            sw.WriteLine("}");
            sw.Write("}");
            sw.Close();
            var comando = string.Format("dot -Tjpg {0} -o {1}", ruta + "\\tableroactual.dot", ruta + "\\tableroactual.jpg");
            var informacion = new System.Diagnostics.ProcessStartInfo("cmd", "/C" + comando);
            var proceso = new System.Diagnostics.Process();
            proceso.StartInfo = informacion;
            proceso.Start();
            proceso.WaitForExit();
        }

        public void GraficarMuertos(Matriz matriz, bool muertos)
        {
            if (muertos)
            {
                sw = new StreamWriter(ruta + "\\tablerodemuertos.dot");
            }
            else
            {
                sw = new StreamWriter(ruta + "\\tablerodevivos.dot");
            }

            sw.Write("digraph{\n node[shape = record];\n");
            sw.WriteLine("subgraph clustertablero{");
            if (muertos)
            {
                sw.WriteLine("label = \"Tablero de unidades muertas\";");
                GraficarMatrizMuertos(matriz);
            }
            else
            {
                sw.WriteLine("label =\"Tablero de unidades sobrevivientes\";");
                GraficarMatrizVivos(matriz);
            }
            sw.WriteLine("}");
            sw.Write("}");
            sw.Close();
            var comando = "";
            if (muertos)
            {
                comando = string.Format("dot -Tjpg {0} -o {1}", ruta + "\\tablerodemuertos.dot", ruta + "\\tablerodemuertos.jpg");
            }
            else
            {
                comando = string.Format("dot -Tjpg {0} -o {1}", ruta + "\\tablerodevivos.dot", ruta + "\\tablerodevivos.jpg");
            }
            var informacion = new System.Diagnostics.ProcessStartInfo("cmd", "/C" + comando);
            var proceso = new System.Diagnostics.Process();
            proceso.StartInfo = informacion;
            proceso.Start();
            proceso.WaitForExit();
        }

        public void GraficarTopJugadoresJuegos(ListaTopJuegosGanados lista)
        {
            sw = new StreamWriter(ruta + "\\top10j.dot");
            sw.WriteLine("digraph{");
            sw.WriteLine("node[shape = record]");
            sw.WriteLine("subgraph clusterTop{");
            sw.WriteLine("label=\"Top 10 de jugadores con mas partidas ganadas\"");
            NodoTopJuegosGanados aux = lista.GetPrimero();
            int cont = 0;
            while (cont < 10 && aux != null)
            {
                sw.WriteLine("top" + cont + "[label = \"Jugador: " + aux.GetIdJugador() + "\\nNumero de juegos ganados: " + aux.GetNumero() + "\"];");
                aux = aux.GetSiguiente();
                cont++;
            }
            sw.WriteLine("}");
            sw.WriteLine("}");
            sw.Close();
            var comando = string.Format("dot -Tjpg {0} -o {1}", ruta + "\\top10j.dot", ruta + "\\top10.jpg");
            var informacion = new System.Diagnostics.ProcessStartInfo("cmd", "/C" + comando);
            var proceso = new System.Diagnostics.Process();
            proceso.StartInfo = informacion;
            proceso.Start();
            proceso.WaitForExit();
        }

        public void GraficarTopUniDes(ListaTopUnidadesDestruidas lista)
        {
            sw = new StreamWriter(ruta + "\\top10u.dot");
            sw.WriteLine("digraph{");
            sw.WriteLine("node[shape = record]");
            sw.WriteLine("subgraph clusterTop{");
            sw.WriteLine("label=\"Top 10 de Jugadores con mayor porcentaje de unidades destruidas\"");
            NodoTopUnidadesDestruidas aux = lista.GetPrimero();
            int cont = 0;
            while (cont < 10 && aux != null)
            {
                sw.WriteLine("top" + cont + "[label = \"Jugador: " + aux.GetId() + "\\nNumero de juegos ganados: " + aux.GetPorcentaje() + "\"];");
                aux = aux.GetSiguiente();
                cont++;
            }
            sw.WriteLine("}");
            sw.WriteLine("}");
            sw.Close();
            var comando = string.Format("dot -Tjpg {0} -o {1}", ruta + "\\top10u.dot", ruta + "\\top10u.jpg");
            var informacion = new System.Diagnostics.ProcessStartInfo("cmd", "/C" + comando);
            var proceso = new System.Diagnostics.Process();
            proceso.StartInfo = informacion;
            proceso.Start();
            proceso.WaitForExit();
        }

        void GraficarMatriz(Matriz mat)
        {
            sw.Write("subgraph clusterNivel0{\nlabel = \"Nivel 0\"\n");
            GraficarEncabezadosColumna(mat.encnivel0, 0);
            GraficarEncabezadosFila(mat.enfnivel0, 0);
            GraficarContenido(mat.enfnivel0, mat.encnivel0, 0);
            sw.Write("}\n");

            sw.Write("subgraph clusterNivel1{\nlabel = \"Nivel 1\"\n");
            GraficarEncabezadosColumna(mat.encnivel1, 1);
            GraficarEncabezadosFila(mat.enfnivel1, 1);
            GraficarContenido(mat.enfnivel1, mat.encnivel1, 1);
            sw.Write("}\n");

            sw.Write("subgraph clusterNivel2{\nlabel = \"Nivel 2\"\n");
            GraficarEncabezadosColumna(mat.encnivel2, 2);
            GraficarEncabezadosFila(mat.enfnivel2, 2);
            GraficarContenido(mat.enfnivel2, mat.encnivel2, 2);
            sw.Write("}\n");

            sw.Write("subgraph clusterNivel3{\nlabel = \"Nivel 3\"\n");
            GraficarEncabezadosColumna(mat.encnivel3, 3);
            GraficarEncabezadosFila(mat.enfnivel3, 3);
            GraficarContenido(mat.enfnivel3, mat.encnivel3, 3);
            sw.Write("}\n");
        }

        void GraficarMatriz(Matriz matriz, string usuario)
        {
            sw.Write("subgraph clusterNivel0{\nlabel = \"Nivel 0\"\n");
            GraficarEncabezadosColumna(matriz.encnivel0, 0, usuario);
            GraficarEncabezadosFila(matriz.enfnivel0, 0, usuario);
            //GraficarContenido(matriz.enfnivel0, matriz.encnivel0, 0);
            sw.Write("}\n");

            sw.Write("subgraph clusterNivel1{\nlabel = \"Nivel 1\"\n");
            GraficarEncabezadosColumna(matriz.encnivel1, 1);
            GraficarEncabezadosFila(matriz.enfnivel1, 1);
            GraficarContenido(matriz.enfnivel1, matriz.encnivel1, 1);
            sw.Write("}\n");

            sw.Write("subgraph clusterNivel2{\nlabel = \"Nivel 2\"\n");
            GraficarEncabezadosColumna(matriz.encnivel2, 2);
            GraficarEncabezadosFila(matriz.enfnivel2, 2);
            GraficarContenido(matriz.enfnivel2, matriz.encnivel2, 2);
            sw.Write("}\n");

            sw.Write("subgraph clusterNivel3{\nlabel = \"Nivel 3\"\n");
            GraficarEncabezadosColumna(matriz.encnivel3, 3);
            GraficarEncabezadosFila(matriz.enfnivel3, 3);
            GraficarContenido(matriz.enfnivel3, matriz.encnivel3, 3);
            sw.Write("}\n");
        }

        void GraficarMatrizMuertos(Matriz mat)
        {
            sw.Write("subgraph clusterNivel0{\nlabel = \"Nivel 0\"\n");
            GraficarEncabezadosColumnaMuertos(mat.encnivel0, 0);
            GraficarEncabezadosFilaMuertos(mat.enfnivel0, 0);
            //GraficarContenido(mat.enfnivel0, mat.encnivel0, 0);
            sw.Write("}\n");

            sw.Write("subgraph clusterNivel1{\nlabel = \"Nivel 1\"\n");
            GraficarEncabezadosColumnaMuertos(mat.encnivel1, 1);
            GraficarEncabezadosFilaMuertos(mat.enfnivel1, 1);
            //GraficarContenido(mat.enfnivel1, mat.encnivel1, 1);
            sw.Write("}\n");

            sw.Write("subgraph clusterNivel2{\nlabel = \"Nivel 2\"\n");
            GraficarEncabezadosColumnaMuertos(mat.encnivel2, 2);
            GraficarEncabezadosFilaMuertos(mat.enfnivel2, 2);
            //GraficarContenido(mat.enfnivel2, mat.encnivel2, 2);
            sw.Write("}\n");

            sw.Write("subgraph clusterNivel3{\nlabel = \"Nivel 3\"\n");
            GraficarEncabezadosColumnaMuertos(mat.encnivel3, 3);
            GraficarEncabezadosFilaMuertos(mat.enfnivel3, 3);
            //GraficarContenido(mat.enfnivel3, mat.encnivel3, 3);
            sw.Write("}\n");
        }

        void GraficarMatrizVivos(Matriz mat)
        {
            sw.Write("subgraph clusterNivel0{\nlabel = \"Nivel 0\"\n");
            GraficarEncabezadosColumnaVivos(mat.encnivel0, 0);
            GraficarEncabezadosFilaVivos(mat.enfnivel0, 0);
            //GraficarContenido(mat.enfnivel0, mat.encnivel0, 0);
            sw.Write("}\n");

            sw.Write("subgraph clusterNivel1{\nlabel = \"Nivel 1\"\n");
            GraficarEncabezadosColumnaVivos(mat.encnivel1, 1);
            GraficarEncabezadosFilaVivos(mat.enfnivel1, 1);
            //GraficarContenido(mat.enfnivel1, mat.encnivel1, 1);
            sw.Write("}\n");

            sw.Write("subgraph clusterNivel2{\nlabel = \"Nivel 2\"\n");
            GraficarEncabezadosColumnaVivos(mat.encnivel2, 2);
            GraficarEncabezadosFilaVivos(mat.enfnivel2, 2);
            //GraficarContenido(mat.enfnivel2, mat.encnivel2, 2);
            sw.Write("}\n");

            sw.Write("subgraph clusterNivel3{\nlabel = \"Nivel 3\"\n");
            GraficarEncabezadosColumnaVivos(mat.encnivel3, 3);
            GraficarEncabezadosFilaVivos(mat.enfnivel3, 3);
            //GraficarContenido(mat.enfnivel3, mat.encnivel3, 3);
            sw.Write("}\n");
        }

        void GraficarContenido(EncabezadoFila enfila, EncabezadosColumna encol, int nivel)
        {
            NodoEncabezado auxiliar = enfila.GetPrimero();
            while (auxiliar != null)
            {
                NodoMatriz auxiliarcontenido = auxiliar.cont;
                while (auxiliarcontenido.siguiente != null)
                {
                    sw.Write("c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel + "->c" + auxiliarcontenido.fila + auxiliarcontenido.siguiente.columna + nivel + "\n");
                    auxiliarcontenido = auxiliarcontenido.siguiente;
                }
                while (auxiliarcontenido.anterior != null)
                {
                    sw.Write("c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel + "->c" + auxiliarcontenido.fila + auxiliarcontenido.anterior.columna + nivel + "\n");
                    auxiliarcontenido = auxiliarcontenido.anterior;
                }
                auxiliar = auxiliar.siguiente;
            }
            //relaciones verticales
            auxiliar = encol.GetPrimero();
            while (auxiliar != null)
            {
                NodoMatriz auxiliarcontenido = auxiliar.cont;
                while (auxiliarcontenido.abajo != null)
                {
                    sw.Write("c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel + "->c" + auxiliarcontenido.abajo.fila + auxiliarcontenido.columna + nivel + "\n");
                    auxiliarcontenido = auxiliarcontenido.abajo;
                }

                while (auxiliarcontenido.arriba != null)
                {
                    sw.Write("c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel + "->c" + auxiliarcontenido.arriba.fila + auxiliarcontenido.columna + nivel + "\n");
                    auxiliarcontenido = auxiliarcontenido.arriba;
                }
                auxiliar = auxiliar.siguiente;
            }
        }

        void GraficarEncabezadosColumna(EncabezadosColumna encolum, int nivel)
        {
            if (encolum.GetPrimero() != null)
            {
                int cont = 0;
                NodoEncabezado auxiliar = encolum.GetPrimero();
                sw.Write("{rank = same\n");
                while (auxiliar != null)
                {
                    sw.Write("ec" + auxiliar.Get_Id() + nivel + "[label = \"Numero de columna: " + (char)auxiliar.Get_Id() + "\"];\n");
                    auxiliar = auxiliar.siguiente;
                    cont++;
                }
                sw.Write("}\n");

                auxiliar = encolum.GetPrimero();
                while (auxiliar.siguiente != null)
                {
                    sw.Write("ec" + auxiliar.Get_Id() + nivel + "->ec" + auxiliar.siguiente.Get_Id() + nivel + "\n");
                    sw.Write("ec" + auxiliar.Get_Id() + nivel + "->c" + auxiliar.cont.fila + auxiliar.cont.columna + nivel + "\n");
                    auxiliar = auxiliar.siguiente;
                }
                sw.Write("ec" + auxiliar.Get_Id() + nivel + "->c" + auxiliar.cont.fila + auxiliar.cont.columna + nivel + "\n");
            }
        }

        void GraficarEncabezadosColumna(EncabezadosColumna encolum, int nivel, string usuario)
        {
            if (encolum.GetPrimero() != null)
            {
                int cont = 0;
                NodoEncabezado auxiliar = encolum.GetPrimero();
                sw.Write("{rank = same\n");
                while (auxiliar != null)
                {
                    NodoMatriz auxiliarcontenido = auxiliar.cont;
                    while (auxiliarcontenido != null)
                    {
                        if (auxiliarcontenido.idjugador == usuario)
                        {
                            sw.WriteLine("ec" + auxiliar.Get_Id() + nivel + "[label = \"Numero de columna: " + (char)auxiliar.Get_Id() + "\"];\n");
                            break;
                        }
                        auxiliarcontenido = auxiliarcontenido.abajo;
                    }

                    auxiliar = auxiliar.siguiente;
                    cont++;
                }
                sw.Write("}\n");

                auxiliar = encolum.GetPrimero();
                string anterior = "";
                while (auxiliar != null)
                {
                    NodoMatriz auxiliarcontenido = auxiliar.cont;
                    while (auxiliarcontenido != null)
                    {
                        if (auxiliarcontenido.idjugador == usuario)
                        {
                            if (anterior == "")
                            {
                                anterior = "ec" + auxiliar.Get_Id() + nivel;
                            }
                            else
                            {
                                sw.WriteLine(anterior + "->ec" + auxiliar.Get_Id() + nivel);
                                anterior = "ec" + auxiliar.Get_Id() + nivel;
                            }
                            break;
                        }
                        auxiliarcontenido = auxiliarcontenido.abajo;
                    }
                    auxiliar = auxiliar.siguiente;
                }

                auxiliar = encolum.GetPrimero();
                anterior = "";
                while (auxiliar != null)
                {
                    NodoMatriz auxiliarcontenido = auxiliar.cont;
                    anterior = "";
                    while (auxiliarcontenido != null)
                    {
                        if (auxiliarcontenido.idjugador == usuario)
                        {
                            if (anterior == "")
                            {
                                sw.WriteLine("ec" + auxiliar.Get_Id() + nivel + "->c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel);
                                anterior = "c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel;
                            }
                            else
                            {
                                sw.WriteLine(anterior + "->c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel);
                                sw.WriteLine("c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel + "->" + anterior);
                                anterior = "c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel;
                            }
                        }
                        auxiliarcontenido = auxiliarcontenido.abajo;
                    }

                    auxiliar = auxiliar.siguiente;
                }
            }
        }

        void GraficarEncabezadosColumnaMuertos(EncabezadosColumna encolum, int nivel)
        {
            if (encolum.GetPrimero() != null)
            {
                int cont = 0;
                NodoEncabezado auxiliar = encolum.GetPrimero();
                sw.Write("{rank = same\n");
                while (auxiliar != null)
                {
                    NodoMatriz auxiliarcontenido = auxiliar.cont;
                    while (auxiliarcontenido != null)
                    {
                        if (auxiliarcontenido.vidad == 0)
                        {
                            sw.WriteLine("ec" + auxiliar.Get_Id() + nivel + "[label = \"Numero de columna: " + (char)auxiliar.Get_Id() + "\"];\n");
                            break;
                        }
                        auxiliarcontenido = auxiliarcontenido.abajo;
                    }

                    auxiliar = auxiliar.siguiente;
                    cont++;
                }
                sw.Write("}\n");

                auxiliar = encolum.GetPrimero();
                string anterior = "";
                while (auxiliar != null)
                {
                    NodoMatriz auxiliarcontenido = auxiliar.cont;
                    while (auxiliarcontenido != null)
                    {
                        if (auxiliarcontenido.vidad == 0)
                        {
                            if (anterior == "")
                            {
                                anterior = "ec" + auxiliar.Get_Id() + nivel;
                            }
                            else
                            {
                                sw.WriteLine(anterior + "->ec" + auxiliar.Get_Id() + nivel);
                                anterior = "ec" + auxiliar.Get_Id() + nivel;
                            }
                            break;
                        }
                        auxiliarcontenido = auxiliarcontenido.abajo;
                    }
                    auxiliar = auxiliar.siguiente;
                }

                auxiliar = encolum.GetPrimero();
                anterior = "";
                while (auxiliar != null)
                {
                    NodoMatriz auxiliarcontenido = auxiliar.cont;
                    anterior = "";
                    while (auxiliarcontenido != null)
                    {
                        if (auxiliarcontenido.vidad == 0)
                        {
                            if (anterior == "")
                            {
                                sw.WriteLine("ec" + auxiliar.Get_Id() + nivel + "->c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel);
                                anterior = "c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel;
                            }
                            else
                            {
                                sw.WriteLine(anterior + "->c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel);
                                sw.WriteLine("c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel + "->" + anterior);
                                anterior = "c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel;
                            }
                        }
                        auxiliarcontenido = auxiliarcontenido.abajo;
                    }

                    auxiliar = auxiliar.siguiente;
                }
            }
        }

        void GraficarEncabezadosColumnaVivos(EncabezadosColumna encolum, int nivel)
        {
            if (encolum.GetPrimero() != null)
            {
                int cont = 0;
                NodoEncabezado auxiliar = encolum.GetPrimero();
                sw.Write("{rank = same\n");
                while (auxiliar != null)
                {
                    NodoMatriz auxiliarcontenido = auxiliar.cont;
                    while (auxiliarcontenido != null)
                    {
                        if (auxiliarcontenido.vidad != 0)
                        {
                            sw.WriteLine("ec" + auxiliar.Get_Id() + nivel + "[label = \"Numero de columna: " + (char)auxiliar.Get_Id() + "\"];\n");
                            break;
                        }
                        auxiliarcontenido = auxiliarcontenido.abajo;
                    }

                    auxiliar = auxiliar.siguiente;
                    cont++;
                }
                sw.Write("}\n");

                auxiliar = encolum.GetPrimero();
                string anterior = "";
                while (auxiliar != null)
                {
                    NodoMatriz auxiliarcontenido = auxiliar.cont;
                    while (auxiliarcontenido != null)
                    {
                        if (auxiliarcontenido.vidad != 0)
                        {
                            if (anterior == "")
                            {
                                anterior = "ec" + auxiliar.Get_Id() + nivel;
                            }
                            else
                            {
                                sw.WriteLine(anterior + "->ec" + auxiliar.Get_Id() + nivel);
                                anterior = "ec" + auxiliar.Get_Id() + nivel;
                            }
                            break;
                        }
                        auxiliarcontenido = auxiliarcontenido.abajo;
                    }
                    auxiliar = auxiliar.siguiente;
                }

                auxiliar = encolum.GetPrimero();
                anterior = "";
                while (auxiliar != null)
                {
                    NodoMatriz auxiliarcontenido = auxiliar.cont;
                    anterior = "";
                    while (auxiliarcontenido != null)
                    {
                        if (auxiliarcontenido.vidad != 0)
                        {
                            if (anterior == "")
                            {
                                sw.WriteLine("ec" + auxiliar.Get_Id() + nivel + "->c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel);
                                anterior = "c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel;
                            }
                            else
                            {
                                sw.WriteLine(anterior + "->c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel);
                                sw.WriteLine("c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel + "->" + anterior);
                                anterior = "c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel;
                            }
                        }
                        auxiliarcontenido = auxiliarcontenido.abajo;
                    }

                    auxiliar = auxiliar.siguiente;
                }
            }
        }

        void GraficarEncabezadosFila(EncabezadoFila enfila, int nivel)
        {
            if (enfila.GetPrimero() != null)
            {
                int cont = 0;
                NodoEncabezado auxiliar = enfila.GetPrimero();
                while (auxiliar != null)
                {
                    sw.Write("{rank = same\n");
                    sw.Write("ef" + auxiliar.Get_Id() + nivel + "[label = \"Numero de fila: " + auxiliar.Get_Id() + "\"];\n");

                    NodoMatriz auxiliarcontenido = auxiliar.cont;
                    while (auxiliarcontenido != null)
                    {
                        sw.Write("c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel + "[label = \"Fila: " + auxiliarcontenido.fila + "\\nColumna: " + auxiliarcontenido.columna + "\\nUnidad: " + auxiliarcontenido.idunidad + "\\nJugador: " + auxiliarcontenido.idjugador + "\\nVida: " + auxiliarcontenido.vidad);
                        
                        sw.Write("\"];\n");
                        auxiliarcontenido = auxiliarcontenido.siguiente;
                    }

                    sw.Write("}");
                    auxiliar = auxiliar.siguiente;
                    cont++;
                }

                auxiliar = enfila.GetPrimero();
                while (auxiliar.siguiente != null)
                {
                    sw.Write("ef" + auxiliar.Get_Id() + nivel + "->ef" + auxiliar.siguiente.Get_Id() + nivel + "\n");
                    sw.Write("ef" + auxiliar.Get_Id() + nivel + "->c" + auxiliar.cont.fila + auxiliar.cont.columna + nivel + "\n");
                    auxiliar = auxiliar.siguiente;
                }
                sw.Write("ef" + auxiliar.Get_Id() + nivel + "->c" + auxiliar.cont.fila + auxiliar.cont.columna + nivel + "\n");
            }
        }

        void GraficarEncabezadosFila(EncabezadoFila enfila, int nivel, string usuario)
        {
            if (enfila.GetPrimero() != null)
            {
                int cont = 0;
                NodoEncabezado auxiliar = enfila.GetPrimero();
                string anterior;
                while (auxiliar != null)
                {
                    sw.Write("{rank = same\n");

                    anterior = "";
                    NodoMatriz auxiliarcontenido = auxiliar.cont;
                    while (auxiliarcontenido != null)
                    {
                        if (auxiliarcontenido.idjugador == usuario)
                        {
                            if (anterior == "")
                            {
                                sw.Write("ef" + auxiliar.Get_Id() + nivel + "[label = \"Numero de fila: " + auxiliar.Get_Id() + "\"];\n");
                                sw.Write("c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel + "[label = \"Fila: " + auxiliarcontenido.fila + "\\nColumna: " + auxiliarcontenido.columna + "\\nUnidad: " + auxiliarcontenido.idunidad + "\\nJugador: " + auxiliarcontenido.idjugador + "\\nVida: " + auxiliarcontenido.vidad);
                                sw.Write("\"];\n");
                                sw.WriteLine("ef" + auxiliar.Get_Id() + nivel + "->c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel);
                                anterior = "c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel;
                            }
                            else
                            {
                                sw.Write("c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel + "[label = \"Fila: " + auxiliarcontenido.fila + "\\nColumna: " + auxiliarcontenido.columna + "\\nUnidad: " + auxiliarcontenido.idunidad + "\\nJugador: " + auxiliarcontenido.idjugador + "\\nVida: " + auxiliarcontenido.vidad);
                                sw.Write("\"];\n");
                                sw.WriteLine(anterior + "->c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel);
                                sw.WriteLine("c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel + "->" + anterior);
                                anterior = "c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel;
                            }
                        }

                        auxiliarcontenido = auxiliarcontenido.siguiente;
                    }

                    sw.Write("}");
                    auxiliar = auxiliar.siguiente;
                    cont++;
                }

                auxiliar = enfila.GetPrimero();
                anterior = "";
                while (auxiliar != null)
                {
                    NodoMatriz auxiliarcontenido = auxiliar.cont;
                    while (auxiliarcontenido != null)
                    {
                        if (auxiliarcontenido.idjugador == usuario)
                        {
                            if (anterior == "")
                            {
                                anterior = "ef" + auxiliar.Get_Id() + nivel;
                            }
                            else
                            {
                                sw.WriteLine(anterior + "->ef" + auxiliar.Get_Id() + nivel);
                                anterior = "ef" + auxiliar.Get_Id() + nivel;
                            }
                            break;
                        }
                        auxiliarcontenido = auxiliarcontenido.siguiente;
                    }
                    auxiliar = auxiliar.siguiente;
                }
            }
        }

        void GraficarEncabezadosFilaMuertos(EncabezadoFila enfila, int nivel)
        {
            if (enfila.GetPrimero() != null)
            {
                int cont = 0;
                NodoEncabezado auxiliar = enfila.GetPrimero();
                string anterior;
                while (auxiliar != null)
                {
                    sw.Write("{rank = same\n");

                    anterior = "";
                    NodoMatriz auxiliarcontenido = auxiliar.cont;
                    while (auxiliarcontenido != null)
                    {
                        if (auxiliarcontenido.vidad == 0)
                        {
                            if (anterior == "")
                            {
                                sw.Write("ef" + auxiliar.Get_Id() + nivel + "[label = \"Numero de fila: " + auxiliar.Get_Id() + "\"];\n");
                                sw.Write("c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel + "[label = \"Fila: " + auxiliarcontenido.fila + "\\nColumna: " + auxiliarcontenido.columna + "\\nUnidad: " + auxiliarcontenido.idunidad + "\\nJugador: " + auxiliarcontenido.idjugador + "\\nVida: " + auxiliarcontenido.vidad);
                                sw.Write("\"];\n");
                                sw.WriteLine("ef" + auxiliar.Get_Id() + nivel + "->c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel);
                                anterior = "c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel;
                            }
                            else
                            {
                                sw.Write("c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel + "[label = \"Fila: " + auxiliarcontenido.fila + "\\nColumna: " + auxiliarcontenido.columna + "\\nUnidad: " + auxiliarcontenido.idunidad + "\\nJugador: " + auxiliarcontenido.idjugador + "\\nVida: " + auxiliarcontenido.vidad);
                                sw.Write("\"];\n");
                                sw.WriteLine(anterior + "->c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel);
                                sw.WriteLine("c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel + "->" + anterior);
                                anterior = "c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel;
                            }
                        }

                        auxiliarcontenido = auxiliarcontenido.siguiente;
                    }

                    sw.Write("}");
                    auxiliar = auxiliar.siguiente;
                    cont++;
                }

                auxiliar = enfila.GetPrimero();
                anterior = "";
                while (auxiliar != null)
                {
                    NodoMatriz auxiliarcontenido = auxiliar.cont;
                    while (auxiliarcontenido != null)
                    {
                        if (auxiliarcontenido.vidad == 0)
                        {
                            if (anterior == "")
                            {
                                anterior = "ef" + auxiliar.Get_Id() + nivel;
                            }
                            else
                            {
                                sw.WriteLine(anterior + "->ef" + auxiliar.Get_Id() + nivel);
                                anterior = "ef" + auxiliar.Get_Id() + nivel;
                            }
                            break;
                        }
                        auxiliarcontenido = auxiliarcontenido.siguiente;
                    }
                    auxiliar = auxiliar.siguiente;
                }
            }
        }

        void GraficarEncabezadosFilaVivos(EncabezadoFila enfila, int nivel)
        {
            if (enfila.GetPrimero() != null)
            {
                int cont = 0;
                NodoEncabezado auxiliar = enfila.GetPrimero();
                string anterior;
                while (auxiliar != null)
                {
                    sw.Write("{rank = same\n");

                    anterior = "";
                    NodoMatriz auxiliarcontenido = auxiliar.cont;
                    while (auxiliarcontenido != null)
                    {
                        if (auxiliarcontenido.vidad != 0)
                        {
                            if (anterior == "")
                            {
                                sw.Write("ef" + auxiliar.Get_Id() + nivel + "[label = \"Numero de fila: " + auxiliar.Get_Id() + "\"];\n");
                                sw.Write("c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel + "[label = \"Fila: " + auxiliarcontenido.fila + "\\nColumna: " + auxiliarcontenido.columna + "\\nUnidad: " + auxiliarcontenido.idunidad + "\\nJugador: " + auxiliarcontenido.idjugador + "\\nVida: " + auxiliarcontenido.vidad);
                                sw.Write("\"];\n");
                                sw.WriteLine("ef" + auxiliar.Get_Id() + nivel + "->c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel);
                                anterior = "c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel;
                            }
                            else
                            {
                                sw.Write("c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel + "[label = \"Fila: " + auxiliarcontenido.fila + "\\nColumna: " + auxiliarcontenido.columna + "\\nUnidad: " + auxiliarcontenido.idunidad + "\\nJugador: " + auxiliarcontenido.idjugador + "\\nVida: " + auxiliarcontenido.vidad);
                                sw.Write("\"];\n");
                                sw.WriteLine(anterior + "->c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel);
                                sw.WriteLine("c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel + "->" + anterior);
                                anterior = "c" + auxiliarcontenido.fila + auxiliarcontenido.columna + nivel;
                            }
                        }

                        auxiliarcontenido = auxiliarcontenido.siguiente;
                    }

                    sw.Write("}");
                    auxiliar = auxiliar.siguiente;
                    cont++;
                }

                auxiliar = enfila.GetPrimero();
                anterior = "";
                while (auxiliar != null)
                {
                    NodoMatriz auxiliarcontenido = auxiliar.cont;
                    while (auxiliarcontenido != null)
                    {
                        if (auxiliarcontenido.vidad != 0)
                        {
                            if (anterior == "")
                            {
                                anterior = "ef" + auxiliar.Get_Id() + nivel;
                            }
                            else
                            {
                                sw.WriteLine(anterior + "->ef" + auxiliar.Get_Id() + nivel);
                                anterior = "ef" + auxiliar.Get_Id() + nivel;
                            }
                            break;
                        }
                        auxiliarcontenido = auxiliarcontenido.siguiente;
                    }
                    auxiliar = auxiliar.siguiente;
                }
            }
        }

        public void GraficarTableroInicial(Matriz matriz, string usuario)
        {
            sw = new StreamWriter(ruta + "\\tableroinicial" + usuario + ".dot");
            sw.Write("digraph{\n node[shape = record];\n");
            sw.WriteLine("subgraph clustertablero{");
            sw.WriteLine("label = \"Tablero Inicial\";");
            if (usuario == "admin")
            {
                GraficarMatriz(matriz);
            }
            else
            {
                GraficarMatriz(matriz, usuario);
            }
            sw.WriteLine("}");
            sw.Write("}");
            sw.Close();
            var comando = string.Format("dot -Tjpg {0} -o {1}", ruta + "\\tableroinicial" + usuario + ".dot", ruta + "\\tableroinicial" + usuario + ".jpg");
            var informacion = new System.Diagnostics.ProcessStartInfo("cmd", "/C" + comando);
            var proceso = new System.Diagnostics.Process();
            proceso.StartInfo = informacion;
            proceso.Start();
            proceso.WaitForExit();
        }

        public void GraficarHistorial(ArbolHistorial arbol)
        {
            sw = new StreamWriter(ruta + "\\historial.dot");
            sw.WriteLine("digraph{");
            sw.WriteLine("node[shape = record];");
            sw.WriteLine("subgraph clusterHistorial{");
            sw.WriteLine("label = \"Historial de tiros\"");
            GraficarHistorial(arbol.GetNodoEntrada(), "0");
            sw.WriteLine("}");
            sw.WriteLine("}");
            sw.Close();
            var comando = string.Format("dot -Tjpg {0} -o {1}", ruta + "\\historial.dot", ruta + "\\historial.jpg");
            var informacion = new System.Diagnostics.ProcessStartInfo("cmd", "/C" + comando);
            var proceso = new System.Diagnostics.Process();
            proceso.StartInfo = informacion;
            proceso.Start();
            proceso.WaitForExit();
        }

        private void GraficarHistorial(NodoHistorial nodo, string val)
        {
            if (nodo != null)
            {
                sw.Write("ab" + val + "[label = \"{{");
                int indice = 0;
                for (int i = 0; i < nodo.GetClavesUsadas(); i++)
                {
                    if (i != nodo.GetClavesUsadas() - 1)
                    {
                        sw.Write("X: " + nodo.Datos[i].GetCoordenadaX());
                        sw.Write("\\nY: " + nodo.Datos[i].GetCoordenadaY());
                        sw.Write("\\nUnidad Atacante: " + nodo.Datos[i].GetUnidadatacante());
                        sw.Write("\\nResultado: " + nodo.Datos[i].GetResultado());
                        sw.Write("\\nTipo de unidad dañada: " + nodo.Datos[i].GetTipoUnidadesDan());
                        sw.Write("\\nEmisor: " + nodo.Datos[i].GetEmisor());
                        sw.Write("\\nReceptor: " + nodo.Datos[i].GetReceptor());
                        sw.Write("\\nFecha: " + nodo.Datos[i].GetFecha().ToString());
                        sw.Write("\\nTiempo Restante: " + nodo.Datos[i].GetTiempo());
                        sw.Write("\\nNumero de ataque: " + nodo.Datos[i].GetNumerodeataque());
                        sw.Write("|");
                    }
                    else
                    {
                        sw.Write("X: " + nodo.Datos[i].GetCoordenadaX());
                        sw.Write("\\nY: " + nodo.Datos[i].GetCoordenadaY());
                        sw.Write("\\nUnidad Atacante: " + nodo.Datos[i].GetUnidadatacante());
                        sw.Write("\\nResultado: " + nodo.Datos[i].GetResultado());
                        sw.Write("\\nTipo de unidad dañada: " + nodo.Datos[i].GetTipoUnidadesDan());
                        sw.Write("\\nEmisor: " + nodo.Datos[i].GetEmisor());
                        sw.Write("\\nReceptor: " + nodo.Datos[i].GetReceptor());
                        sw.Write("\\nFecha: " + nodo.Datos[i].GetFecha().ToString());
                        sw.Write("\\nTiempo Restante: " + nodo.Datos[i].GetTiempo());
                        sw.Write("\\nNumero de ataque: " + nodo.Datos[i].GetNumerodeataque());
                    }
                }
                sw.Write("}|{");
                for (int i = 0; i < nodo.GetClavesUsadas() + 1; i++)
                {
                    if (i != nodo.GetClavesUsadas())
                    {
                        sw.Write("<f" + i + ">|");
                    }
                    else
                    {
                        sw.Write("<f" + i + ">");
                    }
                }
                sw.Write("}}\"];\n");
                for (int i = 0; i < nodo.GetClavesUsadas() + 1; i++)
                {
                    if (nodo.Ramas[i] != null)
                    {
                        sw.WriteLine("ab" + val + ":<f" + i + ">->ab" + (val + i.ToString()) + ";");
                    }
                    GraficarHistorial(nodo.Ramas[i], val + i.ToString());
                }
            }
        }

        public void GraficarTabla(TablaHashUsuarios tabla)
        {
            sw = new StreamWriter("C:\\Reportes\\hash.dot");
            sw.WriteLine("digraph{");
            sw.WriteLine("node[shape = record]");
            GraficarTabla(tabla.nodos);
            sw.WriteLine("}");
            sw.Close();
            var comando = string.Format("dot -Tjpg {0} -o {1}", "C:\\Reportes\\hash.dot", "C:\\Reportes\\tablahash.jpg");
            var informacion = new System.Diagnostics.ProcessStartInfo("cmd", "/C" + comando);
            var proceso = new System.Diagnostics.Process();
            proceso.StartInfo = informacion;
            proceso.Start();
            proceso.WaitForExit();
        }

        private void GraficarTabla(NodoHashUsuarios[] nodos)
        {
            sw.Write("t[label = \"{");
            for (int i = 0; i < nodos.Length; i++)
            {
                if (i == nodos.Length - 1)
                {
                    if (nodos[i] != null && nodos[i].nickname.Length != 0)
                    {
                        sw.Write("{Indice: " + i + "\\nNickname: " + nodos[i].nickname + "\\nPassword: " + nodos[i].password + "\\nCorreo: " + nodos[i].correo);
                        if (nodos[i].conectado)
                        {
                            sw.Write("\\nConectado");
                        }
                        else
                        {
                            sw.Write("\\nNo Conectado");
                        }
                        sw.Write("}");
                    }
                }
                else
                {
                    if (nodos[i] != null && nodos[i].nickname.Length != 0)
                    {
                        sw.Write("{Indice: " + i + "\\nNickname: " + nodos[i].nickname + "\\nPassword: " + nodos[i].password + "\\nCorreo: " + nodos[i].correo);
                        if (nodos[i].conectado)
                        {
                            sw.Write("\\nConectado");
                        }
                        else
                        {
                            sw.Write("\\nNo Conectado");
                        }
                        sw.Write("}|");
                    }
                }
            }
            sw.Write("}\"];\n");
        }
    }
}