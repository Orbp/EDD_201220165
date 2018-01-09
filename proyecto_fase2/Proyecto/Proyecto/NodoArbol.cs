using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto
{
    public class NodoArbol
    {
        private string nickname;
        private string password;
        private string correo;
        private bool conectado;
        private ListaJuegos juegos;
        private ArbolContactos contactos;
        public NodoArbol hijoderecho;
        public NodoArbol hijoizquierdo;


        public NodoArbol(string pnickname, string ppassword, string pcorreo, bool pconectado)
        {
            this.nickname = pnickname;
            this.password = ppassword;
            this.correo = pcorreo;
            this.conectado = pconectado;
            this.juegos = new ListaJuegos();
            this.contactos = new ArbolContactos();
            this.hijoderecho = null;
            this.hijoizquierdo = null;
        }

        public string GetNickname()
        {
            return this.nickname;
        }

        public string GetPassword()
        {
            return this.password;
        }

        public void SetPassword(string pass)
        {
            this.password = pass;
        }

        public string GetCorreo()
        {
            return this.correo;
        }

        public ArbolContactos GetContactos()
        {
            return this.contactos;
        }

        public void SetCorreo(string pcorreo)
        {
            this.correo = pcorreo;
        }

        public bool GetConectado()
        {
            return this.conectado;
        }

        public void SetConectado(bool pconectado)
        {
            this.conectado = pconectado;
        }

        public void SetHijoDerecho(NodoArbol aux)
        {
            this.hijoderecho = aux;
        }

        public NodoArbol GetHijoDerecho()
        {
            return this.hijoderecho;
        }

        public void SetHijoIzquierdo(NodoArbol aux)
        {
            this.hijoizquierdo = aux;
        }

        public NodoArbol GetHijoIzquierdo()
        {
            return this.hijoizquierdo;
        }

        public ListaJuegos GetListaJuegos()
        {
            return this.juegos;
        }
    }
}