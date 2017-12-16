#ifndef REPORTES_H
#define REPORTES_H

#include <QMainWindow>
#include <QString>

namespace Ui {
class Reportes;
}

class Reportes : public QMainWindow
{
    Q_OBJECT

public:
    explicit Reportes(QWidget *parent = 0);
    ~Reportes();

private:
    Ui::Reportes *ui;
    QString imagen = "Grafica.jpg";
    QImage im;
    QPixmap p;
    int w;
    int h;
};

#endif // REPORTES_H
