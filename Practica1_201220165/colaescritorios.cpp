#include "colaescritorios.h"

void InsertarColaEscritorios(ColaEscritorios *cola, int id, int turnos, int doc)
{
    NodoColaEscritorios *nuevo = (NodoColaEscritorios *)malloc(sizeof(NodoColaEscritorios));
    nuevo->idpas = id;
    nuevo->numdoc = doc;
    nuevo->numtur = turnos;
    nuevo->siguiente = NULL;
    if(cola->primero != NULL)
    {
        cola->primero = nuevo;
        cola->ultimo = nuevo;
    }
    else
    {
        cola->ultimo->siguiente = nuevo;
        cola->ultimo = nuevo;
    }
}
