using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto
{
    public class NodoListaJuegos
    {
        private string jugador;
        private string oponente;
        private int unidadesdesplegadas;
        private int unidadessobrevivientes;
        private int unidadesdestruidas;
        private bool gano;
        private NodoListaJuegos siguiente;
        private NodoListaJuegos anterior;

        public NodoListaJuegos(string pjugador, string poponente, int punides, int punisobr, int punidest, bool pgano)
        {
            this.jugador = pjugador;
            this.oponente = poponente;
            this.unidadesdesplegadas = punides;
            this.unidadessobrevivientes = punisobr;
            this.unidadesdestruidas = punidest;
            this.gano = pgano;
            this.siguiente = null;
            this.anterior = null;
        }

        public void SetJugador(string pjugador)
        {
            this.jugador = pjugador;
        }
        public string GetJugador()
        {
            return this.jugador;
        }
        public void SetOponente(string poponente)
        {
            this.oponente = poponente;
        }
        public string GetOponente()
        {
            return this.oponente;
        }
        public void SetUnidadesDesplegadas(int punides)
        {
            this.unidadesdesplegadas = punides;
        }
        public int GetUnidadesDesplegadas()
        {
            return this.unidadesdesplegadas;
        }
        public void SetUnidadesSobrevivientes(int punisob)
        {
            this.unidadessobrevivientes = punisob;
        }
        public int GetUnidadesSobrevivientes()
        {
            return this.unidadessobrevivientes;
        }
        public void SetUnidadesDestruidas(int punides)
        {
            this.unidadesdestruidas = punides;
        }
        public int GetUnidadesDestruidas()
        {
            return this.unidadesdestruidas;
        }
        public void SetGano(bool pgano)
        {
            this.gano = pgano;
        }
        public bool GetGano()
        {
            return this.gano;
        }
        public void SetSiguiente(NodoListaJuegos aux)
        {
            this.siguiente = aux;
        }
        public NodoListaJuegos GetSiguiente()
        {
            return this.siguiente;
        }
        public void SetAnterior(NodoListaJuegos aux)
        {
            this.anterior = aux;
        }
        public NodoListaJuegos GetAnterior()
        {
            return this.anterior;
        }
    }
}