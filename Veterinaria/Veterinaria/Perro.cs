using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Veterinaria.Program;

namespace Veterinaria
{

    public enum NivelObediencia
    {
        Bajo,
        Medio,
        Alto
    }
    public class Perro : Mascota
    {
        public string Raza { get; set; }
        public NivelObediencia Obediencia { get; set; }


        public Perro(string nombre, int edad, double peso, string raza, NivelObediencia obediencia)
            : base(nombre, edad, peso)
        {
            Raza = raza;
            Obediencia = obediencia;
        }

        public override void MostrarInfo(bool info)
        {
            if (info)
            {
                Console.WriteLine($"{Tipo}: {Nombre}:\n\tRaza: {Raza}\n\tEdad: {Edad}\n\tPeso: {Peso} Kg,\n\tAlimentación diaria: {CalcularRacion()} gs");
                this.ListarEnfermedades();
                this.ListarVacunas();
            }
            else
            {
                base.MostrarInfo();
            }

        }

        protected override double CalcularRacion() => EstaEnfermo() ? Peso * 70 + 50 : Peso * 70 + 25;

    }
}
