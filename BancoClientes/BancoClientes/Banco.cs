using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoClientes
{
    internal class Banco
    {
        List<Cliente>listadoClientes = new List<Cliente>();

        public Banco(List<Cliente> clientes)
        {
            listadoClientes = clientes;
        }

        public void agregarCliente(Cliente cliente)
        {

            listadoClientes.Add(cliente);
        }


        public void verListadoClientes()
        {
            foreach (var cliente in listadoClientes)
            {
                Console.WriteLine($"{cliente.nombre} ---- {cliente.cuenta}");
            }

        }

        public void calcularTotalClientes()
        {
            double total = 0.0;
            foreach (var cliente in listadoClientes)
            {
                total+= cliente.cuenta;
            }

            Console.WriteLine($"El total del dia final ha sido: {total}€");
        }
    }

    
}
