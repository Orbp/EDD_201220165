using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto
{
    public class NodoEncabezado
    {
        private int id;
        public NodoEncabezado siguiente;
        public NodoMatriz cont;
        public NodoEncabezado arriba;
        public NodoEncabezado abajo;

        public NodoEncabezado(int pid, NodoMatriz pcont)
        {
            this.id = pid;
            this.cont = pcont;
            this.siguiente = null;
        }

        public int Get_Id()
        {
            return this.id;
        }
    }
}