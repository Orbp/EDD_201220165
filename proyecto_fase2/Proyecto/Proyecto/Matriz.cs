using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto
{
    public class Matriz
    {
        public EncabezadosColumna encnivel1;//niveles de acceso
        public EncabezadoFila enfnivel1;//niveles de acceso
        public EncabezadosColumna encnivel0;
        public EncabezadoFila enfnivel0;
        public EncabezadosColumna encnivel2;
        public EncabezadoFila enfnivel2;
        public EncabezadosColumna encnivel3;
        public EncabezadoFila enfnivel3;
        private int nivel;


        public Matriz()
        {
            this.encnivel1 = new EncabezadosColumna();
            this.enfnivel1 = new EncabezadoFila();
            this.encnivel0 = new EncabezadosColumna();
            this.encnivel2 = new EncabezadosColumna();
            this.encnivel3 = new EncabezadosColumna();
            this.enfnivel0 = new EncabezadoFila();
            this.enfnivel2 = new EncabezadoFila();
            this.enfnivel3 = new EncabezadoFila();
        }

        public EncabezadosColumna GetEncabezadosColumnas()
        {
            return this.encnivel1;
        }

        public EncabezadoFila GetEncabezadosFilas()
        {
            return this.enfnivel1;
        }



        public void Insertar(int fila, char columna, int nivel, int movimiento, int alcance, int ataque, int vida, string idunidad, string idjugador)
        {
            //Insercion con niveles
            this.nivel = nivel;
            EncabezadosColumna auxenc;
            EncabezadoFila auxenf;
            if (nivel == 0)
            {
                auxenc = encnivel0;
                auxenf = enfnivel0;
            }
            else if (nivel == 1)
            {
                auxenc = encnivel1;
                auxenf = enfnivel1;
            }
            else if (nivel == 2)
            {
                auxenc = encnivel2;
                auxenf = enfnivel2;
            }
            else
            {
                auxenc = encnivel3;
                auxenf = enfnivel3;
            }

            Insertar(auxenf, auxenc, fila, columna, movimiento, alcance, ataque, vida, idunidad, idjugador);
        }

        public NodoMatriz ExisteNodo(EncabezadoFila enf, EncabezadosColumna enc, int fila, char columna)
        {
            if (enf.ExisteFila(fila) != null && enc.ExisteEncabezadoColuma(columna) != null)
            {
                NodoMatriz aux = enf.ExisteFila(fila).cont;
                while (aux  != null && aux.columna != columna)
                {
                    aux = aux.siguiente;
                }
                return aux;
            }
            return null;
        }

        public bool ExistePieza(EncabezadoFila enf, EncabezadosColumna enc, int fila, char columna, string pieza, string jugador)
        {
            if (enf.ExisteFila(fila) != null && enc.ExisteEncabezadoColuma(columna) != null)
            {
                NodoMatriz aux = enf.ExisteFila(fila).cont;
                while (aux != null && aux.columna != columna)
                {
                    aux = aux.siguiente;
                }
                if (aux.idunidad == pieza && aux.idjugador == jugador)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public NodoMatriz Eliminar(EncabezadoFila enf, EncabezadosColumna enc, int fila, char columna)
        {
            NodoMatriz aux = null;
            if (enf.ExisteFila(fila) != null && enc.ExisteEncabezadoColuma(columna) != null)
            {
                aux = enf.ExisteFila(fila).cont;
                while (aux != null && aux.columna != columna)
                {
                    aux = aux.siguiente;
                }
                NodoMatriz anterior = aux.anterior;//puntero al nodo que esta en la columna anterior
                NodoMatriz sig = aux.siguiente;//puntero al nodo que esta en la columna siguiente
                NodoMatriz arriba = aux.arriba;//puntero al nodo que esta en la fila anterior
                NodoMatriz abajo = aux.abajo;//puntero al nodo que esta en la fila siguiente
                if (anterior == null && sig == null)
                {
                    enf.EliminarEncabezadoFila(fila);
                }
                else if (anterior == null)
                {
                    enf.ExisteFila(fila).cont = sig;
                    aux.siguiente = null;
                    sig.anterior = null;
                }
                else if (sig == null)
                {
                    anterior.siguiente = null;
                    aux.anterior = null;
                }
                else
                {
                    anterior.siguiente = sig;
                    sig.anterior = anterior;
                    aux.siguiente = null;
                    aux.anterior = null;
                }
                if (arriba == null && abajo == null)
                {
                    enc.EliminarEncabezadoColumna(columna);
                }
                else if (arriba == null)
                {
                    enc.ExisteEncabezadoColuma(columna).cont = abajo;
                    aux.abajo = null;
                    abajo.arriba = null;
                }
                else if (abajo == null)
                {
                    arriba.abajo = null;
                    aux.arriba = null;
                }
                else
                {
                    arriba.abajo = abajo;
                    abajo.arriba = arriba;
                    aux.arriba = null;
                    aux.abajo = null;
                }
            }
            return aux;
        }

        public void Insertar(EncabezadoFila enf, EncabezadosColumna enc, int fila, char columna, int movimiento, int alcance, int ataque, int vida, string idunidad, string idjugador)
        {
            NodoMatriz nuevo = new NodoMatriz(movimiento, alcance, ataque, vida, idunidad, idjugador, fila, columna);
            NodoEncabezado auxiliarenc = enc.ExisteEncabezadoColuma(columna);
            if (auxiliarenc == null)//Si la columna en la que se tiene que insertar no existe
            {
                enc.InsertarEncabezadoColumna(columna, nuevo);
            }
            else
            {
                if (auxiliarenc.cont.fila > fila)
                {
                    nuevo.abajo = auxiliarenc.cont;
                    auxiliarenc.cont.arriba = nuevo;
                    auxiliarenc.cont = nuevo;
                }
                else
                {
                    NodoMatriz aux = auxiliarenc.cont;//nodo auxiliar que recorre el contenido de la columna
                    while (aux.abajo != null)//recorrido hasta la ultima posicion del contenido de la columna
                    {
                        if (aux.fila < fila && aux.abajo.fila > fila)
                        {
                            break;
                        }
                        aux = aux.abajo;
                    }
                    if (aux.abajo == null)//si llega a la ultima posicion inserta al final
                    {
                        aux.abajo = nuevo;
                        nuevo.arriba = aux;
                    }
                    else
                    {
                        nuevo.abajo = aux.abajo;
                        nuevo.arriba = aux;
                        aux.abajo.arriba = nuevo;
                        aux.abajo = nuevo;
                    }
                }
            }

            auxiliarenc = enf.ExisteFila(fila);
            if (auxiliarenc == null)//Si la fila en la que se tiene que insertar no existe
            {
                enf.InsertarEncabezadoFila(fila, nuevo);
            }
            else
            {
                if (auxiliarenc.cont.columna > columna)
                {
                    nuevo.siguiente = auxiliarenc.cont;
                    auxiliarenc.cont.anterior = nuevo;
                    auxiliarenc.cont = nuevo;
                }
                else
                {
                    NodoMatriz aux = auxiliarenc.cont;
                    while (aux.siguiente != null)
                    {
                        if (aux.columna < columna && aux.siguiente.columna > columna)
                        {
                            break;
                        }
                        aux = aux.siguiente;
                    }
                    if (aux.siguiente == null)
                    {
                        aux.siguiente = nuevo;
                        nuevo.anterior = aux;
                    }
                    else
                    {
                        nuevo.siguiente = aux.siguiente;
                        nuevo.anterior = aux;
                        aux.siguiente.anterior = nuevo;
                        aux.siguiente = nuevo;
                    }
                }
            }

            if (nivel == 0)
            {
                NodoEncabezado auxiliarcol = encnivel1.ExisteEncabezadoColuma(columna);
                NodoEncabezado auxiliarfil = enfnivel1.ExisteFila(fila);
                if (auxiliarcol != null)//si existe el encabezado de la columna en el nivel 1
                {
                    NodoEncabezado actual = encnivel0.ExisteEncabezadoColuma(columna);
                    actual.arriba = auxiliarcol;
                    auxiliarcol.abajo = actual;
                }
                else//si no se ira a buscar al nivel 2
                {
                    auxiliarcol = encnivel2.ExisteEncabezadoColuma(columna);
                    if (auxiliarcol != null)//si existe el encabezado de la columna en el nivel 2
                    {
                        NodoEncabezado actual = encnivel0.ExisteEncabezadoColuma(columna);
                        actual.arriba = auxiliarcol;
                        auxiliarcol.abajo = actual;
                    }
                    else//si no se ira a buscar al nivel 3
                    {
                        auxiliarcol = encnivel3.ExisteEncabezadoColuma(columna);
                        if (auxiliarcol != null)
                        {
                            NodoEncabezado actual = encnivel0.ExisteEncabezadoColuma(columna);
                            actual.arriba = auxiliarcol;
                            auxiliarcol.abajo = actual;
                        }
                    }
                }

                if (auxiliarfil != null)//si existe el encabezado de la fila en el nivel 1
                {
                    NodoEncabezado actual = enfnivel0.ExisteFila(fila);
                    actual.arriba = auxiliarfil;
                    auxiliarfil.abajo = actual;
                }
                else//si no se ira a buscar al nivel 2
                {
                    auxiliarfil = enfnivel2.ExisteFila(fila);
                    if (auxiliarfil != null)
                    {
                        NodoEncabezado actual = enfnivel0.ExisteFila(fila);
                        actual.arriba = auxiliarfil;
                        auxiliarfil.abajo = actual;
                    }
                    else//si no existe en el nivel 2 se ira al 3
                    {
                        auxiliarfil = enfnivel3.ExisteFila(fila);
                        if (auxiliarfil != null)
                        {
                            NodoEncabezado actual = enfnivel0.ExisteFila(fila);
                            actual.arriba = auxiliarfil;
                            auxiliarfil.abajo = actual;
                        }
                    }
                }
                //relacionar nodos contenido
                NodoMatriz auxiliarcontenido = ExisteNodo(enfnivel1, encnivel1, fila, columna);//busca el nodo en el nivel 1
                if (auxiliarcontenido != null)//si el nodo existe
                {
                    nuevo.subir = auxiliarcontenido;
                    auxiliarcontenido.bajar = nuevo;
                }
                else//si no se va a buscar al siguiente nivel
                {
                    auxiliarcontenido = ExisteNodo(enfnivel2, encnivel2, fila, columna);
                    if (auxiliarcontenido != null)
                    {
                        nuevo.subir = auxiliarcontenido;
                        auxiliarcontenido.bajar = nuevo;
                    }
                    else
                    {
                        auxiliarcontenido = ExisteNodo(enfnivel3, encnivel3, fila, columna);
                        if (auxiliarcontenido != null)
                        {
                            nuevo.subir = auxiliarcontenido;
                            auxiliarcontenido.bajar = nuevo;
                        }
                    }
                }
            }
            else if (nivel == 1)
            {
                NodoEncabezado auxiliarabajo = encnivel0.ExisteEncabezadoColuma(columna); // relacion a nivel inferior
                NodoEncabezado auxiliararriba = encnivel2.ExisteEncabezadoColuma(columna); //relacion a nivel superior
                NodoEncabezado actual = encnivel1.ExisteEncabezadoColuma(columna);
                //columnas
                if (auxiliarabajo != null)
                {
                    actual.abajo = auxiliarabajo;
                    auxiliarabajo.arriba = actual;
                }

                if (auxiliararriba != null)
                {
                    actual.arriba = auxiliararriba;
                    auxiliararriba.abajo = actual;
                }
                else
                {
                    auxiliararriba = encnivel3.ExisteEncabezadoColuma(columna);
                    if (auxiliararriba != null)
                    {
                        actual.arriba = auxiliararriba;
                        auxiliararriba.abajo = actual;
                    }
                }
                //filas
                auxiliarabajo = enfnivel0.ExisteFila(fila);
                auxiliararriba = enfnivel2.ExisteFila(fila);
                actual = enfnivel1.ExisteFila(fila);
                if (auxiliarabajo != null)
                {
                    actual.abajo = auxiliarabajo;
                    auxiliarabajo.arriba = actual;
                }

                if (auxiliararriba != null)
                {
                    actual.arriba = auxiliararriba;
                    auxiliararriba.abajo = actual;
                }
                else
                {
                    auxiliararriba = enfnivel3.ExisteFila(fila);
                    if (auxiliararriba != null)
                    {
                        actual.arriba = auxiliararriba;
                        auxiliararriba.abajo = actual;
                    }
                }

                //contenido
                NodoMatriz auxiliarcontenido = ExisteNodo(enfnivel0, encnivel0, fila, columna);
                if (auxiliarcontenido != null)//para ver si se puede conectar con un nodo en el nivel inferior
                {
                    nuevo.bajar = auxiliarcontenido;
                    auxiliarcontenido.subir = nuevo;
                }

                auxiliarcontenido = ExisteNodo(enfnivel2, encnivel2, fila, columna);
                if (auxiliarcontenido != null)//para verificar si se puede conectar con un nodo en el nivel superior
                {
                    nuevo.subir = auxiliarcontenido;
                    auxiliarcontenido.bajar = nuevo;
                }
                else
                {
                    auxiliarcontenido = ExisteNodo(enfnivel3, encnivel3, fila, columna);
                    if (auxiliarcontenido != null)
                    {
                        nuevo.subir = auxiliarcontenido;
                        auxiliarcontenido.bajar = nuevo;
                    }
                }
            }
            else if (nivel == 2)
            {
                NodoEncabezado auxiliarabajo = encnivel1.ExisteEncabezadoColuma(columna); // relacion a nivel inferior
                NodoEncabezado auxiliararriba = encnivel3.ExisteEncabezadoColuma(columna); //relacion a nivel superior
                NodoEncabezado actual = encnivel2.ExisteEncabezadoColuma(columna);
                //columnas
                if (auxiliarabajo != null)
                {
                    actual.abajo = auxiliarabajo;
                    auxiliarabajo.arriba = actual;
                }
                else
                {
                    auxiliarabajo = encnivel0.ExisteEncabezadoColuma(columna);
                    if (auxiliarabajo != null)
                    {
                        actual.abajo = auxiliarabajo;
                        auxiliarabajo.arriba = actual;
                    }
                }

                if (auxiliararriba != null)
                {
                    actual.arriba = auxiliararriba;
                    auxiliararriba.abajo = actual;
                }

                //filas
                auxiliarabajo = enfnivel1.ExisteFila(fila);
                auxiliararriba = enfnivel3.ExisteFila(fila);
                actual = enfnivel2.ExisteFila(fila);
                if (auxiliarabajo != null)
                {
                    actual.abajo = auxiliarabajo;
                    auxiliarabajo.arriba = actual;
                }
                else
                {
                    auxiliarabajo = enfnivel0.ExisteFila(fila);
                    if (auxiliarabajo != null)
                    {
                        auxiliarabajo.arriba = actual;
                        actual.abajo = auxiliarabajo;
                    }
                }

                if (auxiliararriba != null)
                {
                    actual.arriba = auxiliararriba;
                    auxiliararriba.abajo = actual;
                }


                //contenido
                NodoMatriz auxiliarcontenido = ExisteNodo(enfnivel1, encnivel1, fila, columna);
                if (auxiliarcontenido != null)//para ver si se puede conectar con un nodo en el nivel inferior
                {
                    nuevo.bajar = auxiliarcontenido;
                    auxiliarcontenido.subir = nuevo;
                }
                else
                {
                    auxiliarcontenido = ExisteNodo(enfnivel0, encnivel0, fila, columna);
                    if (auxiliarcontenido != null)
                    {
                        nuevo.bajar = auxiliarcontenido;
                        auxiliarcontenido.subir = nuevo;
                    }
                }

                auxiliarcontenido = ExisteNodo(enfnivel3, encnivel3, fila, columna);
                if (auxiliarcontenido != null)//para verificar si se puede conectar con un nodo en el nivel superior
                {
                    nuevo.subir = auxiliarcontenido;
                    auxiliarcontenido.bajar = nuevo;
                }
            }
            else
            {
                NodoEncabezado auxiliarabajo = encnivel2.ExisteEncabezadoColuma(columna);
                NodoEncabezado actual = encnivel3.ExisteEncabezadoColuma(columna);
                //columnas
                if (auxiliarabajo != null)
                {
                    actual.abajo = auxiliarabajo;
                    auxiliarabajo.arriba = actual;
                }
                else
                {
                    auxiliarabajo = encnivel1.ExisteEncabezadoColuma(columna);
                    if (auxiliarabajo != null)
                    {
                        actual.abajo = auxiliarabajo;
                        auxiliarabajo.arriba = actual;
                    }
                    else
                    {
                        auxiliarabajo = encnivel0.ExisteEncabezadoColuma(columna);
                        if (auxiliarabajo != null)
                        {
                            actual.abajo = auxiliarabajo;
                            auxiliarabajo.arriba = actual;
                        }
                    }
                }
                //filas
                auxiliarabajo = enfnivel2.ExisteFila(fila);
                actual = enfnivel3.ExisteFila(fila);
                if (auxiliarabajo != null)
                {
                    actual.abajo = auxiliarabajo;
                    auxiliarabajo.arriba = actual;
                }
                else
                {
                    auxiliarabajo = enfnivel1.ExisteFila(fila);
                    if (auxiliarabajo != null)
                    {
                        actual.abajo = auxiliarabajo;
                        auxiliarabajo.arriba = actual;
                    }
                    else
                    {
                        auxiliarabajo = enfnivel0.ExisteFila(fila);
                        if (auxiliarabajo != null)
                        {
                            actual.abajo = auxiliarabajo;
                            auxiliarabajo.arriba = actual;
                        }
                    }
                }
                //contenido4
                NodoMatriz auxiliarcontenido = ExisteNodo(enfnivel2, encnivel2, fila, columna);
                if (auxiliarcontenido != null)
                {
                    nuevo.bajar = auxiliarcontenido;
                    auxiliarcontenido.subir = nuevo;
                }
                else
                {
                    auxiliarcontenido = ExisteNodo(enfnivel1, encnivel1, fila, columna);
                    if (auxiliarcontenido != null)
                    {
                        nuevo.bajar = auxiliarcontenido;
                        auxiliarcontenido.subir = nuevo;
                    }
                    else
                    {
                        auxiliarcontenido = ExisteNodo(enfnivel0, encnivel0, fila, columna);
                        if (auxiliarcontenido != null)
                        {
                            nuevo.bajar = auxiliarcontenido;
                            auxiliarcontenido.subir = nuevo;
                        }
                    }
                }
            }
        }

    }
}