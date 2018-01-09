using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto
{
    public class ArbolContactos
    {
        private NodoAVL raiz;

        public NodoAVL GetRaiz()
        {
            return this.raiz;
        }

        public ArbolContactos()
        {
            this.raiz = null;
        }

        public void SetRaiz(NodoAVL AUX)
        {
            this.raiz = AUX;
        }

        public void Insertar(string usuario, string password, string correo)
        {
            NodoAVL nuevo = new NodoAVL(usuario, password, correo);
            NodoAVL padrenuevo = null;
            NodoAVL actual = this.GetRaiz();
            if (GetRaiz() == null)
            {
                this.raiz = nuevo;
            }
            else
            {
                if (!ExisteContacto(usuario))
                {
                    while (actual != null)
                    {
                        padrenuevo = actual;
                        if (actual.GetUsuario().CompareTo(usuario) > 0)
                        {
                            actual = actual.GetHijoIzquierdo();
                        }
                        else
                        {
                            actual = actual.GetHijoDerecho();
                        }
                    }
                    if (padrenuevo.GetUsuario().CompareTo(usuario) > 0)
                    {
                        padrenuevo.SetHijoIzquierdo(nuevo);
                        nuevo.SetPadre(padrenuevo);
                        EquilibrarArbol(padrenuevo, "izquierda", true);
                    }
                    else
                    {
                        padrenuevo.SetHijoDerecho(nuevo);
                        nuevo.SetPadre(padrenuevo);
                        EquilibrarArbol(padrenuevo, "derecha", true);
                    }
                }
            }
        }

        public void Insertar(NodoArbol aux)
        {
            string usuario = aux.GetNickname();
            string password = aux.GetPassword();
            string correo = aux.GetCorreo();
            NodoAVL nuevo = new NodoAVL(usuario, password, correo);
            NodoAVL padrenuevo = null;
            NodoAVL actual = this.GetRaiz();
            if (GetRaiz() == null)
            {
                this.raiz = nuevo;
            }
            else
            {
                if (!ExisteContacto(usuario))
                {
                    while (actual != null)
                    {
                        padrenuevo = actual;
                        if (actual.GetUsuario().CompareTo(usuario) > 0)
                        {
                            actual = actual.GetHijoIzquierdo();
                        }
                        else
                        {
                            actual = actual.GetHijoDerecho();
                        }
                    }
                    if (padrenuevo.GetUsuario().CompareTo(usuario) > 0)
                    {
                        padrenuevo.SetHijoIzquierdo(nuevo);
                        nuevo.SetPadre(padrenuevo);
                        EquilibrarArbol(padrenuevo, "izquierda", true);
                    }
                    else
                    {
                        padrenuevo.SetHijoDerecho(nuevo);
                        nuevo.SetPadre(padrenuevo);
                        EquilibrarArbol(padrenuevo, "derecha", true);
                    }
                }
            }
        }

        private void EquilibrarArbol(NodoAVL nodo, string lado, bool nuevo)
        {
            bool salir = false;
            while (nodo != null && !salir)
            {
                if (nuevo)
                {
                    if (lado == "izquierda")
                    {
                        int auxfe = nodo.GetFe();
                        auxfe -= 1;
                        nodo.SetFe(auxfe);
                    }
                    else
                    {
                        int auxfe = nodo.GetFe();
                        auxfe += 1;
                        nodo.SetFe(auxfe);
                    }
                }
                else
                {
                    if (lado == "izquierda")
                    {
                        int auxfe = nodo.GetFe();
                        auxfe += 1;
                        nodo.SetFe(auxfe);
                    }
                    else
                    {
                        int auxfe = nodo.GetFe();
                        auxfe -= 1;
                        nodo.SetFe(auxfe);
                    }
                }
                if (nodo.GetFe() == 0)
                {
                    salir = true;
                }
                else if (nodo.GetFe() == -2)
                {
                    if (nodo.GetHijoIzquierdo().GetFe() == 1)
                    {
                        RotacionDoble(nodo, nodo.GetPadre(), "derecha");
                    }
                    else
                    {
                        RotacionSimple(nodo, nodo.GetPadre(), "derecha");
                    }
                    salir = true;
                }
                else if (nodo.GetFe() == 2)
                {
                    if (nodo.GetHijoDerecho().GetFe() == -1)
                    {
                        RotacionDoble(nodo, nodo.GetPadre(), "izquierda");
                    }
                    else
                    {
                        RotacionSimple(nodo, nodo.GetPadre(), "izquierda");
                    }
                    salir = true;
                }
                if (nodo.GetPadre() != null)
                {
                    if (nodo.GetPadre().GetHijoDerecho() == nodo)
                    {
                        lado = "derecha";
                    }
                    else
                    {
                        lado = "izquierda";
                    }
                }
                nodo = nodo.GetPadre();
            }
        }

        private void RotacionDoble(NodoAVL nodo, NodoAVL padre, string tipo)
        {
            if (tipo == "derecha")
            {
                NodoAVL hijoizq = nodo.GetHijoIzquierdo();
                NodoAVL hijoizqder = hijoizq.GetHijoDerecho();
                NodoAVL hijoizqderizq = hijoizqder.GetHijoIzquierdo();
                NodoAVL hijoizqderder = hijoizqder.GetHijoDerecho();
                if (padre != null)
                {
                    if (padre.GetHijoDerecho() == nodo)
                    {
                        padre.SetHijoDerecho(hijoizqder);
                    }
                    else
                    {
                        padre.SetHijoIzquierdo(hijoizqder);
                    }
                }
                else
                {
                    this.raiz = hijoizqder;
                }
                hijoizq.SetHijoDerecho(hijoizqderizq);
                nodo.SetHijoIzquierdo(hijoizqderder);
                hijoizqder.SetHijoIzquierdo(hijoizq);
                hijoizqder.SetHijoDerecho(nodo);
                hijoizqder.SetPadre(padre);
                nodo.SetPadre(hijoizqder);
                hijoizq.SetPadre(hijoizqder);
                if (hijoizqderizq != null)
                {
                    hijoizqderizq.SetPadre(hijoizq);
                }
                if (hijoizqderder != null)
                {
                    hijoizqderder.SetPadre(nodo);
                }

                if (hijoizqder.GetFe() == -1)
                {
                    hijoizq.SetFe(0);
                    nodo.SetFe(1);
                }
                else if (hijoizqder.GetFe() == 0)
                {
                    hijoizq.SetFe(0);
                    nodo.SetFe(0);
                }
                else
                {
                    hijoizq.SetFe(-1);
                    nodo.SetFe(0);
                }
                hijoizqder.SetFe(0);
            }
            else
            {
                NodoAVL hijoder = nodo.GetHijoDerecho();
                NodoAVL hijoderizq = hijoder.GetHijoIzquierdo();
                NodoAVL hijoderizqizq = hijoderizq.GetHijoIzquierdo();
                NodoAVL hijodereizqder = hijoderizq.GetHijoDerecho();

                if (padre != null)
                {
                    if (padre.GetHijoDerecho() == nodo)
                    {
                        padre.SetHijoDerecho(hijoderizq);
                    }
                    else
                    {
                        padre.SetHijoIzquierdo(hijoderizq);
                    }
                }
                else
                {
                    this.raiz = hijoderizq;
                }
                nodo.SetHijoDerecho(hijoderizqizq);
                hijoderizqizq.SetHijoIzquierdo(hijodereizqder);
                hijoderizq.SetHijoIzquierdo(nodo);
                hijoderizq.SetHijoDerecho(hijoder);
                hijoderizq.SetPadre(padre);
                nodo.SetPadre(hijoderizq);
                hijoder.SetPadre(hijoderizq);
                if (hijoderizqizq != null)
                {
                    hijoderizqizq.SetPadre(nodo);
                }
                if (hijodereizqder != null)
                {
                    hijodereizqder.SetPadre(hijoder);
                }

                if (hijoderizq.GetFe() == -1)
                {
                    nodo.SetFe(0);
                    hijoder.SetFe(1);
                }
                else if (hijoderizq.GetFe() == 0)
                {
                    nodo.SetFe(0);
                    hijoder.SetFe(0);
                }
                else
                {
                    nodo.SetFe(-1);
                    hijoder.SetFe(0);
                }
                hijoderizq.SetFe(0);
            }
        }

        private void RotacionSimple(NodoAVL nodo, NodoAVL padre, string tipo)
        {
            if (tipo == "derecha")
            {
                NodoAVL hijoizq = nodo.GetHijoIzquierdo();
                NodoAVL hijoizqder = hijoizq.GetHijoDerecho();
                if (padre != null)
                {
                    if (padre.GetHijoDerecho() == nodo)
                    {
                        padre.SetHijoDerecho(hijoizq);
                    }
                    else
                    {
                        padre.SetHijoIzquierdo(hijoizq);
                    }
                }
                else
                {
                    this.raiz = hijoizq;
                }
                nodo.SetHijoIzquierdo(hijoizqder);
                hijoizq.SetHijoDerecho(nodo);
                nodo.SetPadre(hijoizq);
                if (hijoizqder != null)
                {
                    hijoizqder.SetPadre(nodo);
                }
                hijoizq.SetPadre(padre);
                nodo.SetFe(0);
                hijoizq.SetFe(0);
            }
            else
            {
                NodoAVL hijoder = nodo.GetHijoDerecho();
                NodoAVL hijoderizq = hijoder.GetHijoIzquierdo();
                if (padre != null)
                {
                    if (padre.GetHijoDerecho() == nodo)
                    {
                        padre.SetHijoDerecho(hijoder);
                    }
                    else
                    {
                        padre.SetHijoIzquierdo(hijoder);
                    }
                }
                else
                {
                    this.raiz = hijoder;
                }

                nodo.SetHijoDerecho(hijoderizq);
                hijoder.SetHijoIzquierdo(nodo);
                nodo.SetPadre(hijoder);
                if (hijoderizq != null)
                {
                    hijoderizq.SetPadre(nodo);
                }
                hijoder.SetPadre(padre);
                hijoder.SetFe(0);
                nodo.SetFe(0);
            }
        }

        public bool ExisteContacto(string usuario)
        {
            if (GetRaiz() != null)
            {
                NodoAVL aux = this.raiz;
                while (aux != null)
                {
                    if (aux.GetUsuario() == usuario)
                    {
                        return true;
                    }
                    if (aux.GetUsuario().CompareTo(usuario) > 0)
                    {
                        aux = aux.GetHijoIzquierdo();
                    }
                    else
                    {
                        aux = aux.GetHijoDerecho();
                    }
                }
            }
            return false;
        }

        public int Numerodecontactos(NodoAVL nodo)
        {
            int aux = 0;
            if (nodo != null)
            {
                aux+=1;
                if (nodo.GetHijoIzquierdo() != null)
                {
                    aux += Numerodecontactos(nodo.GetHijoIzquierdo());
                }
                if (nodo.GetHijoDerecho() != null)
                {
                    aux += Numerodecontactos(nodo.GetHijoDerecho());
                }
            }
            return aux;
        }
    }
}