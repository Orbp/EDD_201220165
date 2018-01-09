using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto
{
    public class EncabezadoFila
    {
        NodoEncabezado primero;

        public EncabezadoFila()
        {
            this.primero = null;
        }

        public NodoEncabezado GetPrimero()
        {
            return this.primero;
        }

        public void InsertarEncabezadoFila(int id, NodoMatriz pcont)
        {
            NodoEncabezado nuevo = new NodoEncabezado(id, pcont);
            if (this.primero == null)
            {
                this.primero = nuevo;
            }
            else
            {
                if (this.primero.Get_Id() > id)
                {
                    nuevo.siguiente = this.primero;
                    this.primero = nuevo;
                }
                else
                {
                    NodoEncabezado auxiliar = this.primero;
                    while (auxiliar.siguiente != null)
                    {
                        if (auxiliar.Get_Id() < id && auxiliar.siguiente.Get_Id() > id)
                        {
                            break;
                        }
                        auxiliar = auxiliar.siguiente;
                    }
                    if (auxiliar.siguiente == null)
                    {
                        auxiliar.siguiente = nuevo;
                    }
                    else
                    {
                        nuevo.siguiente = auxiliar.siguiente;
                        auxiliar.siguiente = nuevo;
                    }
                }
            }
        }

        public void EliminarEncabezadoFila(int id)
        {
            if (this.primero != null)
            {
                NodoEncabezado auxiliar = this.primero;
                NodoEncabezado anterior = null;
                while (auxiliar != null)
                {
                    
                    if (auxiliar.Get_Id() == id)
                    {
                        break;
                    }
                    anterior = auxiliar;
                    auxiliar = auxiliar.siguiente;

                }
                if (anterior == null)
                {
                    if (auxiliar.siguiente != null)
                    {
                        NodoEncabezado aux = auxiliar.siguiente;
                        auxiliar.siguiente = null;
                        this.primero = aux;
                    }
                    else
                    {
                        this.primero = null;
                    }
                }
                else
                {
                    if (auxiliar.siguiente != null)
                    {
                        anterior.siguiente = auxiliar.siguiente;
                        auxiliar.siguiente = null;
                    }
                    else
                    {
                        anterior.siguiente = null;                       
                    }
                }
                auxiliar = null;
            }
        }

        public NodoEncabezado ExisteFila(int id)
        {
            if (this.primero != null)
            {
                NodoEncabezado auxiliar = this.primero;
                while (auxiliar != null)
                {
                    if (auxiliar.Get_Id() == id)
                    {
                        return auxiliar;
                    }
                    auxiliar = auxiliar.siguiente;
                }
            }
            return null;
        }
    }
}