using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto
{
    public class ListaJuegos
    {
        private NodoListaJuegos primero;
        private NodoListaJuegos ultimo;

        public ListaJuegos()
        {
            this.primero = null;
            this.ultimo = null;
        }

        public NodoListaJuegos GetPrimero()
        {
            return this.primero;
        }

        public NodoListaJuegos GetUltimo()
        {
            return this.ultimo;
        }

        public void InsertarListaJuegos(string pjugador, string poponente, int punides, int punisob, int punidest, bool pgano)
        {
            NodoListaJuegos nuevo = new NodoListaJuegos(pjugador, poponente, punides, punisob, punidest, pgano);
            if (this.primero == null)
            {
                this.primero = nuevo;
                this.ultimo = nuevo;
            }
            else
            {
                this.ultimo.SetSiguiente(nuevo);
                nuevo.SetAnterior(ultimo);
                this.ultimo = nuevo;
            }
        }

        public string DevolverLista()
        {
            string dev = "";
            NodoListaJuegos aux = this.primero;
            while (aux != null)
            {
                dev += aux.GetJugador() + "-" + aux.GetOponente() + "-" + aux.GetUnidadesDesplegadas().ToString() + "-" + aux.GetUnidadesSobrevivientes().ToString() + "-" + aux.GetUnidadesDestruidas().ToString() + "\n";
                aux = aux.GetSiguiente();
            }
            return dev;
        }

        public string DevolverDatos(string jugador1, string jugador2, int unidadesdes, int unidadessob, int unidadesdest)
        {
            NodoListaJuegos aux = this.primero;
            string dev = "";
            while (aux != null)
            {
                if (aux.GetJugador().CompareTo(jugador1) == 0 && aux.GetOponente().CompareTo(jugador2) == 0 && aux.GetUnidadesDesplegadas() == unidadesdes && aux.GetUnidadesSobrevivientes() == unidadessob && aux.GetUnidadesDestruidas() == unidadesdest)
                {
                    dev = aux.GetJugador() + "," + aux.GetOponente() + "," + aux.GetUnidadesDesplegadas().ToString() + "," + aux.GetUnidadesSobrevivientes().ToString() + "," + aux.GetUnidadesDestruidas().ToString() + "," + aux.GetGano().ToString();
                }
                aux = aux.GetSiguiente();
            }
            return dev;
        }

        public void EliminarJuego(string jugador1, string jugador2, int navesdes, int navessob, int navesdest)
        {
            NodoListaJuegos aux = this.primero;
            if (this.primero != this.ultimo)
            {
                while (aux.GetSiguiente() != null)
                {
                    if (aux.GetJugador().CompareTo(jugador1) == 0 && aux.GetOponente().CompareTo(jugador2) == 0 && aux.GetUnidadesDesplegadas() == navesdes && aux.GetUnidadesSobrevivientes() == navessob && aux.GetUnidadesDestruidas() == navesdest)
                    {
                        if (aux == this.primero)
                        {
                            this.primero = aux.GetSiguiente();
                            this.primero.SetAnterior(null);
                            aux.SetSiguiente(null);
                            aux = null;
                        }
                        else if (aux == this.ultimo)
                        {
                            this.ultimo = aux.GetAnterior();
                            this.ultimo.SetSiguiente(null);
                            aux.SetAnterior(null);
                            aux = null;
                        }
                        else
                        {
                            aux.GetAnterior().SetSiguiente(aux.GetSiguiente());
                            aux.GetSiguiente().SetAnterior(aux.GetAnterior());
                            aux.SetSiguiente(null);
                            aux.SetAnterior(null);
                            aux = null;
                        }
                    }
                }
            }
            else
            {
                this.primero = null;
                this.ultimo = null;
            }
        }

        public void ModificarDatosJuego(string jugador1, string oponenteantiguo, string oponentenuevo, int unidadesdesant, int unidadesdesnue, int unidadessobant, int unidadessobnue, int unidadesdestant, int unidadesdestnue)
        {
            NodoListaJuegos aux = this.primero;
            while (aux != null)
            {
                if (aux.GetJugador().CompareTo(jugador1) == 0 && aux.GetOponente().CompareTo(oponenteantiguo) == 0 && aux.GetUnidadesDesplegadas() == unidadesdesant && aux.GetUnidadesSobrevivientes() == unidadessobant && aux.GetUnidadesDestruidas() == unidadesdestant)
                {
                    aux.SetOponente(oponentenuevo);
                    aux.SetUnidadesDesplegadas(unidadesdesnue);
                    aux.SetUnidadesSobrevivientes(unidadessobnue);
                    aux.SetUnidadesDestruidas(unidadesdestnue);
                    break;
                }
                aux = aux.GetSiguiente();
            }
        }

        public int DevolverJuegosGanados(NodoArbol aux)
        {
            NodoListaJuegos auxiliar = aux.GetListaJuegos().GetPrimero();
            int cont = 0;
            while (auxiliar != null)
            {
                if (auxiliar.GetGano())
                {
                    cont++;
                }
                auxiliar = auxiliar.GetSiguiente();
            }
            return cont;
        }

        public double DevolverPorcentajeUnidadesDest(NodoArbol aux)
        {
            NodoListaJuegos auxiliar = aux.GetListaJuegos().GetPrimero();
            double n = 0;
            double n1 = 0;//dest
            while (auxiliar != null)
            {
                if (auxiliar.GetGano())
                {
                    n += auxiliar.GetUnidadesDesplegadas();
                    n1 += auxiliar.GetUnidadesDestruidas();
                }
                auxiliar = auxiliar.GetSiguiente();
            }
            return ((n1*100)/n);
        }

        public int DevolverNumerodeunidadesdest(NodoArbol aux)
        {
            NodoListaJuegos auxiliar = aux.GetListaJuegos().GetPrimero();
            int n = 0;
            while (auxiliar != null)
            {
                if (auxiliar.GetGano())
                {
                    n += auxiliar.GetUnidadesDestruidas();
                }
                auxiliar = auxiliar.GetSiguiente();
            }
            return n;
        }
    }
}