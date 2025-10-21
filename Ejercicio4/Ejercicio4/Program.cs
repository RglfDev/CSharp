using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 4.	Sistema de facturación (interfaces + herencia + sobrecarga)
•	Crea una interfaz IImprimible con un método Imprimir().
Crea clases Cliente, Producto y Factura.
La factura debe tener una lista de productos, calcular el total y poder imprimirse.
*/

namespace Ejercicio4
{
    internal class Program
    {
        public interface IImprimible
        {
            void Imprimir();
        }

        public class Cliente {
            public string Nombre { get; set; }
            public string NI { get; set; }

            public Cliente(string nombre, string ni)
            {
                Nombre = Nombre;
                NI = ni;
            }
        }

        public class Producto
        {
            public string Descripcion { get; set; }
            public double Precio { get; set; }
            public int Cantidad { get; set; }

            public Producto(string descripcion, double precio, int cantidad)
            {
                Descripcion = descripcion;
                Precio = precio;
                Cantidad = cantidad;
            }

            public double Subtotal() => Precio * Cantidad;
        }

        
        public class Factura : IImprimible
        {
            public string Numero { get; set; }
            public Cliente Cliente { get; set; }
            public List<Producto> Productos = new List<Producto>();

            public Factura(string numero, Cliente cliente)
            {
                Numero = numero;
                Cliente = cliente;
            }

            public void AgregarProducto(Producto p)
            {
                Productos.Add(p);
            }

            public double CalcularTotal()
            {
                double total = 0;
                foreach (Producto p in Productos)
                {
                    total += p.Subtotal();
                }
                return total;
            }

            public void Imprimir()
            {
                Console.WriteLine($"Factura nº: {Numero}\nCliente: {Cliente.Nombre} - NI: {Cliente.NI}");
                Console.WriteLine($"Detalle de los productos");
                foreach(Producto p in Productos)
                {
                    Console.WriteLine($"\t{p.Descripcion}: ${p.Precio}, Cantidad: {p.Cantidad} = ${p.Subtotal()}");
                }
                Console.WriteLine($"TOTAL FACTURA: {CalcularTotal()}");
            }
        }


        static void Main(string[] args)
        {
            Cliente c1 = new Cliente("Cliente1", "os793f");
            Factura f1 = new Factura("87e",c1);
            f1.AgregarProducto(new Producto("Ordenador", 1200, 1));
            f1.AgregarProducto(new Producto("Pantalla", 400, 2));
            f1.AgregarProducto(new Producto("Raton", 12, 4));

            f1.Imprimir();



            Console.ReadKey();
        }
    }
}
