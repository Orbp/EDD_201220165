using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto
{
    public class Eliminados
    {
        public NodoEliminados primero;

        public Eliminados()
        {
            this.primero = null;
        }

        public void Insertar(string usuario, int num)
        {
            if (primero == null)
            {
                primero = new NodoEliminados(usuario, num);
            }
            else
            {
                NodoEliminados nuevo = new NodoEliminados(usuario, num);
                if (nuevo.unidades > primero.unidades)
                {
                    nuevo.siguiente = primero;
                    primero = nuevo;
                }
                else
                {
                    NodoEliminados aux = primero;
                    while (aux.siguiente != null)
                    {
                        if (aux.unidades < nuevo.unidades && aux.siguiente.unidades > nuevo.unidades || nuevo.unidades == aux.unidades)
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