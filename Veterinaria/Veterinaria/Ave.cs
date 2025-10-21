using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria
{
    public class Ave : Mascota
    {
        public DateTime FechaNacimiento { get; set; }
        public string TipoAve => Peso < 1 ? "Ave de campo" : "Ave de presa";
       
        public Ave(string nombre, int edad, double peso, DateTime fechaNacimiento)
            : base(nombre, edad, peso)
        {
            FechaNacimiento = fechaNacimiento;
        }

        public override void MostrarInfo(bool info)
        {
            Console.WriteLine($"{Tipo}: {Nombre}\nEdad: {Edad}\nPeso: {Peso} Kg\nFecha de nacimiento: {FechaNacimiento:dd/MM/yyyy}");

            if (info)
            {
                ListarEnfermedades();
                ListarVacunas();
            }
        }

        protected override double CalcularRacion()
        {
            return (Peso < 1) ? Peso *2+10 : Peso * 5 +20;
        }

    }
}

