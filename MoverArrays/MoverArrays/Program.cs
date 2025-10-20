using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoverArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion = 0;
            string[] nombres = new string[5];
            int rellenados = 0;
            do
            {

                Console.WriteLine("Programa para insertar o borrar nombres: ");
                Console.WriteLine("Opcion 1: Añadir un nombre al final ");
                Console.WriteLine("Opcion 2: Insertar un dato en una posicion ");
                Console.WriteLine("Opcion 3: Borrar un dato de una posición ");
                Console.WriteLine("Opcion 4: Mostrar los datos ");
                Console.Write("¿Que opcion eliges?");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        if (rellenados == 5)
                        {
                            Console.Write("El array está lleno");
                        }
                        else
                        {

                            Console.WriteLine("Inserta un nuevo nombre: ");
                            string nuevo = Console.ReadLine();

                           
                                nombres[rellenados] = nuevo;
                                rellenados++;
                            
                            
                        }
                        break;
                    case 2:

                        if (rellenados == 5)
                        {
                            Console.Write("El array está lleno");
                        }
                        else
                        {
                            Console.Write("Inserta un nuevo nombre: ");
                            string nuevo2 = Console.ReadLine();

                            Console.Write("Inserta en numero una posición: ");
                            int posicion2 = Convert.ToInt32(Console.ReadLine());

                            for (int i = rellenados; i > posicion2; i--)
                            {
                                nombres[i] = nombres[i - 1];
                            }

                            nombres[posicion2] = nuevo2;
                            rellenados++;
                        }
                        break;
                    case 3:

                        Console.Write("Inserta en numero una posición para borrar el dato: ");
                        int posicion3 = Convert.ToInt32(Console.ReadLine());

                        for (int i = rellenados; i > posicion3 - 1; i--)
                        {
                            nombres[i] = nombres[i + 1];
                        }
                        rellenados--;
                        nombres[rellenados] = null;


                        break;

                    case 4:

                        Console.WriteLine("Datos del array: ");

                        for (int i = 0; i < nombres.Length; i++)
                        {
                            Console.Write(nombres[i] + ", ");
                        }


                        break;

                }

            } while (opcion != 0);




            Console.ReadKey();
        }
    }
}
