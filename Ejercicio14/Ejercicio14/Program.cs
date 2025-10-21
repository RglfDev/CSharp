using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 14.	Sistema de gestión de empleados:
Tendremos una jerarquía de clases:
•	Persona (clase base)
•	Empleado (hereda de Persona)
•	Gerente y Desarrollador (heredan de Empleado)
•	También usaremos un enum llamado Departamento.
*/

namespace Ejercicio14
{
    internal class Program
    {

        enum Departamento
        {
            RecursosHumanos,
            Desarrollo,
            Ventas,
            Finanzas
        }

        class Persona
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public DateTime FechaNacimiento { get; set; }

            public Persona(string nombre, string apellido, DateTime fechaNacimiento)
            {
                Nombre = nombre;
                Apellido = apellido;
                FechaNacimiento = fechaNacimiento;
            }

            public int CalcularEdad()
            {
                int edad = DateTime.Now.Year - FechaNacimiento.Year;
                if (DateTime.Now.Year < FechaNacimiento.DayOfYear) edad--;
                return edad;
            }

            public virtual void MostrarInfo()
            {
                Console.WriteLine($"{Nombre} {Apellido}");
                Console.WriteLine($"Edad: {CalcularEdad()} años");
            }
        }
            class Empleado : Persona
            {
                public int IdEmpleado { get; set; }
                public Departamento Departamento { get; set; }
                public DateTime FechaContratacion {  get; set; }

                //Sobrecarga de constructores
                public Empleado(string nombre, string apellido, DateTime fechaNacimiento) : base(nombre, apellido, fechaNacimiento)
                {
                FechaContratacion = DateTime.Now;
                }

                public Empleado(string nombre, string apellido, DateTime fechaNacimiento, int idEmpleado,Departamento departamento,DateTime fechaContratacion) :base(nombre,apellido,fechaNacimiento) 
                {
                    IdEmpleado = IdEmpleado;
                    Departamento = departamento;
                    FechaContratacion = FechaContratacion;
                }

                public int CalcularAntiguedad()
                {
                    int años = DateTime.Now.Year - FechaContratacion.Year;
                    if (DateTime.Now.DayOfYear < FechaContratacion.DayOfYear) años--;
                    return años;
                }

                public override void MostrarInfo()
                {
                    base.MostrarInfo();
                    Console.WriteLine($"{IdEmpleado}");
                    Console.WriteLine($"{Departamento}");
                    Console.WriteLine($"{CalcularAntiguedad()}");
                }
            }

            class Gerente : Empleado
            {
                public int NumeroEmpeadosACargo {  get; set; }

                public Gerente(string nombre, string apellido, DateTime fechaNacimiento, int idEmpleado, Departamento departamento, DateTime fechaContratacion, int empleadosACargo)
                    : base(nombre, apellido, fechaNacimiento, idEmpleado, departamento, fechaContratacion)
                {
                    NumeroEmpeadosACargo = empleadosACargo;
                }
            }

        
        static void Main(string[] args)
        {

            List<Empleado> empleados = new List<Empleado>();


        }
    }
}
