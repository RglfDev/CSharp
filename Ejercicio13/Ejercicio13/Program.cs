using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

/**
 * 13.	Sistema de vehículos eléctricos (herencia + sobrecarga + polimorfismo)
•	Crea una clase base Vehiculo con propiedades Marca y Modelo.
Crea clases derivadas VehiculoElectrico y VehiculoCombustion.
Implementa sobrecarga de métodos para “Cargar()” y “Repostar()” según tipo de vehículo.
*/

namespace Ejercicio13
{
    internal class Program
    {

        class Vehiculo
        {
            public string Marca { get; set; }
            public string Modelo { get; set; }

            public Vehiculo(string marca, string modelo)
            {
                Marca=marca;
                Modelo=modelo;
            }

            public virtual void MostrarInfo() => Console.WriteLine($"{Marca} {Modelo}");
        }

        class VehiculoElectrico: Vehiculo 
        {
            public int CapacidadBateria { get; set; }

            public VehiculoElectrico(string marca, string modelo, int capacidad) :base(marca,modelo)
            {
                CapacidadBateria = capacidad;
            }

            public override void MostrarInfo()
            {
                base.MostrarInfo();
                Console.WriteLine($"Tipo Electrico - Bateria {CapacidadBateria} KWh");
            }

            public void Cargar() => Console.WriteLine($"{Marca} {Modelo} esta cargando");
            
            public void Cargar(int minutos) => Console.WriteLine($"{Marca} {Modelo} cargando en {minutos}");
        }

        class VehiculoCombustion : Vehiculo
        {
            public double CapacidadDeposito { get; set; }

            public VehiculoCombustion(string marca,string modelo, double capacidad): base(marca, modelo)
            {
                CapacidadDeposito = capacidad;
            }

            public override void MostrarInfo()
            {
                base.MostrarInfo();
                Console.WriteLine($"Tipo Combustion - Tanque {CapacidadDeposito} litros");
            }

            public void Repostar()
            {
                Console.WriteLine($"{Marca} {Modelo} esta repostando...");
            }

            public void Repostar(double litros)
            {
                Console.WriteLine($"{Marca} {Modelo} esta repostando {litros} litros en el depósito...");
            }
        }

        static void Main(string[] args)
        {
            Vehiculo v1 = new VehiculoElectrico("Tesla", "Modelo3", 75);
            Vehiculo v2 = new VehiculoCombustion("Toyota", "Corolla", 45);

            v1.MostrarInfo();
            Console.WriteLine();
            v2.MostrarInfo();
            Console.WriteLine();

            ((VehiculoElectrico)v1).Cargar(30);
            ((VehiculoCombustion)v2).Repostar(20);
        }
    }
}
