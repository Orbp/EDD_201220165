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
    }
}
