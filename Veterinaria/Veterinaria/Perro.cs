using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Veterinaria.Program;

namespace Veterinaria
{
    //Enum de nivel de obediencia para el atributo del perro
    public enum NivelObediencia
    {
        Bajo,
        Medio,
        Alto
    }
    //Clase Perro que hereda de MAscota
    public class Perro : Mascota
    {
        public string Raza { get; set; }
        public NivelObediencia Obediencia { get; set; }

        //El constructor hereda los atributos de Animal necesarios, y declara los propios
        public Perro(string nombre, int edad, double peso, string raza, NivelObediencia obediencia)
            : base(nombre, edad, peso)
        {
            Raza = raza;
            Obediencia = obediencia;
        }

        /*Sobreescritura o polimorfismo del método MostrarInfo el cual adapta su funcionamiento a las necesidades de esta clase.
         * Muestra los atributos básicos, tambien muestra la racion diaria llamando al metodo CalcularRacion() y muestra el 
         * listado de enfermedades y vacunas a traves de los métodos correspondientes, a los cuales tiene acceso desde la clase
         * padre ya que estan declarados como PROTECTED.
         * Si no se llama al MostrarInfo(bool), pasa automaticamente a implementar y mostrar el metodo MostrarInfo de la clase 
         * padre.*/
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

        /*Este método devuelve un valor u otro de ración diaria comprobando si el perro está sano o no con el
         * método EstaEnfermo().*/
        protected override double CalcularRacion() => EstaEnfermo() ? Peso * 70 + 50 : Peso * 70 + 25;

    }
}
