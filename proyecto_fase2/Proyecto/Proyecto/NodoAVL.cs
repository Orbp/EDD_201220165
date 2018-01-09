using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto
{
    public class NodoAVL
    {
        private string usuario;
        private string password;
        private string correo;
        private int fe;
        private NodoAVL hijoderecho;
        private NodoAVL hijoizquierdo;
        private NodoAVL padre;

        public NodoAVL(string pusuario, string ppasword, string pcorreo)
        {
            this.usuario = pusuario;
            this.password = ppasword;
            this.correo = pcorreo;
            this.fe = 0;
            this.hijoderecho = null;
            this.hijoizquierdo = null;
        }

        public NodoAVL(NodoArbol aux)
        {
            this.usuario = aux.GetNickname();
            this.password = aux.GetPassword();
            this.correo = aux.GetCorreo();
            this.fe = 0;
            this.hijoderecho = null;
            this.hijoizquierdo = null;
        }

        public void SetHijoIzquierdo(NodoAVL aux)
        {
            this.hijoizquierdo = aux;
        }

        public void SetHijoDerecho(NodoAVL aux)
        {
            this.hijoderecho = aux;
        }

        public void SetPadre(NodoAVL aux)
        {
            this.padre = aux;
        }

        public void SetFe(int auxfe)
        {
            this.fe = auxfe;
        }
        public string GetUsuario()
        {
            return this.usuario;
        }

        public string GetPassword()
        {
            return this.password;
        }

        public string GetCorreo()
        {
            return this.correo;
        }

        public int GetFe()
        {
            return this.fe;
        }

        public NodoAVL GetHijoIzquierdo()
        {
            return this.hijoizquierdo;
        }

        public NodoAVL GetHijoDerecho()
        {
            return this.hijoderecho;
        }

        public NodoAVL GetPadre()
        {
            return this.padre;
        }
    }
}