using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHARPParte2
{
    internal class Program
    {
        #region Funciones
        public static void saludar()
        {
            Console.WriteLine("Hola al programa");
            Console.WriteLine(" de ejemplo");
            Console.WriteLine("saludos");
        }

        public static void escribeNumeroReal(float numero)
        {
            Console.WriteLine(numero.ToString("#.###"));
        }

        public static void escribeSuma(int x, int y)
        {
            int suma = x + y;
            Console.WriteLine(suma.ToString());
        }

        public static int cuadrado(int x)
        {
            return x * x;
        } 
        #endregion

        public static void duplicar(ref int x)
        {
            Console.WriteLine($"El valor recibido vale {x}");
            x = x * 2;
            Console.WriteLine($"Ahora vale {x}");
        }

        

        static void Main(string[] args)
        {
            //string text = "Hola";
            //text += " Mundo";
            //text += "!";


            //string texto = "";
            //for (int i = 0; i > 1000; i++)
            //{
            //    texto += 1.ToString(); //Aqui construimos 1000 strings, ocupando 1000 espacios de memoria
            //}

            //StringBuilder sb = new StringBuilder(); //Con stringBuilder almacenamos todo en el mismo objeto, ocupando solo un espacio de memoria
            //for (int i = 0; i < 1000; i++)
            //{
            //    sb.Append(i); //Con append añadimos la cadena al objeto StringBuilder
            //}

            //string texto2 = sb.ToString(); //Por ultimo, se parsea el stringBuilder a String y se construye finalmente el String

            ////ES NECESARIO PARSEAR EL STRINGBUILDER A STRING AL FINAL

            ////FOREACH

            //int[] diasMes = { 31, 23, 24 };

            //foreach (int dias in diasMes)
            //{
            //    Console.WriteLine("días del mes: {0}", dias);
            //}

            //string[] nombres = { "Alberto", "Jesus", "Maria" };
            //foreach (string nombre in nombres)
            //{
            //    Console.WriteLine(nombre);
            //}

            //string saludo = "Hola";
            //foreach(char letra in saludo)
            //{
            //    Console.WriteLine(letra);
            //}

            //saludar();
            //escribeNumeroReal(2.3f);
            //escribeSuma(3, 5);
            //int resultado = cuadrado(3);
            //Console.WriteLine(resultado.ToString());

            int n = 5;
            Console.WriteLine($"n vale {n}");
            // Con ref, en vez de pasar un valor como parámetro podemos pasarle una variable directamente para que la trabaje
            // o modifique. Cuando la devuelva, cambiará el valor de la variable original

            duplicar(ref n); Console.WriteLine($"Ahora n vale {n}");

            Random generador = new Random(); // Objeto para generar numeros aleatorios
            int aleatorio = generador.Next(1, 100); //.Next(inicio,fin) genera numero aleatorios entre esos valores

            Console.ReadKey();

        }
    }
}
