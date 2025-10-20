using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoClientes
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Cliente c1 = new Cliente();
            Cliente c2 = new Cliente();
            Cliente c3 = new Cliente();
            Banco caixa = new Banco(new List<Cliente> {c1,c2,c3});

            c1.ingresar(200.00);
            c2.retirar(500.00);
            c3.verCuenta();

            caixa.calcularTotalClientes();

            Console.ReadKey();

        }

        
    }

   
}
