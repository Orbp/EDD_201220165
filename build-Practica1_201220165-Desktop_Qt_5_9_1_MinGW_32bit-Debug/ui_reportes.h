/********************************************************************************
** Form generated from reading UI file 'reportes.ui'
**
** Created by: Qt User Interface Compiler version 5.9.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_REPORTES_H
#define UI_REPORTES_H

#include <QtCore/QVariant>
#include <QtWidgets/QAction>
#include <QtWidgets/QApplication>
#include <QtWidgets/QButtonGroup>
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QLabel>
#include <QtWidgets/QMainWindow>
#include <QtWidgets/QMenuBar>
#include <QtWidgets/QStatusBar>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_Reportes
{
public:
    QWidget *centralwidget;
    QLabel *label;
    QMenuBar *menubar;
    QStatusBar *statusbar;

    void setupUi(QMainWindow *Reportes)
    {
        if (Reportes->objectName().isEmpty())
            Reportes->setObjectName(QStringLiteral("Reportes"));
        Reportes->resize(800, 600);
        centralwidget = new QWidget(Reportes);
        centralwidget->setObjectName(QStringLiteral("centralwidget"));
        label = new QLabel(centralwidget);
        label->setObjectName(QStringLiteral("label"));
        label->setGeometry(QRect(0, 0, 801, 541));
        Reportes->setCentralWidget(centralwidget);
        menubar = new QMenuBar(Reportes);
        menubar->setObjectName(QStringLiteral("menubar"));
        menubar->setGeometry(QRect(0, 0, 800, 26));
        Reportes->setMenuBar(menubar);
        statusbar = new QStatusBar(Reportes);
        statusbar->setObjectName(QStringLiteral("statusbar"));
        Reportes->setStatusBar(statusbar);

        retranslateUi(Reportes);

        QMetaObject::connectSlotsByName(Reportes);
    } // setupUi

    void retranslateUi(QMainWindow *Reportes)
    {
        Reportes->setWindowTitle(QApplication::translate("Reportes", "MainWindow", Q_NULLPTR));
        label->setText(QString());
    } // retranslateUi

};

namespace Ui {
    class Reportes: public Ui_Reportes {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_REPORTES_H
