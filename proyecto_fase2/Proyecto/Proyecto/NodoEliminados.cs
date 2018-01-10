using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto
{
    public class NodoEliminados
    {
        public string usuario;
        public int unidades;
        public NodoEliminados siguiente;

        public NodoEliminados(string usuario, int unidades)
        {
            this.usuario = usuario;
            this.unidades = unidades;
            this.siguiente = null;
        }

    }
}