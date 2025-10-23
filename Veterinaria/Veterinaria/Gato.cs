using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria
{
    //Enum para definir la personalidad del gato.
    public enum TipoPersonalidad
    {
        Arisco,
        Salvaje,
        Cariñoso,
    }
    //Clase gato que hereda de Mascota.
    public class Gato : Mascota
    {
        public string Localizacion { get; set; }

        public TipoPersonalidad Personalidad { get; set; }

        //Constructor que toma los atributos necesarios de la clase padre.
        public Gato(string nombre, int edad, double peso, TipoPersonalidad personalidad)
            : base(nombre, edad, peso)
        {
            Personalidad = personalidad;
            Localizacion = GetLocalizacion();
        }

        /* Este método da a elegir entre dos opciones para definir de donde procede el gato:
         * -Se puede elegir entre dos opciones.
         * -Si el valor es incorrecto, se asiga una por defecto.
         * -Se le pasa directamente el valor de este método al constructor.*/
        private string GetLocalizacion()
        {
            int option = 0;
            Console.WriteLine("¿De donde procede?\n\t1.Callejero.\n\t2.Doméstico.");
            Console.Write("Respuesta: ");
            if((int.TryParse(Console.ReadLine(),out option) && (option ==1 || option ==2)))
            {
                return option ==1 ? "Callejero" : "Doméstico";
            }
            else
            {
                Console.WriteLine("Valor incorrecto, se le asignara por defecto el valor Doméstico");
                return "Doméstico";
            }
        }

        //Metodo MostrarInfo heredado de la clase padre con sobrecarga personalizado (Expilación en clase Perro)
        public override void MostrarInfo(bool info)
        {
            if (info)
            {
                Console.WriteLine($"{Tipo}: {Nombre}:\n\t- Localizacion: {Localizacion}\n\t- Edad: {Edad}" +
                    $"\n\t- Peso: {Peso:F2} Kg,\n\t- Alimentación diaria: {CalcularRacion()} gs");
                this.ListarEnfermedades();
                this.ListarVacunas();
            }
            else
            {
                base.MostrarInfo();
            }
        }

        //Método heredado personalizado para calcular la ración diaria
        protected override double CalcularRacion()
        {
            if (Peso < 10)
            {
                return Peso * 70 + 50;
            }
            else if (Peso >= 10 && Peso <= 20)
            {
                return Peso * 50 + 40;
            }
            else
            {
                return Peso * 20 + 20;
            }
        }
    }
}
