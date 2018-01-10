using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto
{
    public class NodoListaHistorial
    {
        public string nombre;
        public ArbolHistorial contenido;
        public NodoListaHistorial siguiente;

        public NodoListaHistorial(string pnombre, ArbolHistorial pcontenido)
        {
            this.nombre = pnombre;
            this.contenido = pcontenido;
            this.siguiente = null;
        }
    }
}