#include "listaescritorios.h"

void InsertarListaEscritorios(ListaDobleEscritorios *lista, char id){
    NodoEscritorios *nuevo = (NodoEscritorios *)malloc(sizeof(NodoEscritorios));
    nuevo->anterior = NULL;
    nuevo->siguiente = NULL;
    nuevo->id = id;
    nuevo->idpas = 0;
    nuevo->numturnos = 0;
    nuevo->numdoc = 0;
    if(lista->primero == NULL){
        lista->primero = nuevo;
    }else{
        if(id < lista->primero->id){//Insertar al principio
            nuevo->siguiente = lista->primero;
            lista->primero->anterior = nuevo;
            lista->primero = nuevo;
        }else
        {
            NodoEscritorios *aux = lista->primero;
            while(aux->siguiente != NULL){
                if(aux->siguiente->id > id && aux->id < id){
                    break;
                }
                aux = aux->siguiente;
            }
            if(aux->siguiente == NULL){//Insertar al final
                aux->siguiente = nuevo;
                nuevo->anterior = aux;
            }else{//Inserta en medio
                nuevo->siguiente = aux->siguiente;
                nuevo->anterior = aux;
                aux->siguiente->anterior = nuevo;
                aux->siguiente = nuevo;
            }
        }
    }
}

void Mostrar(ListaDobleEscritorios *lista){
    NodoEscritorios *aux = lista->primero;
    while(aux != NULL){
        printf("Escritorio %c", aux->id);
        aux = aux->siguiente;
    }
}

void ImprimirListaConsola(QTextEdit *editor, ListaDobleEscritorios *lista)
{
    if(lista->primero != NULL)
    {
        NodoEscritorios *aux = lista->primero;
        editor->append("----------ESCRITORIOS----------");
        while(aux != NULL)
        {
            editor->append("Escritorio " + QString(aux->id));
            if(aux->idpas == 0)
            {
                editor->append("Pasajero atendido: ninguno");
            }else{
                editor->append("Pasajero atendido: " + QString::number(aux->idpas));
            }
            editor->append("Turnos restantes: " + QString::number(aux->numturnos));
            editor->append("Cantidad de documentos: " + QString::number(aux->numdoc));
            aux = aux->siguiente;
        }
    }
}

void InsertarPasajeroEscritorio(ListaDobleEscritorios *lista, int idpas, int numturnos, int numdoc)
{

}
