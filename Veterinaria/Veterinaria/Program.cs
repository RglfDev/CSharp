using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******> PROTECTORA VETERINARIA ANIMALETES <******");

            Protectora protectora = new Protectora();

            int opcion;

            do
            {
                Console.WriteLine("\n<<<< Menu principal >>>>");
                Console.WriteLine("1.- Añadir mascota");
                Console.WriteLine("2.- Listado de mascotas");
                Console.WriteLine("3.- Ver animal detallado");
                Console.WriteLine("4.- Detectar enfermedad");
                Console.WriteLine("5.- Vacunar mascota");
                Console.WriteLine("6.- Salir");
                Console.Write("Elige una opción: ");
                Console.WriteLine();

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    opcion = -1; 
                }

                if (opcion >= 1 && opcion <= 6)
                {
                    switch (opcion)
                    {
                        case 1:
                            protectora.AñadirMascota();
                            break;
                        case 2:
                            protectora.ListarAnimales();
                            break;
                        case 3:
                            protectora.AnimalDetallado();
                            break;
                        case 4:
                            protectora.DetectarEnfermedad();
                            break;
                        case 5:
                            protectora.CurarEnfermedad();
                            break;
                        case 6:
                            Console.WriteLine("Saliendo...");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opción inválida. Introduce un número del 1 al 6.");
                }

                Console.WriteLine("=====================");

            } while (opcion != 6);
        }
    }
}
