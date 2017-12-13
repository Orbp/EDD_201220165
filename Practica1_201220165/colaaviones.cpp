#include "colaaviones.h"

void InsertarColaLlegada(coladoblellegada *cola, int pid, int ptama, int ppasa, int pturnosdes, int pturnosman){
    NodoColaAvion *nuevo = (NodoColaAvion *)malloc(sizeof(NodoColaAvion));
    nuevo->siguiente = NULL;
    nuevo->anterior = NULL;
    nuevo->id = pid;
    nuevo->tama = ptama;
    nuevo->pasajeros = ppasa;
    nuevo->turnosdesabordaje = pturnosdes;
    nuevo->turnosdemantenimiento = pturnosman;
    if(cola->primero == NULL){
        cola->primero = nuevo;
        cola->ultimo = nuevo;
    }else{
        cola->ultimo->siguiente = nuevo;
        nuevo->anterior = cola->ultimo;
        cola->ultimo = nuevo;
    }
}

void EliminarColaLlegada(coladoblellegada *cola){
    if(cola->primero != NULL && cola->primero->siguiente != NULL){
        NodoColaAvion *aux = cola->primero;
        cola->primero = cola->primero->siguiente;
        aux->anterior = NULL;
        aux->siguiente = NULL;
        free(aux);
    }else if(cola->primero != NULL && cola->primero->siguiente == NULL){
        NodoColaAvion *aux = cola->primero;
        cola->primero = NULL;
        cola->ultimo = NULL;
        free(aux);
    }
}

void MostrarColaLlegada(coladoblellegada *cola){
    if(cola->primero != NULL){
        NodoColaAvion *aux = cola->primero;
        while(aux != NULL){
            std::cout<<"Avion "<<aux->id<<", pasajeros "<<aux->pasajeros<<", tama;o "<<aux->tama<<", turnos de mantenimiento "<<aux->turnosdemantenimiento<<", turnos de desabordaje "<<aux->turnosdesabordaje<<std::endl;

            aux = aux->siguiente;
        }
    }
}
