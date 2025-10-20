using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{

    internal class Program { 

        struct cancion
    {
            public string nombre;
            public string artista;
            public int duracion;
            public int peso;

    }
    
        static void Main(string[] args)
        {

            Console.Write("escribe el nombre de la cancion: ");
            string nombreCancion = Console.ReadLine();
            Console.Write("escribe el nombre del artista: ");
            string nombreArtista = Console.ReadLine();
            Console.Write("escribe la duración en segundos: ");
            int duracionCancion = Convert.ToInt32(Console.ReadLine());
            Console.Write("¿Cuantos Kbs pesa?: ");
            int pesoCancion = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Cancion: {nombreCancion}, Artista: {nombreArtista}, duración: {duracionCancion} seg., peso: {pesoCancion} Kbs.");

            Console.ReadKey();

        }
    }
}
