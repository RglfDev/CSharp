using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ObjetosCSharp
{
    internal class Program
    {
        #region Clases de los ejercicios
        public class Puerta
        {
            public int ancho { get; set; }
            public int alto { get; set; }
            public int color { get; set; }
            public bool abierta { get; set; }

            public Puerta()
            {
                ancho = 23;
                alto = 120;
                color = 34;
                abierta = false;
            }

            public Puerta(int anch, int alt, int col)
            {
                ancho = anch;
                alto = alt;
                color = col;


            }

            public void Abrir()
            {
                abierta = true;
            }

            public void Cerrar()
            {
                abierta = false;
            }

            public void MostrarEstado()
            {
                Console.WriteLine($"Ancho de la puerta: {ancho}");
                Console.WriteLine($"Alto de la puerta: {alto}");
                Console.WriteLine($"Color de la puerta: {color}");
                Console.WriteLine($"Modo de la puerta: {abierta}");
            }
        }

        public class Persona
        {
            public string nombre { get; set; }
            public int edad { get; set; }
            public DateTime fechaNacimiento { get; set; }

            private int CalcularEdad(DateTime fecha)
            {
                int año = fecha.Year;
                int actual = DateTime.Now.Year;
                return actual - año;
            }

            public void Saludar()
            {
                Console.WriteLine($"Hola me llamo {nombre} y tengo {CalcularEdad(fechaNacimiento)}");
            }
        }

        public class Porton : Puerta //Herencia de clases con :
        {
            public bool bloqueado { get; set; } //prop TAB TAB y sale directamente para poner los getter y setter

            public void Bloquear()
            {
                bloqueado = true;
            }

            public void Desbloquear()
            {
                bloqueado = false;
            }

            public new void MostrarEstado()  // Sobreescritura del metodo que contenía el padre, pudiendo reescribirlo.
            {
                Console.WriteLine($"Ancho del portón : {ancho}");
                Console.WriteLine($"Alto del portón : {alto}");
                Console.WriteLine($"Color del portón : {color}");
                Console.WriteLine($"Estado del portón : {abierta}");
                Console.WriteLine($"Portón bloqueado?? : {bloqueado}");
            }
        }

        public class Empleado
        {
            const int sueldo = 1000;
            const string nombre = "Nuevo empleado";
            const string cargo = "Empleado Base";

            public string Nombre { get; set; }
            public int Sueldo { get; set; }

            public string Cargo { get; set; }

            public Empleado()
            {
                Nombre = nombre;
                Sueldo = sueldo;
                Cargo = cargo;
            }

            public Empleado(string _nombre, int _sueldo, string _cargo)
            {
                Nombre = _nombre;
                Sueldo = _sueldo;
                Cargo = _cargo;
            }

            public void Imprimir()
            {
                Console.WriteLine($"El empleado : {Nombre} con cargo {Cargo} cobra {Sueldo}");
            }

        }
        
        public class Estadistica
        {
            int num1;
            int num2;
            int num3;

            public Estadistica( int _num1, int _num2, int _num3)
            {
                num1 = _num1;  
                num2 = _num2;
                num3 = _num3;
            }

            public int Suma()
            {
                return num1 + num2 + num3;
                
            }

            public decimal Media()
            {
                decimal resultadoMedia = (decimal)Suma() / 3;
                return resultadoMedia;
            }
        }

        public class Concatena
        {
            public string nombre { get; set; }
            public string apellido { get; set; }

            public string concatenar()
            {
                return $"El nombre completo es {nombre} {apellido}";
            }
        } 
        #endregion
        static void Main(string[] args)
        {

            Puerta puerta1 = new Puerta();
            puerta1.MostrarEstado();
            Console.ReadKey();

            Puerta p2 = new Puerta(45,190,20);
            p2.MostrarEstado();

            Persona persona = new Persona();

            persona.nombre = "David";
            DateTime fechaNAc = new DateTime(2010, 8, 18);
            persona.fechaNacimiento = fechaNAc;

            persona.Saludar();

            Porton porton1 = new Porton();
            porton1.ancho = 65;
            porton1.alto = 238;
            porton1.color = 49;
            porton1.abierta = true;
            porton1.bloqueado = false;

            porton1.MostrarEstado();

            Console.Write("Empleado generico : ");
            string nombreempleado = Console.ReadLine();

            if(nombreempleado.Length == 0)
            {
                Empleado empleadoGenerico = new Empleado();
                empleadoGenerico.Imprimir();
            }
            else
            {
                Console.Write("Dime cuanto va a cobrar : ");
                int sueldoEmpleado = Convert.ToInt32(Console.ReadLine());

                Console.Write("Dime su cargo : ");
                string cargoEmpleado = Console.ReadLine();

                Empleado empleado = new Empleado(nombreempleado, sueldoEmpleado, cargoEmpleado);
                empleado.Imprimir();
            }

            Console.Write("Dime tu nombre : ");
            string nombreSusodicho = Console.ReadLine();

            Console.Write("Dime tu nombre : ");
            string apellidoSusodicho = Console.ReadLine();

            Concatena c1 = new Concatena();
            c1.nombre = nombreSusodicho;
            c1.apellido = apellidoSusodicho;

            Console.WriteLine(c1.concatenar());


            Estadistica operacion = new Estadistica(10, 15, 20);
            Console.WriteLine(Convert.ToString($"La suma total de los tres numeros es: {operacion.Suma()}"));
            Console.WriteLine(Convert.ToString($"La media total de los tres numeros es: {operacion.Media()}"));


        }
    }
}
