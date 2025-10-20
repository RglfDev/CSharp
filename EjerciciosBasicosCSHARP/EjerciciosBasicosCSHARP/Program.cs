using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosBasicosCSHARP
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Programa de conversion de grados");
            Console.Write("Introduce una cantidad en grados Celsius");
            double celsius = Convert.ToDouble(Console.ReadLine());

            double kelvin = celsius + 273.00;
            double farenheith = celsius * 18 / (10 + 32);

            Console.WriteLine("Grados Kelvin: {0}", kelvin);
            Console.WriteLine("Grados Farenheith: {0}", farenheith);

            Console.ReadKey();
        }
    }
}
