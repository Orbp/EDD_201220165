using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto
{
    public class ListaTopUnidadesDestruidas
    {
        private NodoTopUnidadesDestruidas primero;

        public NodoTopUnidadesDestruidas GetPrimero()
        {
            return this.primero;
        }

        public ListaTopUnidadesDestruidas()
        {
            this.primero = null;
        }

        public void InsertarTopUnidades(string id, double numero)
        {
            if (!Existe(id, numero))
            {
                NodoTopUnidadesDestruidas nuevo = new NodoTopUnidadesDestruidas(id, numero);
                if (this.primero == null)
                {
                    this.primero = nuevo;
                }
                else
                {
                    if (nuevo.GetPorcentaje() > this.primero.GetPorcentaje())
                    {
                        nuevo.SetSiguiente(this.primero);
                        this.primero = nuevo;
                    }
                    else
                    {
                        NodoTopUnidadesDestruidas aux = this.primero;
                        while (aux.GetSiguiente() != null)
                        {
                            if (aux.GetPorcentaje() > nuevo.GetPorcentaje() && nuevo.GetPorcentaje() > aux.GetSiguiente().GetPorcentaje() || aux.GetPorcentaje() == nuevo.GetPorcentaje())
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

        public bool Existe(string id, double n)
        {
            NodoTopUnidadesDestruidas aux = this.primero;
            while (aux != null)
            {
                if (aux.GetId() == id)
                {
                    double num = aux.GetPorcentaje() + n;
                    aux.SetPorcentaje(num);
                    return true;
                }
                aux = aux.GetSiguiente();
            }
            return false;
        }
    }
}