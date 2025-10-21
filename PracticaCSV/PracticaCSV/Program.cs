using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

/**
 * Pasos a seguir: 
•	Crear un nuevo proyecto de consola en Visual Studio. 
•	Colocar el archivo productos.csv en la carpeta del ejecutable del proyecto. 
•	Definir una clase Producto con las propiedades Id, Nombre, Categoria, Precio y Stock. 
•	Leer el archivo con StreamReader línea a línea, ignorando la cabecera. 
•	Separar los valores usando Split(',') y convertirlos a los tipos adecuados. 
•	Guardar los objetos en una lista de Producto. 
•	Procesar los datos usando bucles y diccionarios para calcular: 
o	El valor total del inventario por categoría (Precio × Stock). 
o	El producto más caro y más barato de cada categoría. 
•	Mostrar los resultados por consola. 
•	Opcional: guardar un resumen en un nuevo archivo inventario_resultados.csv con StreamWriter.*/

namespace PracticaCSV
{
    internal class Program
    {
        //Clase producto que almacenará cada producto del TXT
        class Producto
        {
            public int Id {  get; set; }
            public string Nombre { get; set; }
            public string Categoria { get; set; }
            public double Precio { get; set; }
            public int Stock {  get; set; }
        }
        static void Main(string[] args)
        {
            //Rutas del CSV y del fichero de Resultados
            string rutaCSV = "productos.csv";
            string nombreArchivo = "Resultado.txt";
            

            //Creación de la lista Productos para almacenar los objetos Producto
            List<Producto> productos = new List<Producto>();

            //Creación de un idioma "Inglés" para parsear los decimales (el español no reconoce el . en los textos)
            CultureInfo Inglesa = new CultureInfo("en-US");

            try
            {
                //Apertura del método de lectura de ficheros
                using (StreamReader sr = new StreamReader(rutaCSV))
                {
                    //Lógica para saltar la linea de los títulos
                    string linea;
                    bool primeraLinea = true;

                    while ((linea = sr.ReadLine()) != null)
                    {
                        if (primeraLinea)
                        {
                            primeraLinea = false;
                            continue;
                        }
                    //Separación de los elementos del CSV por ","
                        string[] columnas = linea.Split(',');

                    //Guardamos los datos en un objeto nuevo a cada vuelta
                        Producto producto = new Producto
                        {
                            Id = int.Parse(columnas[0]),
                            Nombre = columnas[1],
                            Categoria = columnas[2],
                            Precio = double.Parse(columnas[3], Inglesa),
                            Stock = int.Parse(columnas[4])
                        };
                        productos.Add(producto);

                    }
                }


                //Apertura del mecanismo de escritura de ficheros
                //Conforme se vayan generando strings de salida, se mostrarán tanto en consola como en el fichero
                using (StreamWriter sw = new StreamWriter(nombreArchivo))
                {

                    string console1 = "-----Lista de productos-----";
                    Console.WriteLine(console1);
                    sw.WriteLine(console1);

                    //Impresión por ambas salidas de la lista total de productos extraidos del CSV
                    foreach (var producto in productos)
                    {
                        string console2 = $"ID: {producto.Id} - Nombre: {producto.Nombre} - Categoria: " +
                            $"{producto.Categoria} - Precio: {producto.Precio} - Stock: {producto.Stock}";

                        Console.WriteLine(console2);
                        sw.WriteLine(console2);
                    }

                    //Creación del diccionario que conendrá los elementos clave(nombreCategoría) y valor(Lista de elementos por categoría)
                    Dictionary<string, List<Producto>> Categorias = new Dictionary<string, List<Producto>>();


                    /* Por cada Key, si no existe ninguna key en el diccionario con esa categoria se crea y se añade el objeto correspondiente a esta.*/
                    foreach (var p in productos)
                    {
                        
                        if (!Categorias.ContainsKey(p.Categoria))
                        {
                            Categorias[p.Categoria] = new List<Producto>();
                        }

                        Categorias[p.Categoria].Add(p);

                    }


                    string console3 = "----Productos por categoria-----";
                    Console.WriteLine(console3);
                    sw.WriteLine();
                    sw.WriteLine(console3);

                    /*Bucles anidados para sacar los totales por categoría, máximos y mínimos:
                     * ---- Primer ForEach ----
                     * Con el primer bucle nos situamos en la key de cada categoría, y con el segundo tratamos los valores de la lista que contiene:
                     * 1- Recorremos las Keys para sacar el título con la variable {p}.
                     * 2- Variable para ir guardando la suma de los totales a cada vuelta del bucle.
                     *  ---- Segundo ForEach ----
                     * 3- Bucle anidado donde "c" representa cada objeto guardado, a traves de la cual accederemos a sus valores.
                     * 4- Impresión de los datos de cada categoría por cada vuelta de bucle en ambas salidas.
                     * 5- Vamos sumando el precio * cantidad de cada elemento de la lista y añadiendolo al total.
                     * 6- Impresión del precio total.
                     * 7- Sacamos los valores máximos y mínimos de cada categoría a través del precio.
                     * 8- Impresión de estos últimos valores en cada vuelta del ciclo.
                     */

                    //1
                    foreach (var p in Categorias.Keys)
                    {
                        string console4 = $"Categoria {p}\n--------------------------------";
                        Console.WriteLine(console4);
                        sw.WriteLine(console4);
                        //2
                        double totalCat = 0.0;
                        //3
                        foreach (var c in Categorias[p])
                        {
                        //4
                            string console5 = $"ID: {c.Id} - Nombre: {c.Nombre} - Categoria: " +
                                $"{c.Categoria} - Precio: {c.Precio} - Stock: {c.Stock}";
                            Console.WriteLine(console5);
                            sw.WriteLine(console5);
                        //5
                            totalCat += c.Precio * c.Stock;
                        }
                        //6
                        string console6 = $"Precio total de {p} = {totalCat:F2}";
                        Console.WriteLine(console6);
                        sw.WriteLine(console6);

                        //7
                        double caro = Categorias[p].Max(e => e.Precio);
                        double barato = Categorias[p].Min(e => e.Precio);

                        //8
                        string console7 = $"El mas caro es {caro} y el mas barato es {barato}\n";
                        Console.WriteLine(console7);
                        sw.WriteLine(console7);
                    }
                }


            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        
        }
    }
}
