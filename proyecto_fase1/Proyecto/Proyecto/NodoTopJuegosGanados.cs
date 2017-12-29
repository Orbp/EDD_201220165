using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto
{
    public class NodoTopJuegosGanados
    {
        private string idjugador;
        private int numero;
        NodoTopJuegosGanados siguiente;

        public NodoTopJuegosGanados(string id, int n)
        {
            this.idjugador = id;
            this.numero = n;
            this.siguiente = null;
        }

        public string GetIdJugador()
        {
            return this.idjugador;
        }

        public int GetNumero()
        {
            return this.numero;
        }

        public void SetSiguiente(NodoTopJuegosGanados aux)
        {
            this.siguiente = aux;
        }

        public NodoTopJuegosGanados GetSiguiente()
        {
            return this.siguiente;
        }
    }
}