using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 9.	Sistema de transporte (clases abstractas + interfaces + polimorfismo)
•	Crea una clase abstracta Transporte con métodos Mover() y Detener().
Crea una interfaz ITransportable con SubirPasajeros(int cantidad).
Implementa clases Bus, Avion y Barco.
*/

namespace Ejercicio9
{
    internal class Program
    {
        interface ITransporte
        {
            void SubirPasajeros(int cantidad);
        }

        abstract class Transporte
        {
            public string Nombre { get; set; }
            public int VelocidadMaxima { get; set; }

            public Transporte (string nombre, int velocidadMaxima)
            {
                Nombre = nombre;
                VelocidadMaxima = velocidadMaxima;
            }

            public abstract void Mover();
            public virtual void Detener()
            {
                Console.WriteLine($"{Nombre} se ha detenido");
            }

        }

        class Bus : Transporte, ITransporte
        {
            private int pasajeros = 0;

            public Bus(string nombre, int velocidad) : base(nombre, velocidad) { }

            public override void Mover()
            {
                Console.WriteLine($"{Nombre} circula por carretera a {VelocidadMaxima} Km/h.");
            }
            public void SubirPasajeros(int cantidad)
            {
                pasajeros += cantidad;
                Console.WriteLine($"{cantidad} pasajeros subieron al bus. Total {pasajeros} pasajeros.");
            }
        }

        class Avion : Transporte, ITransporte
        {

            public Avion(string nombre, int velocidad) : base(nombre, velocidad) { }

            public override void Mover()
            {
                Console.WriteLine($"{Nombre} vuela a {VelocidadMaxima} Km/h.");
            }
            public void SubirPasajeros(int cantidad)
            {
                Console.WriteLine($"{cantidad} pasajeros abordaron el avion {Nombre}.");
            }
        }

        class Barco : Transporte, ITransporte
        {
            public Barco (string nombre, int velocidad) : base(nombre, velocidad) { }
            public override void Mover()
            {
                Console.WriteLine($"{Nombre} navega a {VelocidadMaxima} nudos.");
            }

            public void SubirPasajeros(int cantidad)
            {
                Console.WriteLine($"{cantidad} pasajeros subieron al barco {Nombre}.");
            }
        }

        static void Main(string[] args)
        {

            Transporte[] transportes =
            {
                new Bus("Linea 24",80),
                new Avion("Boeing 737", 850),
                new Barco("Titanic",40)
            };

            foreach (var t in transportes)
            {
                t.Mover();
                ((ITransporte)t).SubirPasajeros(50);
                t.Detener();
                Console.WriteLine();
            }

        }
    }
}
