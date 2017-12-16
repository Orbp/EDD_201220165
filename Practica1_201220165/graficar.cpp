#include "graficar.h"

Graficar::Graficar(coladoblellegada *cola, listamantenimiento *lista, Colaesperamantenimiento *colamentenimiento, ColaPasajeros *colapasa, ListaCircularMaleta *listacircular, ListaDobleEscritorios *listaesc)
{
    grafica = fopen("Grafica.dot", "w+");
    fprintf(grafica, "digraph{ \n node[shape = record];");
    fprintf(grafica, "subgraph clusterAeropuerto{\n");
    fprintf(grafica, "label = \"Aeropuerto\";\n");
    GraficarColaLlegada(cola);
    GraficarListaPuestosMantenimiento(lista);
    GraficarColaMantenimiento(colamentenimiento);
    GraficarColaPasajeros(colapasa);
    GraficarListaCircularMaletas(listacircular);
    GraficarListaEscritorios(listaesc);
    fprintf(grafica, "}\n");
    fprintf(grafica, "}\n");
    fclose(grafica);
    system("dot -Tjpg Grafica.dot -o Grafica.jpg");
}

void Graficar::GraficarColaLlegada(coladoblellegada *cola){
    fprintf(grafica, "subgraph clusterAviones{\nrankdir = BT;\n");
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
            fprintf(grafica, "nca%d[label = \"Avion %d\\nTipo %s\\nPasajeros %d\\nTurnos de mantenimiento %d\"];\n", cont, aux->id, tipo.toStdString().c_str(), aux->pasajeros, aux->turnosdemantenimiento);
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

void Graficar::GraficarListaPuestosMantenimiento(listamantenimiento *lista){
    fprintf(grafica, "subgraph clusterPuestosmantenimiento{\n");
    fprintf(grafica, "label = \" Puestos de Mantenimiento \"");
    int cont = 0;
    if(lista->primero != NULL){
        nodomantenimiento *aux = lista->primero;
        while(aux != NULL){
            fprintf(grafica, "lpm%d[label = \"Estacion %d\\n",cont, aux->idestacion);
            if(aux->estado == false){
                fprintf(grafica, "Estado libre\\n");
            }else{
                fprintf(grafica, "Estado ocupado\\n");
            }
            if(aux->idavion == 0){
                fprintf(grafica, "Avion que esta siendo revisado ninguno\\n");
            }else{
                fprintf(grafica, "Avion que esta siendo revisado %d\\n", aux->idavion);
            }
            fprintf(grafica, "Turnos restantes %d\"];\n", aux->turnosrestantes);
            aux = aux->siguiente;
            cont++;
        }
        aux = lista->primero;
        cont = 0;
        while(aux != NULL)
        {
            if(aux != lista->ultimo)
            {
                fprintf(grafica, "lpm%d->lpm%d\n",cont, cont+1);
            }
            aux = aux->siguiente;
            cont++;
        }
    }
    fprintf(grafica, "}");
}

void Graficar::GraficarColaMantenimiento(Colaesperamantenimiento *colamantenimiento){
    fprintf(grafica, "subgraph clusterColaesperamantenimiento{\n");
    fprintf(grafica, "label = \" Cola de espera para Mantenimiento \"");
    int cont = 0;
    if(colamantenimiento->primero != NULL){
        Nodocolaesperamantenimiento *aux = colamantenimiento->primero;
        while(aux != NULL){
            fprintf(grafica, "cem%d[label = \"Avion %d\\nTurnos que pasara en mantenimiento %d\"]",cont, aux->idavion, aux->numturnos);
            aux = aux->siguiente;
            cont++;
        }
        aux = colamantenimiento->primero;
        cont = 0;
        while(aux != NULL)
        {
            if(aux != colamantenimiento->ultimo)
            {
                fprintf(grafica, "cem%d->cem%d\n",cont, cont+1);
            }
            cont++;
            aux = aux->siguiente;
        }
    }
    fprintf(grafica, "}");

}

void Graficar::GraficarColaPasajeros(ColaPasajeros *colapasa){
    fprintf(grafica, "subgraph clusterColaPasajeros{\n");
    fprintf(grafica, "label = \"Cola de espera para pasajeros \"");
    if(colapasa->primero != NULL){
        nodocolapasajeros *aux = colapasa->primero;
        int cont = 0;
        while(aux != NULL){
            fprintf(grafica, "cp%d[label = \"Pasajero %d\\nMaletas %d\\nDocumentos %d\\nTurnos que pasara en escritorio %d\"];\n", cont, aux->id, aux->nummaletas, aux->numdoc, aux->numturnos);
            aux = aux->siguiente;
            cont++;
        }
        cont = 0;
        aux = colapasa->primero;
        while(aux->siguiente != NULL){
            fprintf(grafica, "cp%d->cp%d\n", cont, cont+1);
            cont++;
            aux = aux->siguiente;
        }
    }
    fprintf(grafica, "}");
}

void Graficar::GraficarListaCircularMaletas(ListaCircularMaleta *lista){
    fprintf(grafica, "subgraph clusterListaMaletas{\n");
    fprintf(grafica, "label = \"Maletas de pasajeros\"\n");
    if(lista->primero != NULL){
        int cont = 0;
        NodoCircularMaleta *aux = lista->primero;
        //fprintf(grafica, "{rank = same ");
        fprintf(grafica, "lcm%d[label = \"Maleta %d\\nPasajero %d\"]; ", cont,aux->id, aux->idpas);
        aux = aux->siguiente;
        cont++;
        int tama = TamaMaleta(lista);
        while(aux != lista->primero){
            fprintf(grafica, "lcm%d[label = \"Maleta %d\\nPasajero %d\"]; ", cont, aux->id, aux->idpas);
            aux = aux->siguiente;

            cont++;
        }

        QString alin;
        for(int i = 0; i <= cont/2; i++){
            alin += "{rank = same lcm" + QString::number(i) + "; lcm" + QString::number((cont-1)-i) + ";}\n";
        }
        fprintf(grafica, alin.toStdString().c_str());

        cont = 0;
        aux = lista->primero;;
        fprintf(grafica, "lcm%d->lcm%d\n", cont, cont+1);
        aux = aux->siguiente;
        cont++;
        while(aux != lista->primero){
            if(aux->siguiente != lista->primero){
                fprintf(grafica, "lcm%d->lcm%d\n", cont, cont+1);
            }else{
                fprintf(grafica, "lcm%d->lcm0\n", cont);
                fprintf(grafica, "lcm0->lcm%d\n", cont);
            }
            fprintf(grafica, "lcm%d->lcm%d\n", cont, cont-1);
            cont++;
            aux = aux->siguiente;
        }

    }
    fprintf(grafica, "}");
}

void Graficar::GraficarListaEscritorios(ListaDobleEscritorios *lista){
    fprintf(grafica, "subgraph clusterEscritorios{\n");
    fprintf(grafica, "label = \"Escritorios\"\n");
    if(lista->primero != NULL)
    {
        NodoEscritorios *aux = lista->primero;
        int cont = 0;
        fprintf(grafica, "{rank = \"same\"\n");
        while(aux != NULL){
            fprintf(grafica, "le%d[label =\"Escritorio %c\\n", cont, aux->id);
            if(aux->idpas == 0){
                fprintf(grafica, "Pasajero atendido: ninguno\\n");
            }else{
                fprintf(grafica, "Pasajero atendido: %d\\n", aux->idpas);
            }
            fprintf(grafica, "Turnos restantes: %d\"];\n", aux->numturnos);
            aux = aux->siguiente;
            cont++;
        }
        fprintf(grafica, "}");
        aux = lista->primero;
        cont = 0;
        while(aux != NULL){
            if(cont == 0 && aux->siguiente != NULL){
                fprintf(grafica, "le%d->le%d\n", cont, cont+1);
            }else if(aux->siguiente == NULL && cont > 0){
                fprintf(grafica, "le%d->le%d\n", cont, cont-1);
            }else if(cont > 0){
                fprintf(grafica, "le%d->le%d\n", cont, cont+1);
                fprintf(grafica, "le%d->le%d\n", cont, cont-1);
            }
            aux = aux->siguiente;
            cont++;
        }
    }
    fprintf(grafica, "}");
}
