using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria
{
    internal class Protectora
    {
        public List<Mascota> listaMascotas = new List<Mascota>();

        public void AñadirMascota()
        {
            Console.WriteLine("Elige un tipo de mascota:\n\t1.-Perro.\n\t2.-Gato.\n\t3.-Ave.");
            Console.Write("Respuesta: ");
            if ((!int.TryParse(Console.ReadLine(), out int opcion) || opcion < 1 || opcion > 3))
            {
                Console.WriteLine("Valor inválido. Por favor, inténtelo de nuevo más tarde.");
                return;
            }
            else
            {

                Console.Write("Introduce su nombre: ");
                string nombre = Console.ReadLine();

                Console.Write("Introduce su edad: ");
                if (!(int.TryParse(Console.ReadLine(), out int edad)))
                {
                    Console.WriteLine("Edad no váida, por defecto se asignara la edad de 1 año");
                    edad = 1;
                }

                Console.Write("Introduce su peso en Kg: ");
                if (!(int.TryParse(Console.ReadLine(), out int peso)))
                {
                    Console.WriteLine("Peso no váido, por defecto se asignara el peso a 5 Kg");
                    peso = 5;
                }
                switch (opcion)
                {
                    case 1:
                        Console.Write("Introduce la raza: ");
                        string raza = Console.ReadLine();

                        Console.WriteLine("Que nivel de obediencia tiene?\n\t1.-Bajo\n\t2.-Medio\n\t3.-Alto");
                        Console.Write("Respuesta: ");
                        if ((!int.TryParse(Console.ReadLine(), out int select) || select <1  || select > 3))
                        {
                            Console.Write("Valor no válido. Se le asignará el valor Medio");
                            select = 2;
                        }
                        select -= 1;
                        NivelObediencia obediencia = (NivelObediencia)select;

                        Mascota perro = new Perro(nombre, edad, peso, raza, obediencia);
                        listaMascotas.Add(perro);
                        break;

                    case 2:
                        Console.WriteLine("¿Qué personalidad tiene el Gato?\n\t1.-Arisco\n\t2.-Salvaje\n\t3.-Cariñoso");
                        Console.Write("Respuesta: ");
                        if ((!int.TryParse(Console.ReadLine(), out int personal) || personal <1 || personal > 3))
                        {
                            Console.Write("Valor no válido. Se le asignará el valor Medio");
                            select = 2;
                        }
                        personal -= 1;
                        TipoPersonalidad personalidad = (TipoPersonalidad)personal;

                        Mascota gato = new Gato(nombre, edad, peso, personalidad);
                        listaMascotas.Add(gato);
                        break;

                    case 3:
                        Console.Write("Introduce la fecha de nacimiento del Ave (dd/mm/aa): ");
                        if (!DateTime.TryParse(Console.ReadLine(), out DateTime fecha))
                        {
                            Console.Write("Formato de fecha no válido. Se asignará la fecha actual");
                            fecha = DateTime.Now;
                        }

                        Mascota ave = new Ave(nombre, edad, peso, fecha);
                        listaMascotas.Add(ave);
                        break;
                }
            }
        }

        public void ListarAnimales()
        {
            for (int i = 0; i < listaMascotas.Count; i++)
            {
                Console.Write($"  {i + 1}: -->  ");
                listaMascotas[i].MostrarInfo();
            }
        }

        public void AnimalDetallado()
        {
            ListarAnimales();
            Console.Write("Ingresa el número del animal: ");
            if (int.TryParse(Console.ReadLine(), out int seleccion))
            {
                seleccion -= 1;

                if (seleccion < 0 || seleccion >= listaMascotas.Count)
                {
                    Console.Write("No hay ningún animal en esa posición");
                }
                else
                {
                    listaMascotas[seleccion].MostrarInfo(true);
                }
            }
            else
            {
                Console.WriteLine("Dato no valido, volviendo...");
            }
            
        }

        public void DetectarEnfermedad()
        {
            Console.Write("Escoge un animal por su número para diagnosticar: ");
            if ((int.TryParse(Console.ReadLine(), out int pos)))
            {
                pos -= 1;
                if (pos < 0 || pos >= listaMascotas.Count)
                {
                    Console.WriteLine("No existe un animal con ese número");
                }
                else
                {

                    Mascota mascota = listaMascotas[pos];

                    mascota.MostrarInfo(true);
                    Console.Write("Introduce la enfermedad detectada: ");
                    string enfermedad = Console.ReadLine().ToLower().Trim();

                    mascota.DetectarEnfermedad(enfermedad);
                }
            }
            else
            {
                Console.WriteLine("Error, introduce un dato válido");
            }
        }

        public void CurarEnfermedad()
        {
            Console.Write("Escoge un animal por su número para curar: ");
            if ((int.TryParse(Console.ReadLine(), out int pos))){

                pos -= 1;

                if(pos <0 || pos >= listaMascotas.Count)
                {
                    Console.WriteLine("No existe un animal con ese número");
                }
                else
                {
                    Mascota mascota = listaMascotas[pos];
                    mascota.MostrarInfo(true);
                    Console.Write("Introduce la enfermedad a vacunar: ");
                    string enfermedad = Console.ReadLine().ToLower().Trim();
                    mascota.Vacunar(enfermedad);
                }
            }
            else
            {
                Console.WriteLine("Error, introduce un dato válido");
            }
        }

    }
}
