using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto
{
    public class ListaTopJuegosGanados
    {
        private NodoTopJuegosGanados primero;

        public NodoTopJuegosGanados GetPrimero()
        {
            return this.primero;
        }

        public void InsertarListaJuegosGanados(string usuario, int numero)
        {
            NodoTopJuegosGanados nuevo = new NodoTopJuegosGanados(usuario, numero);
            if (this.primero == null)
            {
                this.primero = nuevo;
            }
            else
            {
                if (nuevo.GetNumero() > this.primero.GetNumero())
                {
                    nuevo.SetSiguiente(this.primero);
                    this.primero = nuevo;
                }
                else
                {
                    NodoTopJuegosGanados aux = this.primero;
                    while (aux.GetSiguiente() != null)
                    {
                        if (aux.GetNumero() > nuevo.GetNumero() && nuevo.GetNumero() > aux.GetSiguiente().GetNumero() || aux.GetNumero() == nuevo.GetNumero())
                        {
                            break;
                        }
                        aux = aux.GetSiguiente();
                    }
                    if (aux.GetSiguiente() == null)
                    {
                        aux.SetSiguiente(nuevo);
                    }
                    else
                    {
                        nuevo.SetSiguiente(aux.GetSiguiente());
                        aux.SetSiguiente(nuevo);
                    }
                }
            }
        }
    }
}