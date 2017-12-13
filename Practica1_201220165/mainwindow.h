#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include "colaaviones.h"
#include <time.h>
#include "graficar.h"

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
    coladoblellegada *colallegada = (coladoblellegada *)malloc(sizeof(coladoblellegada));
    void Consola(int turno);
};

#endif // MAINWINDOW_H
