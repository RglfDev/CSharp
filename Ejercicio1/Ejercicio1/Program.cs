using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


/**
 * 1.	Sistema de vehículos (interfaces y clases relacionadas)
•	Crea una interfaz IVehiculo con Acelerar() y Frenar().
•	Otra interfaz IMostrable con MostrarInfo().
•	Crea clases Auto y Moto que implementen ambas.
*/
namespace Ejercicio1
{
    internal class Program
    {

        public interface IVehiculo
        {
            void Acelerar();
            void Frenar();
        }

        public interface IMostrable
        {
            void MostrarInfo();
        }

        public class Auto : IVehiculo, IMostrable
        {

            public string Marca { get; set; }
            public int Velocidad { get; private set; }

            public Auto(string marca, int velocidadInicial)
            {

                Marca = marca;
                Velocidad = velocidadInicial;
            }

            public void Acelerar() => Velocidad += 5;


            public void Frenar() => Velocidad -= 5;


            public void MostrarInfo()
            {
                Console.WriteLine($"Auto: {Marca} va a {Velocidad} km/h");

            }
        }

        public class Moto : IVehiculo, IMostrable
        {

            public string Modelo { get; set; }
            public int Velocidad { get; set; }

            public Moto(string modelo, int velocidadInicial)
            {
                Modelo = modelo;
                Velocidad = velocidadInicial;
            }

            public void Acelerar() => Velocidad += 150;

            public void Frenar() => Velocidad -= 120;

            public void MostrarInfo()
            {
                Console.WriteLine($"Moto: {Modelo} va a {Velocidad} km/h");
            }
        }

        static void Main(string[] args)
        {

            IVehiculo v1 = new Auto("Toyota", 50);
            IVehiculo v2 = new Moto("Yamaha", 40);

            ((IMostrable)v1).MostrarInfo();
            ((IMostrable)v2).MostrarInfo();

            Console.WriteLine("Acelerando Vehículos...");
            v1.Acelerar();
            v2.Acelerar();

            ((IMostrable)v1).MostrarInfo();
            ((IMostrable)v2).MostrarInfo();

            Console.WriteLine("Frenando Moto!!");

            v2.Frenar();

            ((IMostrable)v1).MostrarInfo();
            ((IMostrable)v2).MostrarInfo();

            Console.ReadKey();
        }
    }
            
}
