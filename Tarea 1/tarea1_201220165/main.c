#include <stdio.h>
#include <stdlib.h>

typedef struct nodo
{
    int valor;
    struct nodo *siguiente;
    struct nodo *anterior;
}Nodo;

typedef struct Lista
{
    Nodo *primero;
    Nodo *ultimo;
}lista;

void Insertar(lista *list, int valor){
    Nodo *nuevo = malloc(sizeof(Nodo));
    nuevo->valor = valor;
    nuevo->siguiente = NULL;
    nuevo->anterior = NULL;
    if(list->primero == NULL){
        list->primero = nuevo;
        list->ultimo = nuevo;
    }else{
        list->ultimo->siguiente = nuevo;
        nuevo->anterior = list->ultimo;
        list->ultimo = nuevo;
    }
}

void Mostrar(lista *list){
    if(list->primero == NULL){
        printf("La lista se encuentra vacia\n");
    }else{
        printf("Lista guardada\n");
        Nodo *aux = list->primero;
        while(aux != list->ultimo){
            printf("valor: %d\n", aux->valor);
            aux = aux->siguiente;
        }
        printf("valor: %d\n", aux->valor);
    }
}

void Eliminar(lista *list, int valor){
    if(list->primero != NULL){
        Nodo *aux = list->primero;
        if(list->primero == list->ultimo && list->primero->valor == valor){
            list->primero = NULL;
            list->ultimo = NULL;
            free(aux);
            printf("Elemento eliminado\n");
        }else{

            while(aux->valor != valor && aux != list->ultimo){
                aux = aux->siguiente;
            }
            if(aux == list->primero && aux->valor == valor){
                list->primero = list->primero->siguiente;
                list->primero->anterior = NULL;
                free(aux);
                printf("Elemento eliminado\n");
            }else if(aux == list->ultimo && aux->valor == valor){
                list->ultimo = list->ultimo->anterior;
                list->ultimo->siguiente = NULL;
                free(aux);
                printf("Elemento eliminado\n");
            }else if(aux && aux->valor == valor){
                Nodo *auxant = aux->anterior;
                Nodo *auxsig = aux->siguiente;
                auxant->siguiente = auxsig;
                auxsig->anterior =auxant;
                free(aux);
                printf("Elemento eliminado\n");
            }else{
                printf("El valor no existe en la lista\n");
            }
        }
    }else{
        printf("La lista se encuentra vacia\n");
    }
}

int main()
{
    int opcion = 0;
    int v;
    lista *l = malloc(sizeof(lista));
    l->primero = NULL;
    l->ultimo = NULL;
    do{
        printf("Seleccione una opcion\n");
        printf("1. Insertar\n");
        printf("2. Mostrar\n");
        printf("3. Eliminar\n");
        scanf("%d", &opcion);
        if(opcion == 1){
            printf("Ingrese el numero a insertar: \n");
            scanf("%d", &v);
            Insertar(l, v);
        }else if(opcion == 2){
            Mostrar(l);
        }else{
            printf("Ingrese el numero a eliminar: \n");
            scanf("%d", &v);
            Eliminar(l, v);
        }
    }while(opcion < 4);
    return 0;
}
