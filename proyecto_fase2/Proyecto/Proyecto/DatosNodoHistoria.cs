using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto
{
    public class DatosNodoHistoria
    {
        private string coordenadax;
        private string coordenaday;
        private string unidadatacante;
        private string resultado;
        private string tipodeunidaddan;
        private string emisor;
        private string receptor;
        private DateTime fecha;
        private int tiempo;
        private int numerodeataque;


        public string GetCoordenadaX()
        {
            return this.coordenadax;
        }

        public void SetCoordenadaX(string aux)
        {
            this.coordenadax = aux;
        }

        public string GetCoordenadaY()
        {
            return this.coordenaday;
        }

        public void SetCoordenadaY(string aux)
        {
            this.coordenaday = aux;
        }

        public string GetUnidadatacante()
        {
            return this.unidadatacante;
        }

        public void SetUnidadatacante(string aux)
        {
            this.unidadatacante = aux;
        }

        public string GetResultado()
        {
            return this.resultado;
        }

        public void SetResultado(string aux)
        {
            this.resultado = aux;
        }

        public string GetTipoUnidadesDan()
        {
            return this.tipodeunidaddan;
        }

        public void SetTipoUnidadesDan(string aux)
        {
            this.tipodeunidaddan = aux;
        }

        public string GetEmisor()
        {
            return this.emisor;
        }

        public void SetEmisor(string aux)
        {
            this.emisor = aux;
        }

        public string GetReceptor()
        {
            return this.receptor;
        }

        public void SetReceptor(string aux)
        {
            this.receptor = aux;
        }

        public DateTime GetFecha()
        {
            return this.fecha;
        }

        public void SetFecha(DateTime aux)
        {
            this.fecha = aux;
        }

        public int GetTiempo()
        {
            return this.tiempo;
        }

        public void SetTiempo(int aux)
        {
            this.tiempo = aux;
        }

        public int GetNumerodeataque()
        {
            return this.numerodeataque;
        }

        public void SetNumerodeataque(int aux)
        {
            this.numerodeataque = aux;
        }
    }
}