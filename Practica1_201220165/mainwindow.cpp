#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <QMessageBox>
#include "iostream"

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    colallegada->primero = NULL;
    colallegada->ultimo = NULL;
    listadepuestosmantenimiento->primero = NULL;
    listadepuestosmantenimiento->ultimo = NULL;
    colamantenimiento->primero = NULL;
    colamantenimiento->ultimo = NULL;
    colapasajeros->primero = NULL;
    colapasajeros->ultimo = NULL;
    listamaletas->primero = NULL;
    listaescritorios->primero = NULL;
    ui->textEdit->setText("********************INICIO********************");
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::on_pushButton_clicked()
{
    if(ui->lineEdit->text().isEmpty() || ui->lineEdit_2->text().isEmpty() || ui->lineEdit_3->text().isEmpty() || ui->lineEdit_4->text().isEmpty()){
        QMessageBox::warning(this, "Campo vacio", "Alguno de los campos iniciales se encuentran vacios");
    }else{
        numerodeesc = ui->lineEdit->text().toInt();
        nummant = ui->lineEdit_2->text().toInt();
        numerodeaviones = ui->lineEdit_3->text().toInt();
        numerodeturno = ui->lineEdit_4->text().toInt();
        auxnumerodeturno = 1;
        ui->lineEdit->setEnabled(false);
        ui->lineEdit_2->setEnabled(false);
        ui->lineEdit_3->setEnabled(false);
        ui->lineEdit_4->setEnabled(false);
        ui->pushButton->setEnabled(false);
        ui->pushButton_2->setEnabled(true);
        ui->textEdit->append("Numero de Escritorios que se crearan en el sistema " + QString::number(numerodeesc));
        ui->textEdit->append("Numero de Puestos de Mantenimiento que se crearan en el sistema " + QString::number(nummant));
        ui->textEdit->append("Numero de Aviones que ingresaran al sistemas " + QString::number(numerodeaviones));
        ui->textEdit->append("Numero de Turnos " + QString::number(numerodeturno));
        ui->label_5->setText("Turno " + QString::number(auxnumerodeturno) + "/" + QString::number(numerodeturno));
        if(idaviones <= numerodeaviones){
            srand(time(NULL));
            int taman = rand() % 3;
            int pasajeros;
            int des;
            int man;
            if(taman == 0){
                pasajeros = rand() % 6 + 5;
                des = 0;
                man = 1 + rand() %3;
            }else if(taman == 1){
                pasajeros = rand() % 11 + 15;
                des = 0;
                man = 2 + rand() %3;
            }else if(taman == 2){
                pasajeros = 30 + rand() % 11;
                des = 0;
                man = 3 + rand() %3;
            }
            InsertarColaLlegada(colallegada, idaviones, taman, pasajeros, des, man);
            ui->textEdit->append("********** TURNO " + QString::number(auxnumerodeturno) + "**********");
            ui->textEdit->append("Arribo avion: " + QString::number(idaviones));
            if(taman == 0){
                ui->textEdit->append("Tamaño: pequeño");
            }else if(taman == 1){
                ui->textEdit->append("Tamaño: mediano");
            }else{
                ui->textEdit->append("Tamaño: grande");
            }
            ui->textEdit->append("Avion desabordando: ninguno");
            idaviones++;
            for(int i = 0; i < nummant; i++){
                InsertarListaMantenimiento(listadepuestosmantenimiento, i+1);
            }
            for(int i = 65; i < 65+numerodeesc; i++)
            {
                InsertarListaEscritorios(listaescritorios, (char)i);
            }
            //MostrarColaLlegada(colallegada);
            Imprimir(ui->textEdit, listadepuestosmantenimiento);
            ImprimirListaConsola(ui->textEdit, listaescritorios);
            Mostrar(listaescritorios);
            Graficar *g = new Graficar(colallegada, listadepuestosmantenimiento, colamantenimiento, colapasajeros, listamaletas, listaescritorios);
            Reportes *r = new Reportes();
            r->show();
        }
    }
}

void MainWindow::on_pushButton_2_clicked()
{
    if(auxnumerodeturno < numerodeturno){
        EliminarAvion(listadepuestosmantenimiento, colamantenimiento);
        auxnumerodeturno++;
        ui->textEdit->append("********** TURNO " + QString::number(auxnumerodeturno) + " **********");
        if(idaviones <= numerodeaviones){
            srand(time(NULL));
            int taman = rand() % 3;
            int pasajeros;
            int des;
            int man;
            if(taman == 0){
                pasajeros = rand() % 6 + 5;
                des = 0;
                man = 1 + rand() %3;
            }else if(taman == 1){
                pasajeros = rand() % 11 + 15;
                des = 0;
                man = 2 + rand() %3;
            }else if(taman == 2){
                pasajeros = 30 + rand() % 11;
                des = 0;
                man = 3 + rand() %3;
            }
            InsertarColaLlegada(colallegada, idaviones, taman, pasajeros, des, man);
            ui->textEdit->append("Arribo avion: " + QString::number(idaviones));
            if(taman == 0){
                ui->textEdit->append("Tamaño: pequeño");
            }else if(taman == 1){
                ui->textEdit->append("Tamaño: mediano");
            }else{
                ui->textEdit->append("Tamaño: grande");
            }
            idaviones++;
        }
        if(colallegada->primero != NULL){
            if(colallegada->primero->tama == 0){
                if(colallegada->primero->turnosdesabordaje < maxturnospe){
                    colallegada->primero->turnosdesabordaje++;
                    ui->textEdit->append("Avion desabordando: Avion " + QString::number(colallegada->primero->id));
                }else{
                    int aux;
                    if(colallegada->primero != NULL){
                        aux = colallegada->primero->pasajeros;
                    }
                    EliminarColaLlegada(colallegada, listadepuestosmantenimiento, colamantenimiento, colapasajeros, idpasajeros, listamaletas);
                    idpasajeros += aux + 1;
                    if(colallegada->primero != NULL){
                        colallegada->primero->turnosdesabordaje++;
                        ui->textEdit->append("Avion desabordando: Avion " + QString::number(colallegada->primero->id));
                    }
                }
            }else if(colallegada->primero->tama == 1){
                if(colallegada->primero->turnosdesabordaje < maxturnosme){
                    colallegada->primero->turnosdesabordaje++;
                    ui->textEdit->append("Avion desabordando: Avion " + QString::number(colallegada->primero->id));
                }else{
                    int aux;
                    if(colallegada->primero != NULL){
                        aux = colallegada->primero->pasajeros;
                    }

                    EliminarColaLlegada(colallegada, listadepuestosmantenimiento, colamantenimiento, colapasajeros, idpasajeros, listamaletas);
                    idpasajeros += aux + 1;
                    if(colallegada->primero != NULL){
                        colallegada->primero->turnosdesabordaje++;
                        ui->textEdit->append("Avion desabordando: Avion " + QString::number(colallegada->primero->id));
                    }
                }
            }else if(colallegada->primero->tama == 2){
                if(colallegada->primero->turnosdesabordaje < maxturnosgra){
                    colallegada->primero->turnosdesabordaje++;
                    ui->textEdit->append("Avion desabordando: Avion " + QString::number(colallegada->primero->id));
                }else{
                    int aux;
                    if(colallegada->primero != NULL){
                        aux = colallegada->primero->pasajeros;
                    }
                    EliminarColaLlegada(colallegada, listadepuestosmantenimiento, colamantenimiento, colapasajeros, idpasajeros, listamaletas);
                    idpasajeros += aux+1;
                    if(colallegada->primero != NULL){
                        colallegada->primero->turnosdesabordaje++;
                        ui->textEdit->append("Avion desabordando: Avion " + QString::number(colallegada->primero->id));
                    }
                }
            }
            //MostrarColaLlegada(colallegada);
            Imprimir(ui->textEdit, listadepuestosmantenimiento);
            ImprimirListaConsola(ui->textEdit, listaescritorios);
            Graficar *g = new Graficar(colallegada, listadepuestosmantenimiento, colamantenimiento, colapasajeros, listamaletas, listaescritorios);
            Reportes *r = new Reportes();
            r->show();
        }
    }else{
        QMessageBox::warning(this, "Simulacion finalizada", "Se ha completado el numero de turnos");
        ui->pushButton_2->setEnabled(false);
        ui->pushButton_3->setEnabled(true);
    }
}

void MainWindow::on_pushButton_3_clicked()
{
    ui->lineEdit->setEnabled(true);
    ui->lineEdit->setText("");
    ui->lineEdit_2->setEnabled(true);
    ui->lineEdit_2->setText("");
    ui->lineEdit_3->setEnabled(true);
    ui->lineEdit_3->setText("");
    ui->lineEdit_4->setEnabled(true);
    ui->lineEdit_4->setText("");
    ui->pushButton_3->setEnabled(false);
    ui->pushButton->setEnabled(true);
    ui->textEdit->setText("");
    colallegada->primero = NULL;
    colallegada->ultimo = NULL;
    listadepuestosmantenimiento->primero = NULL;
    listadepuestosmantenimiento->ultimo = NULL;
    colamantenimiento->primero = NULL;
    colamantenimiento->ultimo = NULL;
    listamaletas->primero = NULL;
}
