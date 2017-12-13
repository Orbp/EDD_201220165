#ifndef GRAFICAR_H
#define GRAFICAR_H

#include "colaaviones.h"
#include "stdio.h"
#include "stdlib.h"
#include "QString"

class Graficar
{
public:
    Graficar(coladoblellegada *cola);

private:
    FILE *grafica;
    void GraficarColaLlegada(coladoblellegada *cola);
};

#endif // GRAFICAR_H
