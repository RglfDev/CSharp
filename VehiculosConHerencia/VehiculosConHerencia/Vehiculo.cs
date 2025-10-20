using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiculosConHerencia
{
    internal class Vehiculo
    {
        public string Marca { get; set; }
        public virtual void MostrarInfo() => Console.WriteLine($"Marca: {Marca}");

    }

    class Auto: Vehiculo
    {
        public int Puertas { get; set; }
        public override void MostrarInfo() => Console.WriteLine($"Auto {Marca} con {Puertas}");
    }
}
