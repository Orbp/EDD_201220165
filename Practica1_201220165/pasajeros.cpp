#include "pasajeros.h"

void InsertarColaPasajeros(ColaPasajeros *cola, int id, ListaCircularMaleta *lista){
    //srand(time(NULL));
    nodocolapasajeros *nuevo = (nodocolapasajeros *)malloc(sizeof(nodocolapasajeros));
    nuevo->id = id;
    int nummal;
    int numregis;
    int cantdoc;
    nummal = rand() % 4 + 1;
    cantdoc = rand() % 10 + 1;
    numregis = rand() % 4 +1;
    nuevo->numdoc = cantdoc;
    nuevo->nummaletas = nummal;
    nuevo->numturnos = numregis;
    nuevo->siguiente = NULL;
    if(cola->primero == NULL){
        cola->primero = nuevo;
        cola->ultimo = nuevo;
    }else{
        cola->ultimo->siguiente = nuevo;
        cola->ultimo = nuevo;
    }
    int auxmal;
    if(lista->primero == NULL)
    {
        auxmal = 1;
    }else{
        auxmal = lista->primero->anterior->id;
        auxmal++;
    }

    for(int i = auxmal; i < auxmal + nummal; i++){
        InsertarMaleta(lista, i, id);
    }
}
