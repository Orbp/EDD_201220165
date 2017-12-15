#ifndef PASAJEROS_H
#define PASAJEROS_H

#include <stdio.h>
#include <stdlib.h>
#include "listacircularmaletas.h"
#include <time.h>

typedef struct NodoColaPasajeros
{
    int id;
    int nummaletas;
    int numturnos;
    int numdoc;
    NodoColaPasajeros *siguiente;
}nodocolapasajeros;

typedef struct colapasajeros
{
    nodocolapasajeros *primero;
    nodocolapasajeros *ultimo;
}ColaPasajeros;

void InsertarColaPasajeros(ColaPasajeros *cola, int id, ListaCircularMaleta *lista);

#endif // PASAJEROS_H
