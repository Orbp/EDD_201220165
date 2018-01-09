using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto
{
    public class TablaHashUsuarios
    {
        public NodoHashUsuarios[] nodos;
        double registrosocupados;
        double registrosdisponibles;
        int numerodeexpancion;
        int tama;

        public TablaHashUsuarios()
        {
            nodos = new NodoHashUsuarios[43];
            registrosdisponibles = 43;
            registrosocupados = 0;
            tama = 43;
        }

        public void Insertar(string nickname, string password, string correo, bool conectado)
        {
            if (nodos[clave(nickname)] != null && nodos[clave(nickname)].nickname.Length > 0)
            {
                Rehash(clave(nickname), nickname, password, correo, conectado);
            }
            else
            {
                nodos[clave(nickname)] = new NodoHashUsuarios();
                nodos[clave(nickname)].nickname = nickname;
                nodos[clave(nickname)].password = password;
                nodos[clave(nickname)].correo = correo;
                nodos[clave(nickname)].conectado = conectado;
                registrosdisponibles--;
                registrosocupados++;
            }
        }

        public void Expandir()
        {
            if (porcentajeocupacion() > 50)
            {
                NodoHashUsuarios[] aux = nodos;
                bool primo = false;
                int nuevotama = tama;
                int auxprim = 0;
                while (!primo)
                {
                    nuevotama = nuevotama + 1;
                    auxprim = 0;
                    for (int i = 1; i <= nuevotama; i++)
                    {
                        if (nuevotama % i == 0)
                        {
                            auxprim++;
                        }
                        if (auxprim > 2)
                        {
                            break;
                        }
                    }
                    if (auxprim != 2)
                    {
                        primo = false;
                    }
                    else
                    {
                        primo = true;
                    }
                }
                nodos = new NodoHashUsuarios[nuevotama];
                tama = nuevotama;
                registrosdisponibles = nuevotama;
                registrosocupados = 0;
                for (int i = 0; i < aux.Length; i++)
                {
                    if (aux[i] != null && aux[i].nickname.Length > 0)
                    {
                        Insertar(aux[i].nickname, aux[i].password, aux[i].correo, aux[i].conectado);
                    }
                }
            }
        }

        public void Rehash(int clave, string nickname, string password, string correo, bool conectado)
        {
            bool insertado = false;
            int i = 1;
            int indice;
            while (!insertado)
            {
                indice = clave + (int)Math.Pow(i, 2);
                if (indice >= tama)
                {
                    indice = indice - tama;
                    if (nodos[indice] != null && nodos[indice].nickname.Length != 0)
                    {
                        i++;
                    }
                    else
                    {
                        nodos[indice] = new NodoHashUsuarios();
                        nodos[indice].nickname = nickname;
                        nodos[indice].password = password;
                        nodos[indice].correo = correo;
                        nodos[indice].conectado = conectado;
                        registrosdisponibles++;
                        registrosocupados--;
                        insertado = true;
                    }
                }
                else
                {
                    if (nodos[indice] != null && nodos[indice].nickname.Length != 0)
                    {
                        i++;
                    }
                    else
                    {
                        nodos[indice] = new NodoHashUsuarios();
                        nodos[indice].nickname = nickname;
                        nodos[indice].password = password;
                        nodos[indice].correo = correo;
                        nodos[indice].conectado = conectado;
                        registrosdisponibles++;
                        registrosocupados--;
                        insertado = true;
                    }
                }
            }
        }

        public int clave(string valor)
        {
            int aux = 0;
            char[] auxval = valor.ToCharArray();
            for (int i = 0; i < valor.Length; i++)
            {
                aux += (int)auxval[i];
            }
            return aux % tama;
        }

        public int porcentajeocupacion()
        {
            double aux = (registrosocupados / registrosdisponibles);
            aux = aux * 100;
            return (int)aux;
        }
    }
}