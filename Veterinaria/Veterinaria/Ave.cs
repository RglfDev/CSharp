using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria
{
    //Clase Ave que hereda de Mascota
    public class Ave : Mascota
    {
        /*Atributos:
         * -Fecha nacimiento: recoge la fecha en formato DateTime.
         * -Tipo Ave: Dependiendo del peso del ave asigna su tipo automáticamente.
         * */
        public DateTime FechaNacimiento { get; set; }
        public string TipoAve => Peso < 1 ? "Ave de campo" : "Ave de presa";

       //Constructor que hereda las porpiedades necesarias de la clase padre
        public Ave(string nombre, int edad, double peso, DateTime fechaNacimiento)
            : base(nombre, edad, peso)
        {
            FechaNacimiento = fechaNacimiento;
        }

       //Metodo MostrarInfo heredado de la clase padre con sobrecarga personalizado (Expilación en clase Perro)
        public override void MostrarInfo(bool info)
        {
            Console.WriteLine($"{Tipo}: {Nombre}\n\tClase de ave: {TipoAve}\n\tEdad: {Edad}\n\tPeso: {Peso:F2} Kg" +
                $"\n\tFecha de nacimiento: {FechaNacimiento:dd/MM/yyyy} Ración diaria: {CalcularRacion()} gs.");

            if (info)
            {
                ListarEnfermedades();
                ListarVacunas();
            }
        }

        //Metodo heredado y sobreescrito que calcula la racion dependiendo del peso
        protected override double CalcularRacion()
        {
            return (Peso < 1) ? Peso *2+10 : Peso * 5 +20;
        }

    }
}

