using System;

namespace Biblioteca
{
    class Libro
    {
        public string Titulo { get; set; }

    }

    class Usuario
    {
        public string Nombre { get; set; }
    }

    class Prestamo
    {
        public Libro Libro { get; set; }
        public Usuario Usuario { get; set; }
        public bool Activo { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Usuario usuario = new Usuario { Nombre = "Ana" };
            Libro uno = new Libro { Titulo = "C# avanzado" };
            Prestamo p1 = new Prestamo { Libro=uno, Usuario=usuario,Activo = true };

            Console.WriteLine($"{p1.Usuario.Nombre} - {p1.Libro.Titulo} - {p1.Activo}");
        }
    }
}
