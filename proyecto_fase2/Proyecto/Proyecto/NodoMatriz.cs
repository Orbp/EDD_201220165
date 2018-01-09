using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto
{
    public class NodoMatriz
    {
        public int movimiento;
        public int alcance;
        public int ataque;
        public int vidad;
        public string idunidad;
        public string idjugador;
        public int fila;
        public char columna;
        public bool mover;
        public bool atacar;
        public NodoMatriz siguiente;//siguiente columna
        public NodoMatriz anterior;//anterior columna
        public NodoMatriz arriba;//anterior fila
        public NodoMatriz abajo;//siguiente fila
        public NodoMatriz subir;//siguiente nivel
        public NodoMatriz bajar;//nivel anterior

        public NodoMatriz(int movimiento, int alcance, int ataque,int vida, string idunidad, string idjugador, int fila, char columna)
        {
            this.movimiento = movimiento;
            this.alcance = alcance;
            this.ataque = ataque;
            this.vidad = vida;
            this.idunidad = idunidad;
            this.idjugador = idjugador;
            this.fila = fila;
            this.columna = columna;
            this.mover = false;
            this.atacar = false;
            this.siguiente = null;
            this.anterior = null;
            this.arriba = null;
            this.abajo = null;
            this.subir = null;
            this.bajar = null;
        }
    }
}