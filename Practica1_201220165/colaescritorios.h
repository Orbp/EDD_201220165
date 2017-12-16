#ifndef COLAESCRITORIOS_H
#define COLAESCRITORIOS_H

#include <stdio.h>
#include <stdlib.h>

typedef struct nodocolaescritorios
{
    int idpas;
    int numtur;
    int numdoc;
    nodocolaescritorios *siguiente;
}NodoColaEscritorios;

typedef struct colaescritorios
{
    NodoColaEscritorios *primero;
    NodoColaEscritorios *ultimo;
}ColaEscritorios;

void InsertarColaEscritorios(ColaEscritorios *cola, int id, int turnos, int doc);
#endif // COLAESCRITORIOS_H
