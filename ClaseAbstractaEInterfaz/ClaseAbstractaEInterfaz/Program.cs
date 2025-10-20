using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClaseAbstractaEInterfaz
{
    internal class Program
    {
        #region Abstracts
        public abstract class Formas
        {
            public const double pi = Math.PI;
            protected double x, y;

            public Formas(double x, double y)
            {
                this.x = x; this.y = y;
            }

            public abstract double Area();
        }

        public class Circulo : Formas
        {

            public Circulo(double radio) : base(radio, 0)
            {

            }
            public override double Area()
            {
                return pi * x * x;
            }

        }

        public class Cilindro : Circulo
        {
            public Cilindro(double radio, double altura) : base(radio)
            {
                y = altura;
            }

            public override double Area()
            {
                return (2 * base.Area()) + (2 * pi * x * y);
            }
        }

        #endregion


        #region Getters y setters, lambdas y condiciones en setter
        public class Date
        {
            private int _month = 7;

            public int Month
            {
                get => _month;
                set
                {
                    if ((value < 0) && (value < 13))
                    {
                        _month = value;
                    }
                }
            }
        }

        public class Person
        {
            private string _name;
            public string Name
            {
                get => _name;
                set => _name = value;
            }


        }
        #endregion

        #region Interfaces
        public interface IVolador
        {
            void Volar();
        }

        public class Abeja : IVolador
        {
            public void Volar()
            {
                
            }
        }

        #endregion
        static void Main(string[] args)
        {

            //Abstractas

            double radius = 2.5;
            double height = 3.0;

            Circulo circulo = new Circulo(radius);
            Cilindro cilindro = new Cilindro(radius, height);

            Console.WriteLine($"Area del circulo: {circulo.Area()}");
            Console.WriteLine($"Area del cilindro: {cilindro.Area()}");

            //Getter y Setter

            Date fecha = new Date();
            fecha.Month = 15;

            Console.WriteLine(fecha.Month);

            //Interfaces

            Abeja abeja = new Abeja(); //Declaramos el objeto abeja


            //IVolador abejaVoladora = abeja as IVolador; //Decimos que abeja pertenece a la interfaz y lo metemos en la clase de la interfaz
            //abejaVoladora.Volar();
            

            Console.ReadKey();


        }

            
    }
}
