using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

/*MANEJAR FICHEROS EN C#
1.Abrir el fichero
2.Leer datos
3.Cerrar el fichero

Los ficheros se crean en la carpeta bin/debug
*/

namespace FicherosCsharp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //clase para gestionar la escritura en ficheros
            StreamWriter fichero;
            fichero = File.CreateText("Prueba.txt");
            fichero.WriteLine("Esta es la primera linea");
            fichero.Write("Esta es la segunda linea");
            fichero.Close();

            //El metodo Using va a abrir y cerrar automaticamente los ficheros de texto sin necesidad de cerrarlos manualmente
            string nombreArchivo = "out.txt";
            string linea;
            using(StreamWriter archivo = File.CreateText(nombreArchivo))
            {
                do
                {
                    Console.Write("Escribe: ");
                    linea = Console.ReadLine();

                    if (linea.Length != 0)
                    {
                        archivo.WriteLine(linea);
                    }
                } while (linea.Length != 0);
            }

            //Este bucle DO-WHILE permite al usuario ir metiendo lineas escritas en un txt hasta que deje de escribir^^

            //Para leer usamos fileReader

            string rutaArchivo = "out.txt";

            using (StreamReader fichero2 = new StreamReader(rutaArchivo))
            {
                string linea2;

                while ((linea2 = fichero2.ReadLine()) != null)
                {
                    Console.WriteLine(linea);
                }
            }
            Console.WriteLine("Lectura completa del fichero");
            
            //Forma mas profesional de leer ficheros 
            foreach(string linea2 in File.ReadLines(rutaArchivo))
            {
                Console.WriteLine(linea);
            }
            Console.ReadKey();

            //Para recuperar partes concretas de un fichero:
            //File.ReadAllLines coge todas las lineas del fichero y las guarda en un array

            string archivoNombre = "out.txt";

            string[] lineas = File.ReadAllLines(archivoNombre);

            bool salir = false;

            do
            {
                Console.Write("Buscar: ");
                string linea3 = Console.ReadLine();

                if (linea3 != "")
                {
                    for (int i = 0; i < lineas.Length; i++)
                    {
                        if (lineas[i].Contains(linea))
                        {
                            Console.WriteLine(lineas[i]);
                        }

                    }
                }
                else
                {
                    salir = true;
                }
            } while (!salir);

            //File.AppendText permite añadir un texto a un TXT ya existente

            string directorioArchivo = "out.txt";
            try
            {

                using (StreamWriter sw = File.AppendText(directorioArchivo))
                {
                    sw.WriteLine("Esta linea se agrega al final del fichero");
                    sw.WriteLine("Otra linea agregada al final del fichero");

                    Console.WriteLine("Contenido agregado correctamente");

                    string contenido = File.ReadAllText(directorioArchivo);
                    Console.WriteLine(contenido);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("El archivo no existe");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("No tienes permiso para acceder a este archivo");
            }

            //Para ficheros que se encuentran en otra ruta

            string rutaExterior = "d:\\ejemploejemplo1.txt";
            string rutaNuevaFichero = @"d:/ejemplos/ejemplo1.txt"; //La @ formatea el texto como una ruta
            string rutaRelativa = @"..\datos\configuracion.txt"; //.. para la ruta relativa

            if (File.Exists(rutaRelativa))
            {
                //Aqui ya hariamos la que fuera con los ficheros. File.Exist previene del cascotazo si no encuentra el fichero
            }


            //Gestionar la lectura de directorios.:
            //Directory: Posee métodos para construir un directorio (CreateDirectory), para borrar (Delete) y moverlo (Move)
            //      tambien puede comprobar si existe o no (Exist)
            //DirectoryInfo:

            string miDirectorio = @"c:\ejemplo1\ejemplo2";

            if(!Directory.Exists(miDirectorio)) Directory.CreateDirectory(miDirectorio);

            //Recuperar ficheros en un directorio : GetFiles()
            string[] listaFicheros;
            listaFicheros = Directory.GetFiles(miDirectorio);

            foreach(string fich in listaFicheros)
            {
                Console.WriteLine(fich);
            }

            //Para tratar con ficheros CSV:
            //1.- Leee el fichero con la info
            //2.-Tratar los datos
            //2.-Mostrar los resultados por consola

"

        }
    }
}
