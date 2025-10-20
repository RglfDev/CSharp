using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHARPSTATIC
{
    internal class Program
    {

        public class Contador
        {
            public int id;
            public static int totalObjetos = 6; 

            public Contador()
            {
                //Incremento la variable de clase
                totalObjetos++;

                id = totalObjetos;
            }

            public static void MostrarTotal()
            {
                Console.WriteLine($"total de objetos : {totalObjetos}");
            }
        }

        public class Persona
        {
            protected string ssn="444-555-666"; //Protected significa que solo pueden acceder a ellos en las clases que hereden de esta
            protected string name = "Pepe lillo";

            public virtual void GetInfo()  //virtual permite sobreescribir el metodo en la clase hija
            {
                Console.WriteLine($"Name: {name}");
                Console.WriteLine($"SSN: {ssn}");
            }
        }

        public class Rectangulo
        {
            int _x;
            int _y;
            public Rectangulo(int x, int y)
            {
                _x = x;
                _y = y;
            }

        }

        public class Employee
        {
            public int salary;

            public Employee(int annualSalary)
            {
                salary = annualSalary;
                Console.WriteLine($"Constructor Empleado salario anual {salary}");

            }

            public Employee(int weeksSalary, int numberOfWeeks) : this(weeksSalary * numberOfWeeks)
            {
                Console.WriteLine($"Constructor employee(weekSalary, numberOfWeeks)"+
                    $"sueldo semanal : {weeksSalary} numeros de la semana : {numberOfWeeks}");
            }
        }

        public class Coordenadas
        {
            private int x, y;

            public Coordenadas()
            {
                x= 0; y= 0;
            }

            public Coordenadas(int x, int y)
            {
                this.x=x; this.y = y;
            }
            public override string ToString()
            {
                return string.Format("{0} {1}",x,y); //Creamos un propio metodo ToString
            }
        }

        
        static void Main(string[] args)
        {

            //STATIC: Variable o metodo.
            //Variable Static: su valor es el mismo para todos os objetos de esa clase.
            //Metodo: es un metodo que se puede usar sin instanciar la clase.

            //variable de clase Static.
            Contador c1 = new Contador();
            Contador c2 = new Contador();
            Contador c3 = new Contador();

            Console.WriteLine($"ID de c1 es {c1.id}");  //7
            Console.WriteLine($"ID de c2 es {c2.id}");  //8
            Console.WriteLine($"ID de c3 es {c3.id}");  //9

            Contador.MostrarTotal();

            Coordenadas co1 = new Coordenadas();
            Coordenadas co2 = new Coordenadas(3,6);


            Console.ReadKey();
        }
    }
}
