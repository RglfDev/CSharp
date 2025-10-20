using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharp //Contenedor raiz del proyecto.
{
    internal class Program //Clase que solo se puede utilizar para este namespace.
    {

        struct fechaNacimiento
        {
            public int dia;
            public int mes;
            public int año;

        }

        struct tipoPersona
        {
            public string nombre;
            public char inicial;
            public int edad;
            public int fechaNacimiento diaNacimiento;
            public float nota;
        }

       
        static void Main(string[] args) // metodo main como JAVA.
        {
            //Console.WriteLine("Hola"); //Printear por consola.
            //Console.Write("Usuario: "); //Espera a que el usuario meta un valor para avanzar. Mientras muestra el string.
            // Console.ReadLine(); // Muestra todo lo obtenido hasta ahora por consola.
            // Console.ReadKey(); // Hace que la consola se pare mostrando los WriteLine que lleve, hasta que el usuario pulse un botón.

            Console.WriteLine(5 + 2);  //Aparecera 7 en la consola.


            /**Variables

            int primerNumero;
            primerNumero = 4;

            int segundoNumero = 543, tercerNumero = 567;

            Console.WriteLine(primerNumero); //Escribe una linea y salta a la linea siguiente

            int suma = primerNumero + segundoNumero + tercerNumero;

            Console.WriteLine("La suma es {0}",suma); // -> Cada posicion{0} indica por orden donde van a colocarse las variables (suma)
            Console.WriteLine("La suma es " + suma); //Formas de declarar variables en strigs
            Console.WriteLine($"La suma es {suma}"); // -> Literals, se abre con $"" y la variable va entre {}

            Console.WriteLine("La suma de {0} y {1} es {2}",primerNumero, segundoNumero,suma);

            Console.Write("Introduce un número: "); //Escribe una linea y se mantiene en la misma linea.
            int numeroPrimero = Convert.ToInt32(Console.ReadLine()); //Recogemos un valor por teclado y, como necesitamos que
                                                                     //sea int32, lo parseamos con Convert.

            Console.Write("Introduce un número: ");
            int numeroSegundo = Convert.ToInt32(Console.ReadLine());

            int operacion = numeroPrimero + numeroSegundo;

            Console.WriteLine($"La suma de {numeroPrimero} y {numeroSegundo} es {operacion}");

            //Para debugear basta con colocar los puntos rojos e ir saltando de paso en paso con la tecla F10

            Console.ReadKey();*/



            //Console.Write("Introduce en numero1:");
            //int numeroUno = Convert.ToInt32(Console.ReadLine());

            //Console.Write("Introduce en numero2:");
            //int numeroDos = Convert.ToInt32(Console.ReadLine());

            //int operacion = (numeroUno + numeroDos) * (numeroUno - numeroDos);
            //int cuadrados = (numeroUno*numeroUno) - (numeroDos*numeroDos);

            //Console.WriteLine($"La operación rara da como resultado {operacion}");
            //Console.WriteLine($"La operación de potencias da como resultado {cuadrados}");
            //Console.ReadKey();

            //Console.Write("Introduce un numero");
            //int numero = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("{0} * {1} = ({2}", numero, 1, numero * 1 );

            //Estructuras de control

            //IF-ELSE::
            // <, > , ==, !=, 
            //Console.WriteLine("Numero: ");
            //numero = Convert.ToInt32(Console.ReadLine());
            //if (numero > 0) Console.WriteLine("El numero es positivo"); //Si las condiciones no son muy grandes se pueden poner en la misma linea.
            //else Console.WriteLine("El numero es negativo");

            ////Operadores lógicos: 

            //int opcion = 3;
            //int usuario = 2;

            //if ( (opcion != 1) && (usuario == 2))
            //{

            //} 

            //Operador Condicional (TERNARIO):

            //nombreVariable = condicion ? valor1 : valor2 ((Esto es igual que en JAVASCRIPT))

            //int a, b, operacion, resultado;


            //Console.WriteLine("Numero: ");
            //a = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("Otro numero: ");
            //b = Convert.ToInt32(Console.ReadLine());

            //Console.Write("Escribe una operacion (1=Resta; otro=Suma)");
            //resultado = (operacion == 1) ? a - b : a + b;

            //Console.WriteLine($"El resultado es {resultado}");
            //Console.ReadKey();

            ////STRINGS

            //Valor inicial con comillas dobles:
            //string frase = "Hola que tal";
            //Console.Write("Introduce una frase: ");
            //string usuarioFrase = Console.ReadLine();

            //SWITCH:

            //Console.Write("Mete u nombre: ");
            //string nombre = Console.ReadLine();

            //switch (nombre)
            //{
            //    case "Juan":
            //        Console.WriteLine("Hola Juan");
            //        break;

            //    case "Antonio":
            //        Console.WriteLine("Hola Antonio");
            //        break;

            //    default:
            //        Console.WriteLine("Hola usuario");
            //        break;

            //}


            //While:

            //Console.Write("Numero: (0 para salir): ");
            //int numero = Convert.ToInt32(Console.ReadLine());

            //while (numero != 0)
            //{
            //    if (numero > 0) Console.WriteLine("Es positivo");
            //    else Console.WriteLine("Negativo");
            //    Console.WriteLine("Teclea otro numero (0 para salir)");
            //    numero = Convert.ToInt32(Console.ReadLine());

            //}

            //DO -WHILE

            //int valida = 711;
            //int clave;

            //do
            //{
            //    Console.Write("Clave Numerica: ");
            //    clave = Convert.ToInt32((valida).ToString());

            //    if (clave != valida) Console.WriteLine("No es valida");



            //} while (clave != valida);

            //Console.WriteLine("Clave aceptada");

            //Bucle FOR:
            //int contador = 0;

            //for (contador = 1; contador <= 10; contador++)
            //{
            //    if(contador == 4)
            //    break;



            //}

            //TRY_CATCH

            //int numero1, numero2, numero3;
            //try {
            //    Console.Write("Introduce el primer número: ");
            //    numero1 = Convert.ToInt32(Console.ReadLine());

            //    Console.Write("Introduce el segundo número: ");
            //    numero2 = Convert.ToInt32(Console.ReadLine());

            //    numero3 = numero1 / numero2;

            //    Console.WriteLine("La division es {0}", numero3);

            //}
            //catch(FormatException ex1)
            //{
            //    Console.WriteLine("Personalizar el mensaje", ex1.Message);
            //}
            //catch(DivideByZeroException ex1)
            //{
            //    Console.WriteLine("Ha habido un error; {0}", ex1.Message);
            //}

            //Tipos de datos

            //Decimales 


            ////Float Maximo de 7 cifras decimales (obligatorio subfijo f)
            //float calificacion = 12.5f;
            ////Convert.ToSingle()

            ////Double Maximo de 15 decimales (opcional subfijo n). La que mas vamos a usar.
            //double calificacion1 = 21.5;
            //double calificacion2 = 21.5d;
            ////Convert.ToDouble()

            ////Decimal Maximo de 15 dcimales(obligatorio subfijo m)
            //decimal totalPago = 2345.87m;
            ////Convert.ToDecimal()

            float primerNumero;
            double segundoNumero;
            decimal suma;

            Console.Write("Numero 1: ");
            primerNumero = Convert.ToSingle(Console.ReadLine());

            Console.Write("Numero 2: ");
            segundoNumero = Convert.ToDouble(Console.ReadLine());

            suma = Convert.ToDecimal(primerNumero + segundoNumero);

            Console.WriteLine($"{primerNumero} + {segundoNumero} = {suma}");
            Console.ReadKey();

            //Convertir de decimal a String:

            //double numero = 12.34;

            //Console.WriteLine(numero.ToString("N1"));//->12,3
            //Console.WriteLine(numero.ToString("N3"));//->12,340

            //Console.WriteLine(numero.ToString("0.0")); //-> 12.3
            //Console.WriteLine(numero.ToString("0.000")); //-> 12.340
            //Console.WriteLine(numero.ToString("#.#")); //-> 12.3
            //Console.WriteLine(numero.ToString("#.###")); //-> 12.340


            ////Datos tipo caracter:

            //char letra = 'a';

            ////Convert.ToChar

            //char letraTeclado = Convert.ToChar(Console.ReadLine());

            ////tipo Boolean

            //bool ultimoNivel = true;
            //int nivel = 10;

            //if (nivel == 10) ultimoNivel = !ultimoNivel;
            //int enemigos = 0;

            //bool partidaTerminada = (enemigos == 0) && ultimoNivel == false;


            ////ARRAYS

            //int[] numeros = new int[5];
            //numeros[0] = 200;
            //numeros[1] = 150;

            //int[] numeros2 = { 200, 150, 100, -30, 300 };

            //for(int i = 0; i < numeros2.Length; i++)
            //{
            //    suma += numeros2[i];

            //}

            //int[] datos = { 10, 15, 12, 0, 0 };
            //int capacidadArray = datos.Length;
            //int cantidad = 3;

            ////MOSTRAR ARRAY

            //for (int i = 0; i < capacidadArray; i++)
            //{
            //    Console.WriteLine($"{datos[i]}");

            //}

            ////Buscamos un valor = 15

            //for (int i = 0; i < capacidadArray; i++)
            //{
            //    if (datos[i] == 15)
            //    Console.WriteLine($"El 15 estaba en la posicion {i+1}");

            //}

            ////Añadir un dato en la primera posicion libre: 6

            //Console.WriteLine("Añadir el 6 al final");
            //if (cantidad < capacidadArray)
            //{
            //    datos[cantidad] = 6;
            //    cantidad++;

            //}

            //Console.ReadKey();


            ////Mostrar Array

            //for (int i = 0;i < capacidadArray; i++)
            //{
            //    Console.WriteLine($"{datos[i]}");
            //}


            ////Borrar un dato: el segundo

            //int posicionBorrar = 1;

            //for(int i = posicionBorrar; i<cantidad; i++)
            //{
            //    datos[i] = datos[i + 1];

            //}
            //cantidad--;

            ////Mostrar Array

            //for (int i = 0; i < capacidadArray; i++)
            //{
            //    Console.WriteLine($"{datos[i]}");
            //}


            ////Insertar en una posicion determinada 30 en la tercera posicion

            //if(cantidad < capacidadArray)
            //{
            //    Console.WriteLine("Hay hueco, insert 30 en la posicion 3");
            //    int posicionAInsertar = 2;
            //    for (int i = cantidad; i > posicionAInsertar; i--)
            //    {
            //        datos[i] = datos[i] - 1;

            //    }

            //    datos[posicionAInsertar] = 30;
            //    cantidad++;

            //}

            ////Gestion de arrays de diferentes tipos:

            //var mezcla = { 1, "Hola", true }; -> No tiraria

            //object[] datos = { 1, "hola", true,3.14,'A'}; // Permite almacenar diferentes tipos pero habria que castearlos para recuperarlos

            //foreach(var item in datos)
            //{
            //    Console.WriteLine($"{item} (tipo:{item.GetType()}"); 
            //}

            //int numero = (int)datos[0];
            //string cadena =(string)datos[1];

            //dynamic[] datos1 = {1, "hola", true, 3.14, 'A' }; //Este es el unico tipo que puede generar arrays con tipos combinados SIN castearlos

            //foreach (var item in datos1) ;


            ////Matrices:
            ///
            //int datosAlumnos[2, 3];

            //    int[,] notas = new int[2, 3] ->2 Colecciones, 3 valores en cada una
            //    {
            //        {8,7,9},
            //        {6,13,18}
            //    };

            //    for (int i = 0; i < notas.GetLength(0); i++)
            //    {
            //        int sumaTotal = 0;
            //        for (int j = 0; j < notas.GetLength(1); j++)
            //        {
            //            sumaTotal += notas[i, j];
            //        }
            //        double promedio = (double)suma/notas.GetLength(1);
            //        Console.WriteLine($"Alumno {i + 1} - Promedio : {promedio:F2}"); //-> F2: toFixed(2)
            //        Console.ReadKey();
            //    }
            //}


            ////Jagged Arrays

            //int[][] jagged = new int[3][];
            //jagged[0] = new int[] { 1, 2 };
            //jagged[1] = new int[] { 3, 4, 5 };
            //jagged[2] = new int[] { 6, 7, 8 };


            //int[][] notas;
            //notas = new int[3][]; //3 bloques de datos
            //notas[0] = new int[3];//3 notas en un grupo
            //notas[1] = new int[4];//4 notas en el segundo grupo
            //notas[2] = new int[2];//2 notas en el ultimo grupo

            //for (int i = 0; i < notas.Length; i++)
            //{
            //    for (int j = 0; j < notas[i].Length; j++)
            //    {

            //        notas[i][j] = i + j;
            //    }
            //}

            //for (int i = 0; i < notas.Length; i++)
            //{
            //    for (int j = 0; j < notas[i].Length; j++)
            //    {

            //        Console.WriteLine("{0}",notas[i][j] = i + j);
            //    }
            //}


            //Registros: agrupación de datos (campos) ->struct
            //Primero se declara la estructura FUERA del main (mirar arriba)
            //Luego se inicializa la instancia del objeto o lo que sea esto

            //tipoPersona persona;
            //persona.nombre = "Javier";
            //persona.inicial = 'J';
            //persona.edad = 26;
            //persona.nota = 7.5f;

            //tipoPersona[] personas = new tipoPersona[10];
            //personas[0].nombre = "Maria";
            //personas[8].nota = 3.2f;

            //tipoPersona persona;
            //persona.diaNacimiento.dia =

            //STRING 

            //Metodos para extraer una subcadena

            string frase = "Hola Master Desarrollo";
            string saludo = frase.Substring(0,4); //Recupera valores de string contenidos entre las posiciones de los dos numeros "Hola"

            string cadenaExtraer = "Master"; //palabra a extraer
            int posicion = frase.IndexOf(cadenaExtraer); //Posicion desde la que parte la palabra Master

            string porcion = frase.Substring(posicion, cadenaExtraer.Length); //Se saca la porcion utilizando la posicion y la longitud de la palabra


            double valor = 1.232323;
            Console.WriteLine(valor.ToString("F2")); //Devuelve el numero con dos decimales en string.
            Console.WriteLine(valor.ToString("C")); //Devuelve el resultado en moneda (con$ delante).
            Console.WriteLine(valor.ToString("P")); //saca el dato con porcentaje.


            string fraseLarga = "Hola buenos dias por la noche";

            char [] delimitadores = { ',', '.', ';' };

            string[] ejemploPartido = fraseLarga.Split(delimitadores); // Utiliza el array de caracteres para separar por los caracteres la frase

            for (int i = 0; i < ejemploPartido.Length; i++) //imprimimos el array
            {
                Console.WriteLine("Fragmento de {0} = {1}", i, ejemploPartido[i]);
            }

        }
    }
}
