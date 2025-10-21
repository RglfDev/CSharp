using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

/**
 * 1.	Sistema de gestión de Animales del Zoológico”
•	El zoológico necesita un sistema para registrar animales y mostrar información básica de cada uno.
•   Cada animal tiene una especie, un nombre, una edad, y un hábitat (por ejemplo: terrestre, acuático o aéreo).
•	Cada tipo de animal puede emitir un sonido y tiene una forma de alimentarse diferente.
•	El programa debe permitir crear algunos animales y mostrar su información por consola.
*/

namespace Ejercicio3
{
    internal class Program
    {
        public enum Habitat
        {
            Terrestre,
            Acuatico,
            Aereo
        }

        public interface IAnimal
        {
            void HacerSonido();
            void Alimentarse();
            void MostrarInfo();

        }

        public abstract class Animal : IAnimal {
            protected string Nombre { get; set; }
            protected int Edad { get; set; }
            public Habitat TipoHabitat { get; set; }

            public Animal(string nombre, int edad, Habitat habitat)
            {
                Nombre = nombre;
                Edad = edad;
                TipoHabitat = habitat;
            }


            public abstract void HacerSonido();
            public abstract void Alimentarse();

            public virtual void MostrarInfo()
            {
                Console.WriteLine($"Nombre: {Nombre}, Edad: {Edad}, Habitat: {TipoHabitat}");

            }
        }

        public class Leon : Animal
        {
            public Leon(string nombre, int edad) : base(nombre, edad, Habitat.Terrestre)
            { }
            public override void HacerSonido() => Console.WriteLine($"{Nombre} ruge");
            public override void Alimentarse() => Console.WriteLine($"{Nombre} come carne");

        }
        
        public class Delfin : Animal
        {
            public Delfin(string nombre, int edad) : base(nombre, edad, Habitat.Acuatico)
            { }
            public override void HacerSonido() => Console.WriteLine($"{Nombre} hace ultrasonidos");
            public override void Alimentarse() => Console.WriteLine($"{Nombre} come peces");

        }

        public class Aguila : Animal
        {
            public Aguila(string nombre, int edad) : base(nombre, edad, Habitat.Acuatico)
            { }
            public override void HacerSonido() => Console.WriteLine($"{Nombre} grazna");
            public override void Alimentarse() => Console.WriteLine($"{Nombre} come conejos");

        }


        static void Main(string[] args)
        {

            List<IAnimal> animales = new List<IAnimal>
            {
                new Leon= ("Simba", 5),
                new Delfin("flippy", 2),
            };


            Console.ReadLine();
        }
    }
}
    

