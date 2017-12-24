using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea3
{
    class Arbolbinario
    {
        private NodoArbolBinario raiz;

        public NodoArbolBinario GetRaiz()
        {
            return this.raiz;
        }

        public void SetRaiz(NodoArbolBinario aux)
        {
            this.raiz = aux;
        }

        public void Insertar(NodoArbolBinario raiz, char pcontenido)
        {
            if (raiz.GetContenido() > pcontenido)
            {
                if (raiz.GetHijoIzquierdo() == null)
                {
                    raiz.SetHijoIzquierdo(new NodoArbolBinario(pcontenido));
                }
                else
                {
                    Insertar(raiz.GetHijoIzquierdo(), pcontenido);
                }
            }
            if (raiz.GetContenido() < pcontenido)
            {
                if (raiz.GetHijoDerecho() == null)
                {
                    raiz.SetHijoDerecho(new NodoArbolBinario(pcontenido));
                }
                else
                {
                    Insertar(raiz.GetHijoDerecho(), pcontenido);
                }
            }
        }

        public void RecorridoPreOrden(NodoArbolBinario raiz)
        {
            if (raiz != null)
            {
                Console.WriteLine(raiz.GetContenido());
            }

            if (raiz.GetHijoIzquierdo() != null)
            {
                RecorridoPreOrden(raiz.GetHijoIzquierdo());
            }

            if (raiz.GetHijoDerecho() != null)
            {
                RecorridoPreOrden(raiz.GetHijoDerecho());
            }
        }

        public void RecorridoInOrden(NodoArbolBinario raiz)
        {
            if (raiz.GetHijoIzquierdo() != null)
            {
                RecorridoInOrden(raiz.GetHijoIzquierdo());
            }
            if (raiz != null)
            {
                Console.WriteLine(raiz.GetContenido());
            }
            if (raiz.GetHijoDerecho() != null)
            {
                RecorridoInOrden(raiz.GetHijoDerecho());
            }
        }

        public void RecorridoPostOrden(NodoArbolBinario raiz)
        {
            if (raiz.GetHijoIzquierdo() != null)
            {
                RecorridoPostOrden(raiz.GetHijoIzquierdo());
            }
            if (raiz.GetHijoDerecho() != null)
            {
                RecorridoPostOrden(raiz.GetHijoDerecho());
            }
            if (raiz != null)
            {
                Console.WriteLine(raiz.GetContenido());
            }
        }
    }
}
