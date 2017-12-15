#ifndef LISTACIRCULARMALETAS_H
#define LISTACIRCULARMALETAS_H

#include <stdlib.h>
#include <stdio.h>

typedef struct nodocircularmaleta
{
    int id;
    int idpas;
    nodocircularmaleta *siguiente;
    nodocircularmaleta *anterior;
}NodoCircularMaleta;

typedef struct listacircularmaleta
{
    NodoCircularMaleta *primero;
}ListaCircularMaleta;

void InsertarMaleta(ListaCircularMaleta *lista, int id, int idpas);
void EliminarMaleta(ListaCircularMaleta *lista, int idpas);
int TamaMaleta(ListaCircularMaleta *lista);

#endif // LISTACIRCULARMALETAS_H
