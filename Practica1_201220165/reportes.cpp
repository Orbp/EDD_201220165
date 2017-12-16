#include "reportes.h"
#include "ui_reportes.h"

Reportes::Reportes(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::Reportes)
{
    ui->setupUi(this);
    QPixmap ima = QPixmap("Grafica.jpg");
    ima = ima.scaled(ui->label->width(), ui->label->height(), Qt::KeepAspectRatio, Qt::SmoothTransformation);
    ui->label->setPixmap(ima);
    ui->label->setScaledContents(false);
    ui->label->setSizePolicy(QSizePolicy::Ignored, QSizePolicy::Ignored);
}

Reportes::~Reportes()
{
    delete ui;
}
