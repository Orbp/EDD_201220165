using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto
{
    public class NodoTopContactos
    {
        public string usuarios;
        public int numero;
        public NodoTopContactos siguiente;

        public NodoTopContactos(string usuarios, int numero)
        {
            this.usuarios = usuarios;
            this.numero = numero;
            this.siguiente = null;
        }
    }
}