#ifndef GRAFICAR_H
#define GRAFICAR_H

#include "colaaviones.h"
#include "stdio.h"
#include "stdlib.h"
#include "QString"
#include "listamantenimiento.h"
#include "colaesperamantenimiento.h"
#include "listacircularmaletas.h"
#include <QString>

class Graficar
{
public:
    Graficar(coladoblellegada *cola, listamantenimiento *lista, Colaesperamantenimiento *colamantenimiento, ColaPasajeros *colapasa, ListaCircularMaleta *listacircular);

private:
    FILE *grafica;
    void GraficarColaLlegada(coladoblellegada *cola);
    void GraficarListaPuestosMantenimiento(listamantenimiento *lista);
    void GraficarColaMantenimiento(Colaesperamantenimiento *colamantenimiento);
    void GraficarColaPasajeros(ColaPasajeros *colapasa);
    void GraficarListaCircularMaletas(ListaCircularMaleta *lista);
};

#endif // GRAFICAR_H
