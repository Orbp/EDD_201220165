#ifndef COLAESPERAMANTENIMIENTO_H
#define COLAESPERAMANTENIMIENTO_H

#include <stdio.h>
#include <stdlib.h>

typedef struct nodocolaesperamantenimiento
{
    int idavion;
    int numturnos;
    nodocolaesperamantenimiento *siguiente;
}Nodocolaesperamantenimiento;

typedef struct colaesperamantenimiento
{
    Nodocolaesperamantenimiento *primero;
    Nodocolaesperamantenimiento *ultimo;
}Colaesperamantenimiento;

void Insertarcolamantenimiento(Colaesperamantenimiento *cola, int idavion, int numturnos);

#endif // COLAESPERAMANTENIMIENTO_H
