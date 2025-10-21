using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 5.	Sistema de alquiler de vehículos (herencia + polimorfismo + sobreescritura)
        •	Crea una clase base Vehiculo con propiedades Marca, Modelo y PrecioPorDia.
        •   Deriva Auto y Moto.
        •   Ambas deben implementar su propio cálculo del costo de alquiler según la duración y posibles descuentos.
*/

namespace Ejercicio5
{
    internal class Program
    {
        public abstract class Vehiculo
        {
            protected string Marca { get; set; }
            protected string Modelo { get; set; }
            protected double PrecioPordia { get; set; }

            public Vehiculo(string marca, string modelo, double precioPorDia)
            {
                Marca = marca;
                Modelo = modelo;
                PrecioPordia = precioPorDia;
            }


            public abstract double CalcularCoste(int dias);

            public virtual void MostrarInfo()
            {
                Console.WriteLine($"{GetType().Name}: {Marca} {Modelo}- Precio/Día {PrecioPordia}");

            }
        }

        public class Auto : Vehiculo
        {
            public bool TieneGPS { get; set; }

            public Auto(string marca, string modelo, double precioPordia, bool gps) : base(marca, modelo, precioPordia)
            {
                TieneGPS = gps;
            }

            public override double CalcularCoste(int dias)
            {
                double costo = dias * PrecioPordia;
                if (TieneGPS) costo += 5 * dias;
                if (dias > 7) costo *= 0.9; //descuento del 10%
                return costo;
            }
        }

        public class Moto : Vehiculo
        {
            public bool TieneCasco {  get; set; }

            public Moto(string marca, string modelo, double precio, bool casco) : base (marca,modelo,precio)
            {
                TieneCasco = casco;
            }

            public override double CalcularCoste(int dias)
            {
                double costo = dias * PrecioPordia;
                if (TieneCasco) costo += 2 * dias;
                return costo;
            }
        }
        static void Main(string[] args)
        {

            List<Vehiculo> lista = new List<Vehiculo>
            {
                new Auto ("Toyota", "Corolla", 50, true),
                new Moto ("Kawasaki", "Ninja", 30, false),
            };

            foreach (Vehiculo v in lista)
            {
                v.MostrarInfo();

                Console.WriteLine($"Costo por 10 días: ${v.CalcularCoste(10):0.00}");
                Console.WriteLine();
            }


        }
    }
}
