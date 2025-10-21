using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio12
{
    /**
     * 12.	Sistema de evaluación de proyectos (herencia + interfaces + sobrecarga + composición)
•	Crea una interfaz IEvaluable con método Evaluar().
•	Crea clases Proyecto y Evaluador.
•	El evaluador puede calificar el proyecto con puntuaciones o comentarios (usando sobrecarga).
*/
    internal class Program
    {
        interface IEvaluable
        {
            void Evaluar(int puntuacion);
            void Evaluar(string comentario);
        }

        class Proyecto
        {
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
            public int Calificacion { get; set; }
            public string Comentario { get; set; }

            public Proyecto (string titulo, string descripcion)
            {
                Titulo = titulo;
                Descripcion = descripcion;
            }

            public void AsignarCalificacion(int nota)
            {
                Calificacion = nota;
            }

            public void AsignarComentario(string texto)
            {
                Comentario = texto;
            }

            public void MostrarResultado()
            {
                Console.WriteLine($"Proyecto: {Titulo}");
                Console.WriteLine($"Descripción: {Descripcion}");
                Console.WriteLine($"Calificación: {Calificacion}");
                Console.WriteLine($"Comentario: {Comentario}");
            }

        }

        class Evaluador : IEvaluable
        {
            public string  Nombre { get; set; }
            private Proyecto proyecto;

            public Evaluador(string nombre, Proyecto p)
            {
                Nombre = nombre;
                proyecto = p;
            }

            public void Evaluar(int puntuacion)
            {
                proyecto.AsignarCalificacion(puntuacion);
                Console.WriteLine($"{Nombre} asigno una calificacion de {puntuacion} al proyecto {proyecto.Titulo}");
            }

            public void Evaluar (string comentario)
            {
                proyecto.AsignarComentario(comentario);
                Console.WriteLine($"{Nombre} asigno un comentario de {comentario} al proyecto {proyecto.Titulo}");
            }
        }


        static void Main(string[] args)
        {
            Proyecto pr1 = new Proyecto("Ingeniería","Aplicación para construir puentes");
            Evaluador ev1 = new Evaluador("ING: Pepe",pr1);

            ev1.Evaluar(9);
            ev1.Evaluar("Buen diseño y funcionalidad");
            pr1.MostrarResultado();

            Console.ReadKey();
        }
    }
}
