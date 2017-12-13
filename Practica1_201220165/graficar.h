#ifndef GRAFICAR_H
#define GRAFICAR_H

#include "colaaviones.h"
#include "stdio.h"
#include "stdlib.h"
#include "QString"
#include "listamantenimiento.h"

class Graficar
{
public:
    Graficar(coladoblellegada *cola, listamantenimiento *lista);

private:
    FILE *grafica;
    void GraficarColaLlegada(coladoblellegada *cola);
    void GraficarListaPuestosMantenimiento(listamantenimiento *lista);
};

#endif // GRAFICAR_H
