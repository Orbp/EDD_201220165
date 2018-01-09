using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Proyecto
{
    public class ArbolUsuarios
    {
        private NodoArbol raiz;
        public bool espejo = false;

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

        public bool ExisteUsuario(string pnickname, string password)
        {
            if (!ArbolVacio())
            {
                NodoArbol aux = this.raiz;
                while (aux != null)
                {
                    if (aux.GetNickname() == pnickname && aux.GetPassword() == password)
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

        
        public string DevolverUsuarios(NodoArbol raiz)
        {
            string auxUsuarios = "";
            if (raiz != null)
            {
                auxUsuarios += raiz.GetNickname() + ",";
            }

            if (raiz.GetHijoIzquierdo() != null)
            {
                auxUsuarios += DevolverUsuarios(raiz.GetHijoIzquierdo());
            }
            if(raiz.GetHijoDerecho() != null)
            {
                auxUsuarios += DevolverUsuarios(raiz.GetHijoDerecho());
            }

            return auxUsuarios;
        }

        public string DevolverJuegos(string pnickname)
        {
            string auxJuegos = "";
            NodoArbol aux = this.raiz;
            while (aux != null)
            {
                if (aux.GetNickname() == pnickname)
                {
                    return aux.GetListaJuegos().DevolverLista();
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
            return "";
        }

        public void BorrarJuegos(string jugador1, string jugador2, int unidadesdes, int unidadessob, int unidadesdest)
        {
            NodoArbol aux = this.raiz;
            while (aux != null)
            {
                if (aux.GetNickname() == jugador1)
                {
                    aux.GetListaJuegos().EliminarJuego(jugador1, jugador2, unidadesdes, unidadessob, unidadesdest);
                    break;
                }
                if (aux.GetNickname().CompareTo(jugador1) > 0)
                {
                    aux = aux.GetHijoIzquierdo();
                }
                else
                {
                    aux = aux.GetHijoDerecho();
                }
            }
        }

        public string DevDatosJuego(string jugador1, string jugador2, int unidadesdes, int unidadessob, int unidadesdest)
        {
            string dev = "";
            NodoArbol aux = this.raiz;
            while (aux != null)
            {
                if (aux.GetNickname() == jugador1)
                {
                    dev = aux.GetListaJuegos().DevolverDatos(jugador1, jugador2, unidadesdes, unidadessob, unidadesdest);
                    break;
                }
                if (aux.GetNickname().CompareTo(jugador1) > 0)
                {
                    aux = aux.GetHijoIzquierdo();
                }
                else
                {
                    aux = aux.GetHijoDerecho();
                }
            }
            return dev;
        }

        public void ModificarDatosJuego(string jugador1, string oponenteant, string oponentenue, int unidadesdesant, int unidadesdesnue, int unidadessobant, int unidadessobnue, int unidadesdestant, int unidadesdestnue)
        {
            NodoArbol aux = this.raiz;
            while (aux != null)
            {
                if (aux.GetNickname() == jugador1)
                {
                    aux.GetListaJuegos().ModificarDatosJuego(jugador1, oponenteant, oponentenue, unidadesdesant, unidadesdesnue, unidadessobant, unidadessobnue, unidadesdestant, unidadesdestnue);
                    break;
                }
                if (aux.GetNickname().CompareTo(jugador1) > 0)
                {
                    aux = aux.GetHijoIzquierdo();
                }
                else
                {
                    aux = aux.GetHijoDerecho();
                }
            }
        }

        public ArbolUsuarios Espejo(ArbolUsuarios arbol1)
        {
            if (arbol1.espejo)
            {
                arbol1.espejo = false;
            }
            else
            {
                arbol1.espejo = true;
            }
            arbol1.SetRaiz(nespejo(arbol1.GetRaiz()));
            return arbol1;
        }

        private NodoArbol nespejo(NodoArbol nodo)
        {
            if (nodo == null)
            {
                return null;
            }
            else
            {
                NodoArbol temporal = nodo.GetHijoIzquierdo();
                nodo.SetHijoIzquierdo(nespejo(nodo.GetHijoDerecho()));
                nodo.SetHijoDerecho(nespejo(temporal));
                return nodo;
            }
        }

        public int Altura(NodoArbol raiz, int alt)
        {
            alt = AuxAltura(raiz, 1, alt);
            return alt;
        }

        public int AuxAltura(NodoArbol raiz, int a, int alt)
        {
            if (raiz.GetHijoIzquierdo() != null)
            {
                alt = AuxAltura(raiz.GetHijoIzquierdo(), a + 1, alt);
            }
            if (raiz.GetHijoDerecho() != null)
            {
                alt = AuxAltura(raiz.GetHijoDerecho(), a + 1, alt);
            }
            if (raiz.GetHijoIzquierdo() == null && raiz.GetHijoDerecho() == null && a > alt)
            {
                alt = a;
            }
            return alt;
        }

        private int numnodos = 0;

        
        public int AuxNodosHoja(NodoArbol raiz, int cont)
        {
            if (raiz.GetHijoDerecho() == null && raiz.GetHijoIzquierdo() == null)
            {
                return ++cont;
            }
            int hijosiz = 0;
            if (raiz.GetHijoIzquierdo() != null)
            {
                hijosiz = AuxNodosHoja(raiz.GetHijoIzquierdo(), cont);
            }
            int hijosder = 0;
            if (raiz.GetHijoDerecho() != null)
            {
                hijosder = AuxNodosHoja(raiz.GetHijoDerecho(), cont);
            }
            return hijosiz + hijosder;
        }

        public int AuxNodosRama(NodoArbol raiz, int cont)
        {
            int ramasiz = 0;
            if (raiz.GetHijoIzquierdo() != null)
            {
                ramasiz = AuxNodosRama(raiz.GetHijoIzquierdo(), cont);
            }
            int ramasder = 0;
            if (raiz.GetHijoDerecho() != null)
            {
                ramasder = AuxNodosRama(raiz.GetHijoDerecho(), cont);
            }

            if (raiz.GetHijoIzquierdo() != null || raiz.GetHijoDerecho() != null)
            {
                cont++;
            }
            return cont + ramasiz+ ramasder;
        }

        public ListaTopJuegosGanados listajuegosg(NodoArbol raiz, ListaTopJuegosGanados lista)
        {
            if (raiz != null)
            {
                int nu = raiz.GetListaJuegos().DevolverJuegosGanados(raiz);
                if (nu != 0)
                {
                    lista.InsertarListaJuegosGanados(raiz.GetNickname(), nu);
                }
                
            }
            if (raiz.GetHijoIzquierdo() != null)
            {
                listajuegosg(raiz.GetHijoIzquierdo(), lista);
            }
            if (raiz.GetHijoDerecho() != null)
            {
                listajuegosg(raiz.GetHijoDerecho(), lista);
            }
            return lista;
        }

        public ListaTopUnidadesDestruidas listaunidadesdes(NodoArbol raiz, ListaTopUnidadesDestruidas lista)
        {
            if (raiz != null)
            {
                double n = raiz.GetListaJuegos().DevolverPorcentajeUnidadesDest(raiz);
                if (n != 0)
                {
                    lista.InsertarTopUnidades(raiz.GetNickname(), n);
                }
            }
            if (raiz.GetHijoIzquierdo() != null)
            {
                listaunidadesdes(raiz.GetHijoIzquierdo(), lista);
            }
            if (raiz.GetHijoDerecho() != null)
            {
                listaunidadesdes(raiz.GetHijoDerecho(), lista);
            }
            return lista;
        }

        public void InsertarContacto(string usuario, string contacto, string password, string correo)
        {
            NodoArbol aux = this.GetRaiz();
            if (aux.GetNickname() == usuario)
            {
                if (aux.GetContactos().GetRaiz() == null)
                {
                    aux.GetContactos().SetRaiz(new NodoAVL(contacto, password, correo));
                }
                else
                {
                    aux.GetContactos().Insertar(contacto, password, correo);
                }
            }
            if (aux.GetNickname().CompareTo(usuario) > 0)
            {
                aux = aux.GetHijoIzquierdo();
            }
            else
            {
                aux = aux.GetHijoDerecho();
            }
        }

        public void ExportaraHash(TablaHashUsuarios tabla, NodoArbol nodo)
        {
            if (nodo != null)
            {
                tabla.Insertar(nodo.GetNickname(), nodo.GetPassword(), nodo.GetCorreo(), nodo.GetConectado());

                if (nodo.GetHijoIzquierdo() != null)
                {
                    ExportaraHash(tabla, nodo.GetHijoIzquierdo());
                }
                if (nodo.GetHijoDerecho() != null)
                {
                    ExportaraHash(tabla, nodo.GetHijoDerecho());
                }
            }
        }
    }
}