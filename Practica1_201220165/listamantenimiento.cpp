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

bool InsertarAvion(listamantenimiento *lista, int idavion, int turnos){
    if(lista->primero != NULL){
        nodomantenimiento *aux = lista->primero;
        while(aux != NULL && aux->estado != false){
            aux = aux->siguiente;
        }
        if(aux != NULL){
            aux->idavion = idavion;
            aux->turnosrestantes = turnos;
            aux->estado = true;
            return true;
        }
    }
    return false;
}

void EliminarAvion(listamantenimiento *lista, Colaesperamantenimiento *cola){
    if(lista->primero != NULL){
        nodomantenimiento *aux = lista->primero;
        while(aux != NULL){
            if(aux->estado == true){
                aux->turnosrestantes--;
            }
            aux = aux->siguiente;
        }
        aux = lista->primero;
        while(aux != NULL){
            if(aux->turnosrestantes == 0){
                aux->estado = false;
                aux->idavion = 0;
                Nodocolaesperamantenimiento *aux1 = Eliminarcolamantenimiento(cola);
                if(aux1 != NULL){
                    InsertarAvion(lista, aux1->idavion, aux1->numturnos);
                }
            }
            aux = aux->siguiente;
        }
    }
}
