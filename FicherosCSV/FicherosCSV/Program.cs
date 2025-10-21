using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FicherosCSV
{

    class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Departamento { get; set; }
        public decimal Salario { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            string rutaArchivo = "empleados.csv";

            //Lista empleados
            List <Empleado> empleados = new List<Empleado>();

            try
            {
                using (StreamReader sr = new StreamReader(rutaArchivo))
                {
                    string linea;
                    bool primeraLinea = true;

                    while ((linea = sr.ReadLine()) != null)
                    {
                        if (primeraLinea)
                        {
                            primeraLinea = false;
                            continue;

                        }
                        //dividimos por comas
                        string[] columnas = linea.Split(',');

                        Empleado empleado = new Empleado
                        {
                            Id = int.Parse(columnas[0]),
                            Nombre = columnas[1],
                            Departamento = columnas[2],
                            Salario = decimal.Parse(columnas[3])

                        };

                        empleados.Add(empleado);
                    }


                }

                Console.WriteLine("-----Lista de empleados-----");
                foreach(var empleado in empleados) Console.WriteLine($"{empleado.Nombre} {empleado.Departamento}");
                Console.WriteLine("-----Estadisticas-----");

                var salarioPromedio = empleados.Average(e => e.Salario);
                var salarioMaximo = empleados.Max(e => e.Salario);

                Console.WriteLine($"Salario Promedio: {salarioPromedio}");
                Console.WriteLine($"Salario Maximo: {salarioMaximo}");


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
