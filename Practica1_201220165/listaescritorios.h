#ifndef LISTAESCRITORIOS_H
#define LISTAESCRITORIOS_H

#include <stdio.h>
#include <stdlib.h>
#include <QTextEdit>
#include "colaescritorios.h"

typedef struct nodoescritorios
{
    char id;
    int idpas;
    int numturnos;
    int numdoc;
    nodoescritorios *siguiente;
    ColaEscritorios *cola;
    //PilaD piladocumentos;
    nodoescritorios *anterior;
}NodoEscritorios;

typedef struct listadobleescritorios
{
    NodoEscritorios *primero;
}ListaDobleEscritorios;

void InsertarListaEscritorios(ListaDobleEscritorios *lista, char id);
void Mostrar(ListaDobleEscritorios *lista);
void ImprimirListaConsola(QTextEdit *editor, ListaDobleEscritorios *lista);
bool InsertarPasajeroEscritorio(int idpas, int numturnos, int numdoc);

#endif // LISTAESCRITORIOS_H
