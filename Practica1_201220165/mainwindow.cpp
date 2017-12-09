#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <QMessageBox>
#include "iostream"

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
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
        ui->label_5->setText("Turno " + QString::number(auxnumerodeturno) + "/" + QString::number(numerodeturno));
    }
}

void MainWindow::on_pushButton_2_clicked()
{
    if(auxnumerodeturno < numerodeturno){
        auxnumerodeturno++;
        ui->label_5->setText("Turno " + QString::number(auxnumerodeturno) + "/" + QString::number(numerodeturno));
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
}
