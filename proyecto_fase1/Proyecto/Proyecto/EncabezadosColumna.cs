using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto
{
    public class EncabezadosColumna
    {
        NodoEncabezado primero;

        public EncabezadosColumna()
        {
            this.primero = null;
        }

        public NodoEncabezado GetPrimero()
        {
            return this.primero;
        }

        public void InsertarEncabezadoColumna(char id, NodoMatriz cont)
        {
            NodoEncabezado nuevo = new NodoEncabezado(id, cont);
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

        public NodoEncabezado ExisteEncabezadoColuma(char id)
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