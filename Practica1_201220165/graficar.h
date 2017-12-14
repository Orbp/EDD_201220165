#ifndef GRAFICAR_H
#define GRAFICAR_H

#include "colaaviones.h"
#include "stdio.h"
#include "stdlib.h"
#include "QString"
#include "listamantenimiento.h"
#include "colaesperamantenimiento.h"

class Graficar
{
public:
    Graficar(coladoblellegada *cola, listamantenimiento *lista, Colaesperamantenimiento *colamantenimiento);

private:
    FILE *grafica;
    void GraficarColaLlegada(coladoblellegada *cola);
    void GraficarListaPuestosMantenimiento(listamantenimiento *lista);
    void GraficarColaMantenimiento(Colaesperamantenimiento *colamantenimiento);
};

#endif // GRAFICAR_H
