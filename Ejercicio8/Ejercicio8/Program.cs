using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


/**
 * •8.Crea una interfaz IReservable con métodos Reservar() e ImprimirReserva().
Crea clases Habitacion, HabitacionSimple y HabitacionDoble derivadas de una clase base.
Crea una clase Reserva que contenga un cliente y una habitación.
*/
namespace Ejercicio8
{
    internal class Program
    {
        interface IReservable
        {
            void Reservar(string cliente);
            void ImprimirReserva();
        }

        abstract class Habitacion
        {
            public int Numero { get; set; }
            public double PrecioPorNoche { get; set; }
        

        protected Habitacion(int numero, double precio)
        {
            Numero = numero;
            PrecioPorNoche = precio;
        }

            public virtual void MostrarInfo()
            {
                Console.WriteLine($"Habitacion {Numero} - Precio/Noche: ${PrecioPorNoche}");
            }
        }
        class HabitacionSimple : Habitacion
        {

            public HabitacionSimple(int numero, double precio) : base(numero, precio) { }

            public override void MostrarInfo()
            {
                Console.WriteLine($"Habitacion {Numero} - Precio/Noche: ${PrecioPorNoche}");
            }
        }

        class HabitacionDoble : Habitacion
        {
            public bool TieneVistasAlMar {  get; set; }

            public HabitacionDoble(int numero, double precio, bool vista) : base(numero, precio)
            {
                TieneVistasAlMar = vista;
            }

            public override void MostrarInfo()
            {
                string vista = TieneVistasAlMar ? "con vistas al mar" : "sin vistas";
                Console.WriteLine($"Habitacion {Numero} - ( {vista} )- Precio/Noche: ${PrecioPorNoche}");
            }
            
        }

        class Reserva : IReservable
        {

            public String Cliente { get; set; }
            public Habitacion Habitacion { get; set; }
            public int Noches { get; set; }


            public Reserva ( Habitacion habitacion, int noches)
            {
                Habitacion = habitacion;
                Noches = noches;
            }

            public void ImprimirReserva()
            {
                Console.WriteLine("-----RESERVA-----");
                Console.WriteLine($"Cliente: {Cliente}");
                Habitacion.MostrarInfo();
                Console.WriteLine($"Noches: {Noches}");
                Console.WriteLine($"Precio: ${Habitacion.PrecioPorNoche * Noches:0.00}");
            }

            public void Reservar(string cliente)
            {
            Cliente = cliente;
            Console.WriteLine($"Reserva creada para {Cliente}");
            }
        }


        static void Main(string[] args)
        {
            Habitacion h1 = new HabitacionSimple(101, 80);
            Habitacion h2 = new HabitacionDoble(202, 150,true);

            Reserva r1 = new Reserva(h1, 3);
            Reserva r2 = new Reserva(h2, 5);

            r1.Reservar("Sonia Gonzalez");
            r2.Reservar("Pepe Galindo");

            Console.WriteLine();

            r1.ImprimirReserva();
            Console.WriteLine();
            r2.ImprimirReserva();
            Console.ReadKey();
        }
    }
}
