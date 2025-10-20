using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**Se tiene una clase llamada Alumno que define como atributos su nombre y su edad. 
 * En el constructor realizar el ingreso de datos. Definir otros dos métodos para imprimir 
 * los datos ingresados  y un mensaje de si es mayor o no de edad(edad >= 18).
 */

namespace EjercicioCSHARPInterfacesydemas
{
    internal class Program
    {
        public class Alumno
        {
            private string NombreAlumno { get; set; }


            private int edadAlumno { get; set; }

            public Alumno()
            {
                Console.Write("Ingrese Nombre");
                NombreAlumno = Console.ReadLine();
                Console.Write("Ingrese edad");
                edadAlumno = Convert.ToInt32(Console.ReadLine());
            }

            public void ImprimirDatos()
            {
                Console.WriteLine($" El alumno {NombreAlumno} tiene {edadAlumno} años");

            }

            public void EsMayor()
            {
                if (edadAlumno < 18)
                {
                    Console.WriteLine("El alumno es MENOR de edad");
                }
                else
                {
                    Console.WriteLine("El alumno es MAYOR de edad");
                }

            }

            static void Main(string[] args)
            {

                Alumno a1 = new Alumno(); //Esta linea es la que dispara el constructor y saltarian los ReadLine()
                a1.ImprimirDatos();
                a1.EsMayor();


            }
        }
        
    }
}
