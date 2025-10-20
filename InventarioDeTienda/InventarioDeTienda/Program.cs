using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/** 14.	14. Inventario de Tienda
Crea una jerarquía de clases para distintos tipos de productos (por ejemplo, Electrónico, Ropa, Alimento).
Cada clase debe tener un método que calcule el precio final considerando impuestos o descuentos.
.*/

namespace InventarioDeTienda
{
    class Producto
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }

        public virtual double PrecioFinal() => Precio;
    }

    class Electronica : Producto
    {
        public override double PrecioFinal() => Precio * 1.21; //21%IVA

    }

    class Ropa : Producto
    {
        public double Descuento { get; set; }
        public override double PrecioFinal() => Precio * (1 - Descuento); //Aplicamos un descuento (1:precio, Descuento: la propiedad)

    }
    internal class Program
    {

        
       
        static void Main(string[] args)
        {

            List<Producto> productos = new List<Producto>
        {
            new Electronica{Nombre="TV",Precio=500},
            new Ropa{Nombre="Camiseta", Precio=20, Descuento=0.1}
        };

            foreach (var p in productos)
            {
                Console.WriteLine($"{p.Nombre} - Precio Final: {p.PrecioFinal()}");
            }

        }
    }
}
