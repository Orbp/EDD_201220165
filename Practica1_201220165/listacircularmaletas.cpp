#include "listacircularmaletas.h"

void InsertarMaleta(ListaCircularMaleta *lista, int id, int idpas)
{
    NodoCircularMaleta *nuevo = (NodoCircularMaleta *)malloc(sizeof(NodoCircularMaleta));
    nuevo->id = id;
    nuevo->idpas = idpas;
    nuevo->siguiente = NULL;
    nuevo->anterior = NULL;
    if(lista->primero == NULL){
        lista->primero = nuevo;
        lista->primero->siguiente = lista->primero;
        lista->primero->anterior = lista->primero;
    }else{
        nuevo->siguiente = lista->primero;
        nuevo->anterior = lista->primero->anterior;
        lista->primero->anterior->siguiente = nuevo;
        lista->primero->anterior = nuevo;
    }
}

void EliminarMaleta(ListaCircularMaleta *lista, int idpas)
{
    if(lista->primero != NULL){
        NodoCircularMaleta *aux = lista->primero->siguiente;
        while(aux != lista->primero){
            if(aux->idpas == idpas){
                aux->anterior->siguiente = aux->siguiente;
                aux->siguiente->anterior = aux->anterior;
                aux->siguiente = NULL;
                aux->anterior = NULL;
                free(aux);
            }
            aux = aux->siguiente;
        }
        if(aux->idpas == idpas)
        {
            if(lista->primero != lista->primero->siguiente){
                lista->primero->siguiente->anterior = lista->primero->anterior;
                lista->primero->anterior->siguiente = lista->primero->siguiente;
                free(aux);
            }
            else
            {
                lista->primero = NULL;
                lista->primero->siguiente = NULL;
                free(aux);
            }
        }
    }
}

int TamaMaleta(ListaCircularMaleta *lista)
{
    int cont = 0;
    if(lista->primero != NULL){
        NodoCircularMaleta *aux = lista->primero;
        cont++;
        aux = aux->siguiente;
        while(aux != lista->primero){
            cont++;
            aux = aux->siguiente;
        }
    }
    return cont;
}
