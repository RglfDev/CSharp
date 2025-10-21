using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Veterinaria.Program;

namespace Veterinaria
{
    public abstract class Mascota : ISalud
    {
        public string Nombre { get; set; }
        protected string Tipo => GetType().Name;
        protected int Edad { get; set; }
        protected double Peso { get; set; }
        protected List<String> Vacunas { get; set; }
        protected List<String> Enfermedades { get; set; }

        protected Mascota(string nombre, int edad, double peso)
        {
            Nombre = nombre;
            Edad = edad;
            Peso = peso;
            Vacunas = new List<String>();
            Enfermedades = new List<String>();
        }

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

        public virtual void MostrarInfo()
        {
            Console.WriteLine($"{Tipo}: {Nombre} - Edad: {Edad} años.");
        }
        public abstract void MostrarInfo(bool info);

        protected abstract double CalcularRacion();

        protected bool EstaEnfermo() => Enfermedades.Count > 0;


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

