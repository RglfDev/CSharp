using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoClientes
{
    internal class Cliente
    {
        public string nombre { get; set; }
        public double cuenta { get; set; }


        public Cliente()
        {
            Console.Write($"Introduce tu nombre: ");
            nombre = Console.ReadLine();
            this.nombre = nombre;

            Console.Write($"Introduce tu pasta: ");
            cuenta = Convert.ToDouble(Console.ReadLine());
            this.cuenta = cuenta;
        }
        public void retirar(double amount)
        {

            Console.Clear();
            Console.WriteLine($"{nombre} va a retirar dinero");
            Console.Write("Ingrese la cantidad a retirar:");
            if (!double.TryParse(Console.ReadLine(), out double dinero))
            {
                Console.WriteLine("Introduce una cantidad válida");
                Console.ReadKey();
                return;
            }

            amount = dinero;

            if (amount > cuenta) {
                Console.Write($"Saldo insuficiente");
                return;

            }
            else { 
                cuenta = cuenta - amount;
                Console.WriteLine($"Has retirado {amount}€. Tu cuenta tiene {cuenta}€");
            }
        }
            

        public void ingresar(double amount)
        {

            Console.Clear();
            Console.WriteLine($"{nombre} va a ingresar dinero");
            Console.Write("Ingrese la cantidad a retirar:");
            if (!double.TryParse(Console.ReadLine(), out double dinero))
            {
                Console.WriteLine("Introduce una cantidad válida");
                Console.ReadKey();
                return;
            }

            cuenta = dinero;
            cuenta = cuenta + amount;
            Console.WriteLine($"Has ingresado {amount}€. Tu cuenta tiene {cuenta}€");
        }

        public void verCuenta()
        {
            Console.WriteLine($"Hola {nombre}, tu dinero actual es: {cuenta}€");
        }
    }
}
