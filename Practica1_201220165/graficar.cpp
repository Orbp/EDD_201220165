#include "graficar.h"

Graficar::Graficar(coladoblellegada *cola)
{
    grafica = fopen("Grafica.dot", "w+");
    fprintf(grafica, "digraph{ \n rankdir = LR; \n node[shape = record];");
    fprintf(grafica, "subgraph clusterAeropuerto{\n");
    fprintf(grafica, "label = \"Aeropuerto\";\n");
    GraficarColaLlegada(cola);
    fprintf(grafica, "}\n");
    fprintf(grafica, "}\n");
    fclose(grafica);
    system("dot -Tjpg Grafica.dot -o Grafica.jpg");
}

void Graficar::GraficarColaLlegada(coladoblellegada *cola){
    fprintf(grafica, "subgraph clusterAviones{\n");
    fprintf(grafica, "label = \" Aviones \"");
    if(cola->primero != NULL){
        NodoColaAvion *aux = cola->primero;
        int cont = 0;
        while(aux != NULL){
            QString tipo;
            if(aux->tama == 0){
                tipo = "Pequeño";
            }else if(aux->tama == 1){
                tipo = "Mediano";
            }else{
                tipo = "Grande";
            }
            fprintf(grafica, "nca%d[label = \"Avion %d\\nTipo %s\\nPasajeros %d\"];\n", cont, aux->id, tipo.toStdString().c_str(), aux->pasajeros);
            cont++;
            aux = aux->siguiente;
        }
        cont = 0;
        aux = cola->primero;
        while(aux != NULL && cola->primero != cola->ultimo){
            if(aux == cola->primero && aux->siguiente != NULL){
                fprintf(grafica, "nca%d->nca%d", cont, cont+1);
            }else if(aux == cola->ultimo && aux->anterior != NULL){
                fprintf(grafica, "nca%d->nca%d", cont, cont-1);
            }else{
                fprintf(grafica, "nca%d->nca%d\n", cont, cont+1);
                fprintf(grafica, "nca%d->nca%d", cont, cont-1);
            }
            fprintf(grafica, "\n");
            aux = aux->siguiente;
            cont++;
        }
    }
    fprintf(grafica, "}\n");
}
