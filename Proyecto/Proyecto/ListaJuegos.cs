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
    }
}