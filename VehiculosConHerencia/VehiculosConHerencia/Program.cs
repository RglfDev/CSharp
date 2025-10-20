using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiculosConHerencia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehiculo> vehiculos = new List<Vehiculo>
            {
                new Auto{Marca="Toyota",Puertas=4},
                new Moto{Marca="Suzuki",CascoIncluido = true}
            };

            foreach(var v in vehiculos)
            {
                v.MostrarInfo();
            }
            Console.ReadKey();
            
        }
    }
}
