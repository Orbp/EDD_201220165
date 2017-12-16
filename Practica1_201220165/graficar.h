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
#include "listaescritorios.h"

class Graficar
{
public:
    Graficar(coladoblellegada *cola, listamantenimiento *lista, Colaesperamantenimiento *colamantenimiento, ColaPasajeros *colapasa, ListaCircularMaleta *listacircular, ListaDobleEscritorios *listaesc);

private:
    FILE *grafica;
    void GraficarColaLlegada(coladoblellegada *cola);
    void GraficarListaPuestosMantenimiento(listamantenimiento *lista);
    void GraficarColaMantenimiento(Colaesperamantenimiento *colamantenimiento);
    void GraficarColaPasajeros(ColaPasajeros *colapasa);
    void GraficarListaCircularMaletas(ListaCircularMaleta *lista);
    void GraficarListaEscritorios(ListaDobleEscritorios *lista);
};

#endif // GRAFICAR_H
