using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto
{
    public class TopContactos
    {
        public NodoTopContactos inicio;

        public TopContactos()
        {
            inicio = null;
        }

        public void Insertar(string usuario, int numero)
        {
            if (inicio == null)
            {
                inicio = new NodoTopContactos(usuario, numero);
            }
            else
            {
                NodoTopContactos nuevo = new NodoTopContactos(usuario, numero);
                if (nuevo.numero > inicio.numero)
                {
                    nuevo.siguiente = inicio;
                    inicio = nuevo;
                }
                else
                {
                    NodoTopContactos aux = inicio;
                    while (aux.siguiente != null)
                    {
                        if (aux.numero < nuevo.numero && aux.siguiente.numero > nuevo.numero || nuevo.numero == aux.numero)
                        {
                            break;
                        }
                        aux = aux.siguiente;
                    }
                    if (aux.siguiente == null)
                    {
                        aux.siguiente = nuevo;
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