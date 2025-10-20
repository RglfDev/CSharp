using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiculosConHerencia
{
    internal class Moto : Vehiculo
    {
        public bool CascoIncluido {  get; set; }
        public override void MostrarInfo() => Console.WriteLine($"Moto: {Marca} - casco?? {CascoIncluido}");

        
    }
}
