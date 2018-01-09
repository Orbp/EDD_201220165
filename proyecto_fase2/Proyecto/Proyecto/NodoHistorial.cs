using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto
{
    public class NodoHistorial
    {
        public NodoHistorial[] Ramas;
        public DatosNodoHistoria[] Datos;
        public int clavesusadas;
        public NodoHistorial Padre;

        public NodoHistorial(int indice)
        {
            Ramas = new NodoHistorial[indice + 2];
            Datos = new DatosNodoHistoria[indice + 1];
            this.clavesusadas = 0;
            this.Padre = null;
        }

        public NodoHistorial[] GetRamas()
        {
            return this.Ramas;
        }

        public NodoHistorial GetRamaat(int index)
        {
            return this.Ramas[index];
        }

        public void SetRamaat(int index, NodoHistorial aux)
        {
            this.Ramas[index] = aux;
        }

        public DatosNodoHistoria[] GetDatos()
        {
            return this.Datos;
        }

        public DatosNodoHistoria GetDatosat(int index)
        {
            return this.Datos[index];
        }

        public void SetDatosat(int index, DatosNodoHistoria aux)
        {
            this.Datos[index] = aux;
        }

        public int GetClavesUsadas()
        {
            return this.clavesusadas;
        }

        public void SetClavesUsadas(int aux)
        {
            this.clavesusadas = aux;
        }

        public NodoHistorial GetPadre()
        {
            return this.Padre;
        }

        public void SetPadre(NodoHistorial aux)
        {
            this.Padre = aux;
        }
    }
}