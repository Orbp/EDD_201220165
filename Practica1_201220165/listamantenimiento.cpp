#include "listamantenimiento.h"

void InsertarListaMantenimiento(listamantenimiento *lista, int valor){
    nodomantenimiento *nuevo = (nodomantenimiento *)malloc(sizeof(nodomantenimiento));
    nuevo->estado = false;
    nuevo->idavion = 0;
    nuevo->idestacion = valor;
    nuevo->siguiente = NULL;
    nuevo->turnosrestantes = 0;
    if(lista->primero == NULL){
        lista->primero = nuevo;
        lista->ultimo = nuevo;
    }else{
        lista->ultimo->siguiente = nuevo;
        lista->ultimo = nuevo;
    }
}
