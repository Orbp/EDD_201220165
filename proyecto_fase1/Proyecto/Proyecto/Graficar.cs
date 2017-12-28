using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Proyecto
{
    public class Graficar
    {
        string ruta;
        StreamWriter sw;
        public Graficar(string ruta)
        {
            this.ruta = ruta;
        }

        public void GraficarArbol(ArbolUsuarios arbol)
        {
            sw = new StreamWriter(ruta + "\\arbol.dot");
            sw.WriteLine("digraph{");
            sw.WriteLine("node[shape = record];");
            sw.WriteLine("label = \"Arbol de usuarios \"");
            sw.WriteLine(GraficarNodos(arbol.GetRaiz(), "r"));
            sw.WriteLine(GraficarConexiones(arbol.GetRaiz(), "r"));
            sw.WriteLine("}");
            sw.Close();
            var comando = string.Format("dot -Tjpg {0} -o {1}", ruta + "\\arbol.dot", ruta + "\\arbol.jpg");
            var informacion = new System.Diagnostics.ProcessStartInfo("cmd", "/C" + comando);
            var proceso = new System.Diagnostics.Process();
            proceso.StartInfo = informacion;
            proceso.Start();
            proceso.WaitForExit();
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
    }
}