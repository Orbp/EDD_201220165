#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include "colaaviones.h"
#include <time.h>
#include "graficar.h"
#include "listamantenimiento.h"
#include "colaesperamantenimiento.h"

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();

private slots:
    void on_pushButton_clicked();

    void on_pushButton_2_clicked();

    void on_pushButton_3_clicked();

private:
    Ui::MainWindow *ui;
    int numerodeturno;
    int numerodeaviones;
    int numerodeesc;
    int nummant;
    int auxnumerodeturno = 1;
    int idaviones = 1;
    int maxturnospe = 1;
    int maxturnosme = 2;
    int maxturnosgra = 3;
    int idpasajeros = 1;
    int idmaleta = 1;
    coladoblellegada *colallegada = (coladoblellegada *)malloc(sizeof(coladoblellegada));
    listamantenimiento *listadepuestosmantenimiento = (listamantenimiento *)malloc(sizeof(listamantenimiento));
    colaesperamantenimiento *colamantenimiento = (colaesperamantenimiento *)malloc(sizeof(colaesperamantenimiento));
    ColaPasajeros *colapasajeros = (ColaPasajeros *)malloc(sizeof(ColaPasajeros));
    ListaCircularMaleta *listamaletas = (ListaCircularMaleta *)malloc(sizeof(ListaCircularMaleta));
    void Consola(int turno);
};

#endif // MAINWINDOW_H
