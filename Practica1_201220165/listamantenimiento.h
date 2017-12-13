#ifndef LISTAMANTENIMIENTO_H
#define LISTAMANTENIMIENTO_H

#include <stdio.h>
#include <stdlib.h>

typedef struct NodoMantenimiento
{
    int idestacion;
    bool estado;
    int idavion;
    int turnosrestantes;
    struct NodoMantenimiento *siguiente;
}nodomantenimiento;

typedef struct ListaMantenimiento
{
    nodomantenimiento *primero;
    nodomantenimiento *ultimo;
}listamantenimiento;

void InsertarListaMantenimiento(listamantenimiento *lista, int valor);
bool InsertarAvion(listamantenimiento *lista, int idavion, int turnos);
#endif // LISTAMANTENIMIENTO_H
