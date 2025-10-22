using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Veterinaria.Program;

namespace Veterinaria
{   //Clae abstracta mascota que implementa la interfaz ISalud
    public abstract class Mascota : ISalud
    {
        public string Nombre { get; set; }
        //Este atributo recoge automáticamente el nombre de su clase dependiendo de si es perro, gato o ave.
        protected string Tipo => GetType().Name;
        protected int Edad { get; set; }
        protected double Peso { get; set; }
        //Lista de vacunas para cada animal
        protected List<String> Vacunas { get; set; }
        //Lista de enfermedades para cada animal
        protected List<String> Enfermedades { get; set; }

        protected Mascota(string nombre, int edad, double peso)
        {
            Nombre = nombre;
            Edad = edad;
            Peso = peso;
            Vacunas = new List<String>();
            Enfermedades = new List<String>();
        }

        /**Este método aplica una vacuna al animal:
         *  -Si el animal ya tiene esa vacuna, mostrará un mensaje
         *  -Si el animal esta enfermo de esa enfermedad, al aplicar la vacuna se "curara" y la enfermedad desaparece de la lista.*/
        public void Vacunar(string stringVacuna)
        {
            string vacuna = stringVacuna.ToLower().Trim();
            bool vacunado = Vacunas.Contains(vacuna);

            if (vacunado)
            {
                Console.WriteLine($"El {Tipo} {Nombre} ya ha sido vacunado de {vacuna}");
            }
            else
            {
                Console.WriteLine($"Al {Tipo} {Nombre} se le ha vacunado de {vacuna}");
                Vacunas.Add(vacuna);
                bool buscarEnfermedad = Enfermedades.Contains(vacuna);

                if (buscarEnfermedad) { 
                Enfermedades.Remove(vacuna);
                    Console.WriteLine($"{Nombre} ya no está enfermo de {vacuna}");
                }
            }
        }

        /*Este metodo ernerma a los animales:
         * -Si el animal está vacunado de esa enefermedad, no podrá volver a contraerla.
         * -Si no esta vacunado, el animal enfermara.*/
        public virtual void DetectarEnfermedad(String enf)
        {
            string name = enf.ToLower().Trim();
            bool esInmune = Vacunas.Contains(name);
            if (esInmune)
            {
                Console.WriteLine($"El {Tipo} {Nombre} es inmune a la enfermedad de {name}");
            }
            else
            {
                Console.WriteLine($"Al {Tipo} {Nombre} se le ha detectado la enfermedad de {name}");
                Enfermedades.Add(name);
            }
        }
        //KMetodo para mostrar información básica de cada animal
        public virtual void MostrarInfo()
        {
            Console.WriteLine($"{Tipo}: {Nombre} - Edad: {Edad} años.");
        }
        //Sobrecarga del método anterior para que las clases lo hereden
        public abstract void MostrarInfo(bool info);
        //Metodo para las clases hijas que permitirá calcular las raciones del animal según el tipo.
        protected abstract double CalcularRacion();
        //Método qye compureba si el animal está enfermo contantdo las enfermedades de la lista.
        protected bool EstaEnfermo() => Enfermedades.Count > 0;

        /* Metodo para lsitar las enfermedades. Si tiene las muestra, si no muestra que esta "Sano".*/
        protected void ListarEnfermedades()
        {
            if (this.EstaEnfermo())
            {
                Console.WriteLine("\t\tListado de enfermedades: ");
                foreach (string enf in Enfermedades)
                {
                    Console.WriteLine($"\t\t{enf}");
                }
            }
            else
            {
                Console.WriteLine("\t- Estado: sano");
            }
        }

        /*Metodo de funcionamiento casi igual al anterior, solo que este muestra las vacunas*/
        protected void ListarVacunas()
        {
            Console.WriteLine("\t- Listado de vacunas: ");
            if (Vacunas.Count > 0)
            {
                foreach (string vac in Vacunas)
                {
                    Console.WriteLine($"\t\t{vac}");
                }
            }
            else
            {
                Console.WriteLine("\t\tNo tiene vacunas");
            }
        }


    }
}

