#include "colaesperamantenimiento.h"

void Insertarcolamantenimiento(Colaesperamantenimiento *cola, int idavion, int numturnos){
    Nodocolaesperamantenimiento *nuevo = (Nodocolaesperamantenimiento *)malloc(sizeof(Nodocolaesperamantenimiento));
    nuevo->idavion = idavion;
    nuevo->numturnos = numturnos;
    nuevo->siguiente = NULL;
    if(cola->primero == NULL){
        cola->primero = nuevo;
        cola->ultimo = nuevo;
    }else{
        cola->ultimo->siguiente = nuevo;
        cola->ultimo = nuevo;
    }
}
