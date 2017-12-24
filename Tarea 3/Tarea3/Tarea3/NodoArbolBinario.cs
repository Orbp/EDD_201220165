using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea3
{
    class NodoArbolBinario
    {
        private NodoArbolBinario hijoizquierdo;
        private NodoArbolBinario hijoderecho;
        private char contenido;

        public NodoArbolBinario(char contenido)
        {
            this.contenido = contenido;
            this.hijoderecho = null;
            this.hijoizquierdo = null;
        }

        public NodoArbolBinario GetHijoIzquierdo()
        {
            return this.hijoizquierdo;
        }

        public NodoArbolBinario GetHijoDerecho()
        {
            return this.hijoderecho;
        }

        public char GetContenido()
        {
            return this.contenido;
        }

        public void SetHijoIzquierdo(NodoArbolBinario auxhijoizq)
        {
            this.hijoizquierdo = auxhijoizq;
        }

        public void SetHijoDerecho(NodoArbolBinario auxhijoder)
        {
            this.hijoderecho = auxhijoder;
        }
    }
}
