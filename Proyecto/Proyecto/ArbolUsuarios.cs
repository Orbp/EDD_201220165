using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto
{
    public class ArbolUsuarios
    {
        private NodoArbol raiz;

        public NodoArbol GetRaiz()
        {
            return this.raiz;
        }

        public void SetRaiz(NodoArbol aux)
        {
            this.raiz = aux;
        }

        public bool Insertar(NodoArbol raiz, string pnickname, string ppassword, string pcorreo, bool pconectado)
        {
            if (!ExisteUsuario(pnickname))
            {
                if (raiz.GetNickname().CompareTo(pnickname) > 0)
                {
                    if (raiz.GetHijoIzquierdo() == null)
                    {
                        raiz.SetHijoIzquierdo(new NodoArbol(pnickname, ppassword, pcorreo, pconectado));
                    }
                    else
                    {
                        Insertar(raiz.GetHijoIzquierdo(), pnickname, ppassword, pcorreo, pconectado);
                    }
                }
                else if (raiz.GetNickname().CompareTo(pnickname) < 0)
                {
                    if (raiz.GetHijoDerecho() == null)
                    {
                        raiz.SetHijoDerecho(new NodoArbol(pnickname, ppassword, pcorreo, pconectado));
                    }
                    else
                    {
                        Insertar(raiz.GetHijoDerecho(), pnickname, ppassword, pcorreo, pconectado);
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ExisteUsuario(string pnickname)
        {
            if (!ArbolVacio())
            {
                NodoArbol aux = this.raiz;
                while (aux != null)
                {
                    if (aux.GetNickname() == pnickname)
                    {
                        return true;
                    }

                    if (aux.GetNickname().CompareTo(pnickname) > 0)
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

        public bool ArbolVacio()
        {
            if (this.raiz == null)
            {
                return true;
            }
            return false;
        }

        public NodoArbol GetUsuario(string pnickname)
        {
            NodoArbol aux = this.raiz;
            while (aux != null)
            {
                if (aux.GetNickname() == pnickname)
                {
                    return aux;
                }
                if (aux.GetNickname().CompareTo(pnickname) > 0)
                {
                    aux = aux.GetHijoIzquierdo();
                }
                else
                {
                    aux = aux.GetHijoDerecho();
                }
            }
            return null;
        }

        public bool EliminarUsuario(string pnickname)
        {
            if (!ArbolVacio())
            {
                if (ExisteUsuario(pnickname))
                {
                    NodoArbol padre = null;
                    NodoArbol aux = this.raiz;
                    while (aux != null)
                    {
                        if (aux.GetNickname().CompareTo(pnickname) > 0)
                        {
                            padre = aux;
                            aux = aux.GetHijoIzquierdo();
                        }
                        else if (aux.GetNickname().CompareTo(pnickname) < 0)
                        {
                            padre = aux;
                            aux = aux.GetHijoDerecho();
                        }
                        else
                        {
                            if (aux.GetHijoIzquierdo() == null && aux.GetHijoDerecho() == null)//caso que no tenga hijos
                            {
                                if (padre == null)
                                {
                                    this.SetRaiz(null);
                                }
                                else
                                {
                                    if (padre.GetHijoIzquierdo() == aux)
                                    {
                                        padre.SetHijoIzquierdo(null);
                                    }
                                    else if (padre.GetHijoDerecho() == aux)
                                    {
                                        padre.SetHijoDerecho(null);
                                    }
                                    aux = null;
                                }
                            }
                            else if (aux.GetHijoIzquierdo() == null || aux.GetHijoDerecho() == null)
                            {
                                if (padre != null)
                                {
                                    if (padre.GetHijoDerecho() == aux)
                                    {
                                        if (aux.GetHijoDerecho() != null)
                                        {
                                            padre.SetHijoDerecho(aux.GetHijoDerecho());
                                            aux.SetHijoDerecho(null);
                                        }
                                        else if (aux.GetHijoIzquierdo() != null)
                                        {
                                            padre.SetHijoDerecho(aux.GetHijoIzquierdo());
                                            aux.SetHijoIzquierdo(null);
                                        }
                                    }
                                    else if (padre.GetHijoIzquierdo() == aux)
                                    {
                                        if (aux.GetHijoDerecho() != null)
                                        {
                                            padre.SetHijoIzquierdo(aux.GetHijoDerecho());
                                            aux.SetHijoDerecho(null);
                                        }
                                        else if (aux.GetHijoIzquierdo() != null)
                                        {
                                            padre.SetHijoIzquierdo(aux.GetHijoIzquierdo());
                                            aux.SetHijoIzquierdo(null);
                                        }
                                    }
                                    aux = null;
                                }
                                else
                                {
                                    if (aux.GetHijoDerecho() != null)
                                    {
                                        this.raiz = aux.GetHijoDerecho();
                                    }
                                    else if (aux.GetHijoIzquierdo() != null)
                                    {
                                        this.raiz = aux.GetHijoIzquierdo();
                                    }
                                    aux = null;
                                }
                            }
                            else
                            {
                                NodoArbol hijoaux = aux.GetHijoDerecho();
                                NodoArbol padrehijoaux = null;
                                while (hijoaux.GetHijoIzquierdo() != null)
                                {
                                    padrehijoaux = hijoaux;
                                    hijoaux = hijoaux.GetHijoIzquierdo();
                                }

                                if (hijoaux.GetHijoDerecho() != null && padrehijoaux != null)
                                {
                                    padrehijoaux.SetHijoIzquierdo(hijoaux.GetHijoDerecho());
                                }
                                else if (padrehijoaux != null)
                                {
                                    padrehijoaux.SetHijoIzquierdo(null);
                                }
                                if (padre != null)
                                {
                                    if (padre.GetHijoIzquierdo() == aux)
                                    {
                                        if (aux.GetHijoDerecho() != hijoaux)
                                        {
                                            hijoaux.SetHijoDerecho(aux.GetHijoDerecho());
                                        }
                                        hijoaux.SetHijoIzquierdo(aux.GetHijoIzquierdo());
                                        padre.SetHijoIzquierdo(hijoaux);
                                        aux.SetHijoDerecho(null);
                                    }
                                    else if (padre.GetHijoDerecho() == aux)
                                    {
                                        hijoaux.SetHijoIzquierdo(aux.GetHijoIzquierdo());
                                        if (aux.GetHijoDerecho() != hijoaux)
                                        {
                                            hijoaux.SetHijoDerecho(aux.GetHijoDerecho());
                                        }   
                                        padre.SetHijoDerecho(hijoaux);
                                        aux.SetHijoDerecho(null);
                                    }
                                    aux = null;
                                }
                                else
                                {
                                    if (aux.GetHijoDerecho() == hijoaux)
                                    {
                                        hijoaux.SetHijoIzquierdo(aux.GetHijoIzquierdo());
                                        aux.SetHijoDerecho(null);
                                        this.raiz = hijoaux;
                                    }
                                    else
                                    {
                                        hijoaux.SetHijoDerecho(aux.GetHijoDerecho());
                                        hijoaux.SetHijoIzquierdo(aux.GetHijoIzquierdo());
                                        this.raiz = hijoaux;
                                    }   
                                    aux = null;
                                }
                            }
                        }
                    }
                    return true;
                }
                return false;
            }
            return false;
        }

        public bool Insertarenlistajuegos(string pjugador, string poponente, int punides, int punisob, int punidest, bool pgano)
        {
            if (!ArbolVacio())
            {
                NodoArbol aux = this.GetRaiz();
                while (aux != null)
                {
                    if (aux.GetNickname() == pjugador)
                    {
                        aux.GetListaJuegos().InsertarListaJuegos(pjugador, poponente, punides, punisob, punidest, pgano);
                        break;
                    }
                    if (aux.GetNickname().CompareTo(pjugador) > 0)
                    {
                        aux = aux.GetHijoIzquierdo();
                    }
                    else
                    {
                        aux = aux.GetHijoDerecho();
                    }
                }
                if (aux == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}