using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto
{
    public class ListaHistorial
    {
        public NodoListaHistorial primero;
        public NodoListaHistorial ultimo;

        public ListaHistorial()
        {
            this.primero = null;
            this.ultimo = null;
        }

        public void Insertar(ArbolHistorial arbol, string nombre)
        {
            if (primero == null)
            {
                primero = new NodoListaHistorial(nombre, arbol);
                ultimo = primero;
            }
            else
            {
                NodoListaHistorial nuevo = new NodoListaHistorial(nombre, arbol);
                if (arbol.numerodetirosfinal > primero.contenido.numerodetirosfinal)
                {
                    nuevo.siguiente = primero;
                    primero = nuevo;
                }
                else
                {
                    NodoListaHistorial aux = this.primero;
                    while (aux.siguiente != null)
                    {
                        if (aux.contenido.numerodetirosfinal < nuevo.contenido.numerodetirosfinal && aux.siguiente.contenido.numerodetirosfinal > nuevo.contenido.numerodetirosfinal || nuevo.contenido.numerodetirosfinal == aux.contenido.numerodetirosfinal)
                        {
                            break;
                        }
                        aux = aux.siguiente;
                    }
                    if (aux.siguiente == null)
                    {
                        ultimo.siguiente = nuevo;
                        ultimo = nuevo;
                    }
                    else
                    {
                        nuevo.siguiente = aux.siguiente;
                        aux.siguiente = nuevo;
                    }
                }
            }
        }
    }
}