using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto
{
    public class ArbolHistorial
    {
        public DatosNodoHistoria[] listadatos;
        public NodoHistorial[] listaramas;
        private NodoHistorial nodoentrada;
        private int index;
        public int numerodetirosfinal;

        public NodoHistorial GetNodoEntrada()
        {
            return this.nodoentrada;
        }

        public ArbolHistorial(int indice)
        {
            listadatos = new DatosNodoHistoria[indice + 1];
            listaramas = new NodoHistorial[indice + 2];
            nodoentrada = null;
            index = indice;
            numerodetirosfinal = 0;
        }

        public bool InsertarHistorialCoordenadaX(DatosNodoHistoria datos)
        {
            NodoHistorial nodo, padre;
            int i;
            padre = nodo = this.nodoentrada;
            while (nodo != null)
            {
                padre = nodo;
                i = 0;
                while (i < nodo.GetClavesUsadas() && nodo.Datos[i].GetCoordenadaX().CompareTo(datos.GetCoordenadaX()) < 0)
                {
                    i++;
                }
                if (nodo.Datos[i] != null && nodo.Datos[i].GetCoordenadaX() == datos.GetCoordenadaX() && i < nodo.GetClavesUsadas())
                {
                    InsertarHistorialNumerodetiro(datos);
                    return true;
                }
                else
                {
                    nodo = nodo.Ramas[i];
                }
            }
            nodo = padre;
            InsertarHistorial(datos, nodo, null, null, "coordenadax");
            numerodetirosfinal++;
            return true;
        }

        public bool InsertarHistorialCoordenadaY(DatosNodoHistoria datos)
        {
            NodoHistorial nodo, padre;
            int i;
            padre = nodo = this.nodoentrada;
            while (nodo != null)
            {
                padre = nodo;
                i = 0;
                while (i < nodo.GetClavesUsadas() && nodo.Datos[i].GetCoordenadaY().CompareTo(datos.GetCoordenadaY()) < 0)
                {
                    i++;
                }
                if (nodo.Datos[i] != null && nodo.Datos[i].GetCoordenadaY() == datos.GetCoordenadaY() && i < nodo.GetClavesUsadas())
                {
                    InsertarHistorialNumerodetiro(datos);
                    return true;
                }
                else
                {
                    nodo = nodo.Ramas[i];
                }
            }
            nodo = padre;
            InsertarHistorial(datos, nodo, null, null, "coordenaday");
            numerodetirosfinal++;
            return true;
        }

        public bool InsertarHistorialUnidadAtacante(DatosNodoHistoria datos)
        {
            NodoHistorial nodo, padre;
            int i;
            padre = nodo = this.nodoentrada;
            while (nodo != null)
            {
                padre = nodo;
                i = 0;
                while (i < nodo.GetClavesUsadas() && nodo.Datos[i].GetUnidadatacante().CompareTo(datos.GetUnidadatacante()) < 0)
                {
                    i++;
                }
                if (nodo.Datos[i] != null && nodo.Datos[i].GetUnidadatacante() == datos.GetUnidadatacante() && i < nodo.GetClavesUsadas())
                {
                    InsertarHistorialNumerodetiro(datos);
                    return true;
                }
                else
                {
                    nodo = nodo.Ramas[i];
                }
            }
            nodo = padre;
            InsertarHistorial(datos, nodo, null, null, "unidadatacante");
            numerodetirosfinal++;
            return true;
        }

        public bool InsertarHistorialResultado(DatosNodoHistoria datos)
        {
            NodoHistorial nodo, padre;
            int i;
            padre = nodo = this.nodoentrada;
            while (nodo != null)
            {
                padre = nodo;
                i = 0;
                while (i < nodo.GetClavesUsadas() && nodo.Datos[i].GetResultado().CompareTo(datos.GetResultado()) < 0)
                {
                    i++;
                }
                if (nodo.Datos[i] != null && nodo.Datos[i].GetResultado() == datos.GetResultado() && i < nodo.GetClavesUsadas())
                {
                    InsertarHistorialNumerodetiro(datos);
                    return true;
                }
                else
                {
                    nodo = nodo.Ramas[i];
                }
            }
            nodo = padre;
            InsertarHistorial(datos, nodo, null, null, "resultado");
            numerodetirosfinal++;
            return true;
        }

        public bool InsertarHistorialUnidadDan(DatosNodoHistoria datos)
        {
            NodoHistorial nodo, padre;
            int i;
            padre = nodo = this.nodoentrada;
            while (nodo != null)
            {
                padre = nodo;
                i = 0;
                while(i < nodo.GetClavesUsadas() && nodo.Datos[i].GetTipoUnidadesDan().CompareTo(datos.GetTipoUnidadesDan()) < 0)
                {
                    i++;
                }
                if (nodo.Datos[i] != null && nodo.Datos[i].GetTipoUnidadesDan() == datos.GetTipoUnidadesDan() && i < nodo.GetClavesUsadas())
                {
                    InsertarHistorialNumerodetiro(datos);
                    return true;
                }
                else
                {
                    nodo = nodo.Ramas[i];
                }
            }
            nodo = padre;
            InsertarHistorial(datos, nodo, null, null, "tipodeunidad");
            numerodetirosfinal++;
            return true;
        }

        public bool InsertarHistorialEmisor(DatosNodoHistoria datos)
        {
            NodoHistorial nodo, padre;
            int i;
            padre = nodo = this.nodoentrada;
            while (nodo != null)
            {
                padre = nodo;
                i = 0;
                while (i < nodo.GetClavesUsadas() && nodo.Datos[i].GetEmisor().CompareTo(datos.GetEmisor()) < 0)
                {
                    i++;
                }
                if (nodo.Datos[i] != null && nodo.Datos[i].GetEmisor() == datos.GetEmisor() && i < nodo.GetClavesUsadas())
                {
                    InsertarHistorialNumerodetiro(datos);
                    return true;
                }
                else
                {
                    nodo = nodo.Ramas[i];
                }
            }
            nodo = padre;
            InsertarHistorial(datos, nodo, null, null, "emisor");
            numerodetirosfinal++;
            return true;
        }

        public bool InsertarHistorialReceptor(DatosNodoHistoria datos)
        {
            NodoHistorial nodo, padre;
            int i;
            padre = nodo = this.nodoentrada;
            while (nodo != null)
            {
                padre = nodo;
                i = 0;
                while (i < nodo.GetClavesUsadas() && nodo.Datos[i].GetReceptor().CompareTo(datos.GetReceptor()) < 0)
                {
                    i++;
                }
                if (nodo.Datos[i] != null && nodo.Datos[i].GetReceptor() == datos.GetReceptor() && i < nodo.GetClavesUsadas())
                {
                    InsertarHistorialNumerodetiro(datos);
                    return true;
                }
                else
                {
                    nodo = nodo.Ramas[i];
                }
            }
            nodo = padre;
            InsertarHistorial(datos, nodo, null, null, "receptor");
            numerodetirosfinal++;
            return true;
        }

        public bool InsertarHistorialFecha(DatosNodoHistoria datos)
        {
            NodoHistorial nodo, padre;
            int i;
            padre = nodo = this.nodoentrada;
            while (nodo != null)
            {
                padre = nodo;
                i = 0;
                while (i < nodo.GetClavesUsadas() && nodo.Datos[i].GetFecha() < datos.GetFecha())
                {
                    i++;
                }
                if (nodo.Datos[i] != null && nodo.Datos[i].GetFecha() == datos.GetFecha() && i < nodo.GetClavesUsadas())
                {
                    InsertarHistorialNumerodetiro(datos);
                    return true;
                }
                else
                {
                    nodo = nodo.Ramas[i];
                }
            }
            nodo = padre;
            InsertarHistorial(datos, nodo, null, null, "fecha");
            numerodetirosfinal++;
            return true;
        }

        public bool InsertarHistorialTiempo(DatosNodoHistoria datos)
        {
            NodoHistorial nodo, padre;
            int i;
            padre = nodo = this.nodoentrada;
            while (nodo != null)
            {
                padre = nodo;
                i = 0;
                while(i<nodo.GetClavesUsadas() && nodo.Datos[i].GetTiempo() < datos.GetTiempo())
                {
                    i++;
                }
                if (nodo.Datos[i] != null && nodo.Datos[i].GetTiempo() == datos.GetTiempo() && i < nodo.GetClavesUsadas())
                {
                    InsertarHistorialNumerodetiro(datos);
                    return true;
                }
                else
                {
                    nodo = nodo.Ramas[i];
                }
            }
            nodo = padre;
            InsertarHistorial(datos, nodo, null, null, "tiempo");
            numerodetirosfinal++;
            return true;
        }

        public void InsertarHistorialNumerodetiro(DatosNodoHistoria datos)
        {
            NodoHistorial nodo, padre;
            int i;
            padre = nodo = this.nodoentrada;
            while (nodo != null)
            {
                padre = nodo;
                i = 0;
                while (i < nodo.GetClavesUsadas() && (nodo.Datos[i].GetNumerodeataque() < datos.GetNumerodeataque()))
                {
                    i++;
                }
                nodo = nodo.Ramas[i]; 
            }
            nodo = padre;
            InsertarHistorial(datos, nodo, null, null, "numerodetiro");
            numerodetirosfinal++;
        }

        private void InsertarHistorial(DatosNodoHistoria datos, NodoHistorial nodo, NodoHistorial hijo1, NodoHistorial hijo2, string forma)
        {
            NodoHistorial padre, nuevo;
            int i, j;
            bool salir = false;
            do
            {
                if (nodo == null)
                {
                    nodo = new NodoHistorial(index);
                    nodo.SetClavesUsadas(0);
                    nodo.SetPadre(null);
                    nodoentrada = nodo;
                }
                padre = nodo.GetPadre();
                if (nodo.GetClavesUsadas() == index)
                {
                    nuevo = new NodoHistorial(index);
                    i = 0;
                    if (forma == "coordenadax")
                    {
                        while (nodo.Datos[i] != null && nodo.Datos[i].GetCoordenadaX().CompareTo(datos.GetCoordenadaX()) < 0 && i < index)
                        {
                            listadatos[i] = nodo.Datos[i];
                            listaramas[i] = nodo.Ramas[i];
                            i++;
                        }
                    }
                    else if (forma == "coordenaday")
                    {
                        while (nodo.Datos[i] != null && nodo.Datos[i].GetCoordenadaY().CompareTo(datos.GetCoordenadaY()) < 0 && i < index)
                        {
                            listadatos[i] = nodo.Datos[i];
                            listaramas[i] = nodo.Ramas[i];
                            i++;
                        }
                    }
                    else if (forma == "unidadatacante")
                    {
                        while (nodo.Datos[i] != null && nodo.Datos[i].GetUnidadatacante().CompareTo(datos.GetUnidadatacante()) < 0 && i < index)
                        {
                            listadatos[i] = nodo.Datos[i];
                            listaramas[i] = nodo.Ramas[i];
                            i++;
                        }
                    }
                    else if (forma == "resultado")
                    {
                        while (nodo.Datos[i] != null && nodo.Datos[i].GetResultado().CompareTo(datos.GetResultado()) < 0 && i < index)
                        {
                            listadatos[i] = nodo.Datos[i];
                            listaramas[i] = nodo.Ramas[i];
                            i++;
                        }
                    }
                    else if (forma == "tipodeunidad")
                    {
                        while (nodo.Datos[i] != null && nodo.Datos[i].GetTipoUnidadesDan().CompareTo(datos.GetTipoUnidadesDan()) < 0 && i < index)
                        {
                            listadatos[i] = nodo.Datos[i];
                            listaramas[i] = nodo.Ramas[i];
                            i++;
                        }
                    }
                    else if (forma == "emisor")
                    {
                        while (nodo.Datos[i] != null && nodo.Datos[i].GetEmisor().CompareTo(datos.GetEmisor()) < 0 && i < index)
                        {
                            listadatos[i] = nodo.Datos[i];
                            listaramas[i] = nodo.Ramas[i];
                            i++;
                        }
                    }
                    else if (forma == "receptor")
                    {
                        while (nodo.Datos[i] != null && nodo.Datos[i].GetReceptor().CompareTo(datos.GetReceptor()) < 0 && i < index)
                        {
                            listadatos[i] = nodo.Datos[i];
                            listaramas[i] = nodo.Ramas[i];
                            i++;
                        }
                    }
                    else if (forma == "fecha")
                    {
                        while (nodo.Datos[i] != null && nodo.Datos[i].GetFecha() < datos.GetFecha() && i < index)
                        {
                            listadatos[i] = nodo.Datos[i];
                            listaramas[i] = nodo.Ramas[i];
                            i++;
                        }
                    }
                    else if (forma == "tiempo")
                    {
                        while (nodo.Datos[i] != null && nodo.Datos[i].GetTiempo() < datos.GetTiempo() && i < index)
                        {
                            listadatos[i] = nodo.Datos[i];
                            listaramas[i] = nodo.Ramas[i];
                            i++;
                        }
                    }
                    else if (forma == "numerodetiro")
                    {
                        while (nodo.Datos[i] != null && nodo.Datos[i].GetNumerodeataque() < datos.GetNumerodeataque() && i < index)
                        {
                            listadatos[i] = nodo.Datos[i];
                            listaramas[i] = nodo.Ramas[i];
                            i++;
                        }
                    }
                    listadatos[i] = datos;
                    listaramas[i] = hijo1;
                    listaramas[i + 1] = hijo2;
                    while (i < index)
                    {
                        listadatos[i + 1] = nodo.Datos[i];
                        listaramas[i + 2] = nodo.Ramas[i];
                        i++;
                    }

                    nodo.SetClavesUsadas(index / 2);
                    for (j = 0; j < index / 2; j++)
                    {
                        nodo.Datos[j] = listadatos[j];
                        nodo.Ramas[j] = listaramas[j];
                    }
                    for (j = index / 2; j < index; j++)
                    {
                        nodo.Datos[j] = null;
                        nodo.Ramas[j] = null;
                    }
                    nodo.Ramas[j] = null;
                    nodo.Ramas[nodo.GetClavesUsadas()] = listaramas[nodo.GetClavesUsadas()];
                    nuevo.SetClavesUsadas(index - nodo.GetClavesUsadas());
                    for (j = 0; j < nuevo.GetClavesUsadas(); j++)
                    {
                        nuevo.Datos[j] = listadatos[j + (index / 2) + 1];
                        nuevo.Ramas[j] = listaramas[j + (index / 2) + 1];
                    }
                    nuevo.Ramas[nuevo.GetClavesUsadas()] = listaramas[index + 1];
                    for (j = 0; j <= nodo.GetClavesUsadas(); j++)
                    {
                        if (nodo.Ramas[j] != null)
                        {
                            nodo.Ramas[j].SetPadre(nodo);
                        }
                    }
                    for (j = 0; j <= nodo.GetClavesUsadas(); j++)
                    {
                        if (nuevo.Ramas[j] != null)
                        {
                            nuevo.Ramas[j].SetPadre(nuevo);
                        }
                    }
                    datos = listadatos[index / 2];
                    hijo1 = nodo;
                    hijo2 = nuevo;
                    nodo = padre;
                }
                else
                {
                    i = 0;
                    if (nodo.GetClavesUsadas() > 0)
                    {
                        if (forma == "coordenadax")
                        {
                            while (nodo.Datos[i] != null && nodo.Datos[i].GetCoordenadaX().CompareTo(datos.GetCoordenadaX()) < 0 && i < index)
                            {
                                i++;
                            }
                        }
                        else if (forma == "coordenaday")
                        {
                            while (nodo.Datos[i] != null && nodo.Datos[i].GetCoordenadaY().CompareTo(datos.GetCoordenadaY()) < 0 && i < index)
                            {
                                i++;
                            }
                        }
                        else if (forma == "unidadatacante")
                        {
                            while (nodo.Datos[i] != null && nodo.Datos[i].GetUnidadatacante().CompareTo(datos.GetUnidadatacante()) < 0 && i < index)
                            {
                                i++;
                            }
                        }
                        else if (forma == "resultado")
                        {
                            while (nodo.Datos[i] != null && nodo.Datos[i].GetResultado().CompareTo(datos.GetResultado()) < 0 && i < index)
                            {
                                i++;
                            }
                        }
                        else if (forma == "tipodeunidad")
                        {
                            while (nodo.Datos[i] != null && nodo.Datos[i].GetTipoUnidadesDan().CompareTo(datos.GetTipoUnidadesDan()) < 0 && i < index)
                            {
                                i++;
                            }
                        }
                        else if (forma == "emisor")
                        {
                            while (nodo.Datos[i] != null && nodo.Datos[i].GetEmisor().CompareTo(datos.GetEmisor()) < 0 && i < index)
                            {
                                i++;
                            }
                        }
                        else if (forma == "receptor")
                        {
                            while (nodo.Datos[i] != null && nodo.Datos[i].GetReceptor().CompareTo(datos.GetReceptor()) < 0 && i < index)
                            {
                                i++;
                            }
                        }
                        else if (forma == "fecha")
                        {
                            while (nodo.Datos[i] != null && nodo.Datos[i].GetFecha() < datos.GetFecha() && i < index)
                            {
                                i++;
                            }
                        }
                        else if (forma == "tiempo")
                        {
                            while (nodo.Datos[i] != null && nodo.Datos[i].GetTiempo() < datos.GetTiempo() && i < index)
                            {
                                i++;
                            }
                        }
                        else if (forma == "numerodetiro")
                        {
                            while (nodo.Datos[i] != null && nodo.Datos[i].GetNumerodeataque() < datos.GetNumerodeataque() && i < index)
                            {
                                i++;
                            }
                        }
                        for (j = nodo.GetClavesUsadas(); j > i; j--)
                        {
                            nodo.Datos[j] = nodo.Datos[j-1];
                        }
                        for (j = nodo.GetClavesUsadas() + 1; j > i; j--)
                        {
                            nodo.Ramas[j] = nodo.Ramas[j - 1];
                        }
                    }
                    int a = nodo.GetClavesUsadas();
                    nodo.clavesusadas++;
                    nodo.Datos[i] = datos;
                    nodo.Ramas[i] = hijo1;
                    nodo.Ramas[i + 1] = hijo2;
                    if (hijo1 != null)
                    {
                        hijo1.SetPadre(nodo);
                    }
                    if (hijo2 != null)
                    {
                        hijo2.SetPadre(nodo);
                    }
                    salir = true;
                }
            } while (!salir);
        }

        public void Mostrar(NodoHistorial entrada)
        {
            int i;
            if (entrada == null)
            {
                return;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("[");
                for (i = 0; i < entrada.GetClavesUsadas() - 1; i++)
                {
                    System.Diagnostics.Debug.WriteLine(entrada.Datos[i].GetCoordenadaX() + "," + entrada.Datos[i].GetCoordenadaY() + "," + entrada.Datos[i].GetNumerodeataque());
                }
                System.Diagnostics.Debug.WriteLine("]");
                if (entrada.GetPadre() != null)
                {
                    //System.Diagnostics.Debug.WriteLine("[" + entrada.GetPadre().Datos[i].GetCoordenadaX() + "," + entrada.GetPadre().Datos[i].GetCoordenadaY() + "," + entrada.GetPadre().Datos[i].GetNumerodeataque() + "padre de: " + entrada.Datos[i].GetCoordenadaX() + "," + entrada.Datos[i].GetCoordenadaY() + "," + entrada.Datos[i].GetNumerodeataque());
                }
                for(i = 0; i<=entrada.GetClavesUsadas(); i++)
                {
                    Mostrar(entrada.Ramas[i]);
                }
            }
        }
    }
}