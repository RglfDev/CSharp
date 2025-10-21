using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/**
 * 11.	Sistema de control de dispositivos inteligentes (interfaces + composición + polimorfismo + enum)
Crea una interfaz IEncendible con métodos Encender() y Apagar().
Crea clases Lampara, Televisor y Refrigerador que implementen la interfaz.
Crea una clase CasaInteligente que contenga varios dispositivos y los controle en conjunto.
*/

namespace Ejercicio11
{
    internal class Program
    {
        enum EstadoDispositivo
        {
            Apagado,
            Encendido
        }

        interface IEncendible
        {
            void Encender();
            void Apagar();

            void MostrarEstado();
        }

        class Lampara : IEncendible
        {

            public string Nombre { get; set; }
            public EstadoDispositivo Estado { get; set; }

            public Lampara(string nombre)
            {
                Nombre = nombre;
                Estado = EstadoDispositivo.Apagado;
            }
            public void Apagar()
            {
                Estado = EstadoDispositivo.Apagado;
                Console.WriteLine($"{Nombre} apagada");
            }

            public void Encender()
            {
                Estado = EstadoDispositivo.Encendido;
                Console.WriteLine($"{Nombre} encendida");
            }

            public void MostrarEstado()
            {
                Console.WriteLine($"{Nombre} esta en este momento {Estado}");
            }
        }

        class Televisor : IEncendible
        {

            public string Marca { get; set; }
            public EstadoDispositivo Estado { get; set; }

            public Televisor(string marca)
            {
                Marca = marca;
                Estado = EstadoDispositivo.Apagado;
            }
            public void Apagar()
            {
                Estado = EstadoDispositivo.Apagado;
                Console.WriteLine($"{Marca} apagada");
            }

            public void Encender()
            {
                Estado = EstadoDispositivo.Encendido;
                Console.WriteLine($"{Marca} encendida");
            }

            public void MostrarEstado()
            {
                Console.WriteLine($" la TV {Marca} esta en este momento {Estado}");
            }
        }

        class Refrigerador : IEncendible
        {

            public string Modelo { get; set; }
            public EstadoDispositivo Estado { get; set; }

            public Refrigerador(string modelo)
            {
                Modelo = modelo;
                Estado = EstadoDispositivo.Apagado;
            }

            public void Apagar()
            {
                Estado = EstadoDispositivo.Apagado;
                Console.WriteLine($"Refrigerador {Modelo} apagado");
            }

            public void Encender()
            {
                Estado = EstadoDispositivo.Encendido;
                Console.WriteLine($"Refrigerador {Modelo} encendido");
            }

            public void MostrarEstado()
            {
                Console.WriteLine($"El refrigerador {Modelo} esta en este momento {Estado}");
            }
        }

        class CasaInteligente
        {
            private List<IEncendible> dispositivos = new List<IEncendible>();

            public void AgregarDispositivo(IEncendible d) => dispositivos.Add(d);

            public void EncenderTodo()
            {
                Console.WriteLine("Encendiendo todos los dispositivos...");
                foreach(var d in dispositivos) d.Encender();
            }

            public void ApagarTodo()
            {
                Console.WriteLine("Apagando todos los dispositivos...");
                foreach (var d in dispositivos) d.Apagar();
            }

            public void MostrarEstados()
            {
                Console.WriteLine("-----Estado actual de los dispositivos-----");
                foreach (var d in dispositivos) d.MostrarEstado();
            }

        }

        static void Main(string[] args)
        {

            CasaInteligente casa = new CasaInteligente();
            casa.AgregarDispositivo(new Lampara("Lampara del salón"));
            casa.AgregarDispositivo(new Televisor("Samsung"));
            casa.AgregarDispositivo(new Refrigerador("Balai"));

            casa.MostrarEstados();
            casa.EncenderTodo();

            casa.MostrarEstados();
            casa.ApagarTodo();

            casa.MostrarEstados();

            Console.WriteLine("Programa finalizado");

            Console.ReadKey();

        }
    }
}
