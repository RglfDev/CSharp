using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 2.	Sistema de gestión escolar (herencia + interfaces + clases relacionadas)
•	Crea una clase abstracta Persona con Nombre, Edad y un método MostrarDatos().
Crea clases derivadas Alumno y Profesor.
Ambas deben implementar una interfaz IEvaluable con un método Evaluar().
•	En Main, crea una lista de personas y muestra sus datos.
*/

namespace Ejercicio2
{


    internal class Program
    {

        public interface IEvaluable
        {
            void Evaluar();
        }

        public abstract class Persona : IEvaluable{

            protected string Nombre { get; set; }
            protected int Edad { get; set; }

            public Persona(string nombre, int edad)
            {
                Nombre = nombre;
                Edad = edad;
            }

            public abstract void MostrarDatos();

            public abstract void Evaluar();
            
        }

        public class Alumno : Persona
        {
            public int Nota { get; set; }

            public Alumno(string nombre, int edad, int nota) : base(nombre, edad)
            {
                Nota = nota;
            }

            public override void MostrarDatos()
            {
                Console.WriteLine($" La persona {Nombre} tiene {Edad} años. ");
            }

            public override void Evaluar ()
            {
                string res = (Nota >= 5) ? $"{Nombre} ha aprobado con un {Nota}" : $"{Nombre} ha suspendido con un {Nota}";
                Console.WriteLine(res);
            }

        }

        public class Profesor : Persona
        {
            public string Asignatura { get; set; }
            public Profesor(string nombre, int edad, string asignatura) : base(nombre, edad)
            {
                Asignatura = asignatura;
            }

            public override void Evaluar()
            {
                Console.WriteLine("El profesor esta corrigiendo los exámenes");
            }

            public override void MostrarDatos()
            {
                Console.WriteLine($" El profesor {Nombre} tiene {Edad} años e imparte {Asignatura}. ");
            }

        }
        static void Main(string[] args)
        {

            Persona a1 = new Alumno("Ruben", 35, 4);
            Persona p1 = new Profesor("Javier",50,"Física");

            a1.MostrarDatos();
            ((IEvaluable)a1).Evaluar();
            ((IEvaluable)a1).Evaluar();

            Console.ReadKey();

        }
    }
}
