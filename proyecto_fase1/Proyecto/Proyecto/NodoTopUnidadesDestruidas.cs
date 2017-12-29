using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto
{
    public class NodoTopUnidadesDestruidas
    {
        private string id;
        private double porcentaje;
        private NodoTopUnidadesDestruidas siguiente;

        public NodoTopUnidadesDestruidas(string id, double porcentaje)
        {
            this.id = id;
            this.porcentaje = porcentaje;
            this.siguiente = null;
        }
        public string GetId()
        {
            return this.id;
        }

        public double GetPorcentaje()
        {
            return this.porcentaje;
        }

        public void SetPorcentaje(double n)
        {
            this.porcentaje = n;
        }
        public NodoTopUnidadesDestruidas GetSiguiente()
        {
            return this.siguiente;
        }

        public void SetSiguiente(NodoTopUnidadesDestruidas aux)
        {
            this.siguiente = aux;
        }
    }
}