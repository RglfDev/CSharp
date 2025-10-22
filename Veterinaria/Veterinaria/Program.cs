using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Programa Protectora-Veterinaria:
 * Este programa se ha desarrollado creando diferentes clases de Mascotas que heredarán de la clase 
 * Mascota. Ademas, se ha implementado una clase "Protectora", la cual se encarga de lo siguiente:
 * - Contener una lista de mascotas donde se iran guardando los animales creados.
 * - Llamar a los métodos correspondientes de cada clase para mostrar datos, crear animales etc...según
 *      el usuario vaya escogiendo las opciones pertinentes del menú.
 * - Opción de enfermar y vacunar a los animales:
 *      --Se podrá detectar enfermedades de los animales, las cuales quedaran guardadas en una lista propia.
 *      --Se podrá vacunar a los animales de enfermedades: si ya tienen esa enfermedad, se elimina y queda sano.
 *         Si no, quedará vacunado igualmente, y si a posteriori se le intenta enfermar con esa enfermedad. el 
 *         programa no lo permitira ya que el animal posee dicha vacuna y será "inmune".
 * Se ha intentado plantear de diferente manera al de los vehiculos para abordar metodologías distintas aplicadas
 * en el otro proyecto.
 */

namespace Veterinaria
{
    internal class Program
    {
        /*Clase "Main" desde donde se lanza el programa con un menú por consola para que el 
         * usuario pueda ir eligiendo las opciones que mas le convengan.
         * */
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
