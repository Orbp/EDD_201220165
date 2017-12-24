using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea3
{
    class Program
    {
        static void Main(string[] args)
        {
            Arbolbinario arbol = new Arbolbinario();
            int opcion = 0;
            do
            {
                Console.WriteLine("Seleccione una opcion del menu");
                Console.WriteLine("1. Insertar en el arbol");
                Console.WriteLine("2. Mostrar recorrido");
                Console.WriteLine("3. Salir");
                opcion = int.Parse(Console.ReadLine());
                if (opcion == 1)
                {
                    Console.WriteLine("Ingrese el caracter que se insertara en el arbol");
                    char c = char.Parse(Console.ReadLine());
                    if (arbol.GetRaiz() == null)
                    {
                        arbol.SetRaiz(new NodoArbolBinario(c));
                    }
                    else
                    {
                        arbol.Insertar(arbol.GetRaiz(), c);
                    }
                }
                else if(opcion == 2)
                {
                    Console.WriteLine("Seleccione el tipo de orden que desea mostrar");
                    Console.WriteLine("1. PreOrden");
                    Console.WriteLine("2. InOrden");
                    Console.WriteLine("3. PostOrden");
                    int op = int.Parse(Console.ReadLine());
                    if (op == 1)
                    {
                        arbol.RecorridoPreOrden(arbol.GetRaiz());                        
                    }
                    else if (op == 2)
                    {
                        arbol.RecorridoInOrden(arbol.GetRaiz());
                    }
                    else if (op == 3)
                    {
                        arbol.RecorridoPostOrden(arbol.GetRaiz());
                    }
                }
            } while (opcion != 3);
            Console.ReadKey();
        }
    }
}
