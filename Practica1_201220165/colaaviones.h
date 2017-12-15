#ifndef COLAAVIONES_H
#define COLAAVIONES_H

#include <stdio.h>
#include <stdlib.h>
#include "iostream"
#include "listamantenimiento.h"
#include "colaesperamantenimiento.h"
#include "pasajeros.h"

typedef struct nodocolaavion{
    int tama;
    int pasajeros;
    int turnosdesabordaje;
    int id;
    int turnosdemantenimiento;
    struct nodocolaavion *siguiente;
    struct nodocolaavion *anterior;
}NodoColaAvion;

typedef struct ColaDobleLlegada
{
    NodoColaAvion *primero;
    NodoColaAvion *ultimo;
}coladoblellegada;


void InsertarColaLlegada(coladoblellegada *cola, int pid, int ptama, int ppasa, int pturnosdes, int pturnosman);
void EliminarColaLlegada(coladoblellegada *cola, listamantenimiento *lista, Colaesperamantenimiento *colamantenimiento, ColaPasajeros *colapas, int id, ListaCircularMaleta *listamal);
void MostrarColaLlegada(coladoblellegada *cola);
#endif // COLAAVIONES_H
