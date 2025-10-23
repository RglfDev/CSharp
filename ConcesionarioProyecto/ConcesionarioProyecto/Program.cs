using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace GestorVehículos
{
    /*Concesionario de Vehículos:
     * Este programa se ha desarrollado implementando una lista en la que se van guardando los vehiculos 
     * directamente desde la clase Main. Ademas, se ha hecho de tal manera que el propio constructor
     * lanza un metodo que va pidiendo los datos al usuario de los nuevos vehiculos y se van asignando
     * directamente a los atributos de cada objeto.*/
}
internal class Program
{
    //Interfaz de mantenimiento
    public interface IMantenimiento
    {
        void RealizarMantenimiento();
    }

    //Clase vehiculo que implementa la interfaz de mantenimiento.
    public abstract class Vehiculo: IMantenimiento
    {
        protected string Marca { get; set; }
        protected string Modelo { get; set; }
        protected int Año { get; set; }
        protected double Precio { get; set; }
        protected double PrecioBase { get; set; }

        //Constructor que llama al método DatosUsuario para pedir los datos por consola
        protected Vehiculo()
        {
            DatosUsuario();

        }

        //Metodo para recoger los datos del vehiculo por consola. Si no se ingresan datos o no son correctos, se asignan por defecto.
        protected virtual void DatosUsuario()
        {
            Console.Write("Ingresa la marca: ");
            Marca = Console.ReadLine();
            if (Marca == "" || Marca == null)
            {
                Console.WriteLine("La marca está vacía. Pr defecto se asignará Desconocido.");
                Marca = "Desconocido";
            }

            Console.Write("Ingresa el modelo: ");
            Modelo = Console.ReadLine();
            if (Modelo == "" || Modelo == null)
            {
                Console.WriteLine("El modelo está vacío. Pr defecto se asignará Desconocido.");
                Modelo = "Desconocido";
            }

            Console.Write("Ingresa el año: ");
            if (int.TryParse(Console.ReadLine(), out int año))
            {
                Año = año;
            }
            else
            {
                Año = 2025;
                Console.WriteLine("Valor no válido. Se le asignará por defecto AÑO: 2025....");
                
            }

            Console.Write("Ingresa el precio: ");
            if (double.TryParse(Console.ReadLine(), out double precio))
            {
                PrecioBase = precio;
            }
            else
            {
                PrecioBase = 0.0;
                Console.WriteLine("Valor no válido. Se le asignará por defecto valor 0$");
                
            }


        }

        //Método genérico para mostrar información de los vehículos.
        public void MostrarInfo()
        {
            Console.WriteLine($"{Marca} {Modelo}: Año {Año}");
        }

        //Método sobrecargado que, dependiendo de un booleano, mostraraá en las clases hijas una u otra información.
        public virtual void MostrarInfo(bool detallado)
        {
            if (detallado)
            {
                Console.WriteLine($"{Marca} {Modelo}:\t Año {Año}\t Precio: {Precio}");
            }
            else { MostrarInfo(); }
        }

        //Método abstracto para calcular el precio en las clases hijas, el cual lo hace a traves del precio base ingresado por consola.
        public abstract double CalcularPrecio(double precioBase);

        //Metodo abstracto de la interfáz de mantenimiento.
        public abstract void RealizarMantenimiento();

    }

    //Clase coche que hereda propiedades y accesos de Vehículo.
    public class Coche : Vehiculo
    {
        public int Puertas { get; set; }

        /*En el constructor no hace falta llamar al constructor si no tiene parametros ya que lo hereda 
         * automáticamente de la clase padre. (antes lo tenia puesto con :base(sin parametros), pero
         * quedaba bastante chapucero y así queda mas estético, aunque ambas consiguen el mismo
         * resultado)
         * Calculamos el precio desde el constructor con el método correspondiente.*/
        public Coche()
        {
            //Esto se ejecuta despues del constructor Padre.
            Precio = CalcularPrecio(PrecioBase);
        }

        /*Heredamos con "base." el método que pide los datos al usuario por consola de la clase padre y
         * le añadimos las peticiones por consola necesarias para terminar de construir el objeto Coche. */
        protected override void DatosUsuario()
        {
            base.DatosUsuario();
            Console.Write("Ingresa el nº de puertas (min 3 - max 8): ");
            if (int.TryParse(Console.ReadLine(), out int puertas) && puertas >= 3 && puertas <= 8)
                Puertas = puertas;
            else
            {
                Puertas = 5;
                Console.WriteLine("Valor no válido. Se pondrán por defecto 5 puertas.");
            }

        }

        /*Sobreescritura del método MostrarInfo, el cual si recibe un parámetro mostrará la info detallada del coche,
         * y si no, llama directamente al metodo alojado en la clase padre con .base*/
        public override void MostrarInfo(bool detallado)
        {
            if (detallado)
            {
                Console.WriteLine($"Coche: {Marca} {Modelo},\n\t Año: {Año},\n\t Puertas: {Puertas},\n\t Precio Base: ${PrecioBase:F2},\n\t Precio (0.21 IVA): ${Precio}");
            }
            else
            {
                base.MostrarInfo();
            }
        }

        //Metodo sobreescrito sencillo para calcular el precio total a partir del base mas el 0.21% de IVA.
        public override double CalcularPrecio(double precioBase)
        {
            return precioBase * 1.21;
        }

        //Metodo personalizado de la clase padre (procedente de la interfaz) para mostrar el mantenimiento necesario.
        public override void RealizarMantenimiento()
        {
            Console.WriteLine($"Para realizar el mantenimiento del {Marca} {Modelo} sería necesario revisar las ruedas, aceite y filtros");
        }
    }

    //Clase coche que hereda propiedades y accesos de Vehículo.
    public class Moto : Vehiculo
    {
        public bool Casco { get; set; }

        public Moto()
        {
            //Esto se ejecuta despues del constructor padre
            Precio = CalcularPrecio(PrecioBase);
        }

        //Metodo sobreescrito para pedir los datos correspondientes al usuario (implementa el de la clase padre + atributos nuevos.
        protected override void DatosUsuario()
        {
            base.DatosUsuario();

            Console.Write("Pulsa 1 si quieres incluir casco o 2 si no lo quieres: ");
            if (int.TryParse(Console.ReadLine(), out int opcion) && (opcion == 1 || opcion == 2))
            {
                Casco = (opcion == 1) ? true : false;
            }
            else
            {
                Casco = false;
                Console.WriteLine("Valor no válido. El casco NO irá incluido por defecto.");
                return;
            }

        }

        //Explicacion en la clase Coche
        public override void MostrarInfo(bool detallado)
        {
            if (detallado)
            {
                Console.WriteLine($"Moto: {Marca} {Modelo},\n\t Año: {Año},\n\t Casco incluido: " +
                    $"{(Casco ? "SI (+90$)" : "NO")},\n\t Precio Base: ${PrecioBase:F2},\n\t Precio (0.12 DESC): ${Precio}");
            }
            else
            {
                base.MostrarInfo();
            }
        }

        //Metodo para caluclar el precio aplicando un descuento y sumando el precio del casco.
        public override double CalcularPrecio(double precioBase)
        {
            if (Casco)
            {
                return (precioBase + 90) * (1 - 0.12);
            }
            else
            {
                return precioBase * (1 - 0.12);
            }
        }

        //Metodo para realizar el mantenimiento de la moto.
        public override void RealizarMantenimiento()
        {
            Console.WriteLine($"Para realizar el mantenimiento de la {Marca} {Modelo} sería necesario purgar frenos, aceite y cambio de suspensión.");
        }
    }

    //Clase Camion que hereda de la clase Vehiculo.
    public class Camion : Vehiculo
    {

        public bool CapacidadCarga { get; set; }

        public Camion()
        {
            //Primero se lanza el constructor de la clase padre.
            //Despues asigna el precio total a traves del metodo correspondiente al atributo.
            Precio = CalcularPrecio(PrecioBase);
        }

        //Metodo para pedir datos al usuario importando el metodo de la clase padre.
        protected override void DatosUsuario()
        {
            base.DatosUsuario();

            Console.Write("Elige una opción:\n\t1.Menos de 1000 Kg.\n\t2.Más de 1000 Kg.\nRespuesta: ");
            if (int.TryParse(Console.ReadLine(), out int opcion) && (opcion == 1 || opcion == 2))
            {
                CapacidadCarga = (opcion == 2) ? true : false;
            }
            else
            {
                CapacidadCarga = false;
                Console.WriteLine("Valor no válido. Por defecto se le asignara la carga de MENOS de 500 Kg.");
                return;
            }

        }

        public override void MostrarInfo(bool detallado)
        {
            if (detallado)
            {
                Console.WriteLine($"Camión: {Marca} {Modelo},\n\t Año: {Año},\n\t Capacidad de carga: " +
                    $"{(CapacidadCarga ? "Mas de 1000 Kg" : "Menos de 1000 Kg")},\n\t Precio Base: ${PrecioBase:F2},\n\t Precio (12% IVA): ${Precio}");
            }
            else
            {
                base.MostrarInfo();
            }
        }

        //Devuelve el precio total al atributo metiendole un 12% de IVA.
        public override double CalcularPrecio(double precioBase)
        {
            if (CapacidadCarga)
            {
                return (precioBase + 1500) * 1.12;
            }
            else
            {
                return precioBase * 1.12;
            }

        }

        //Muestra por consola el mantenimiento necesario del camión.
        public override void RealizarMantenimiento()
        {
            Console.WriteLine($"Para realizar el mantenimiento del {Marca} {Modelo} sería necesario revisar la cabina, modulo de carga y la suspensión neumática");
        }
    }

    //Clase principal que lanza el programa
    static void Main(string[] args)
    {
        //Lista donde guardaremos todos los vehiculos
        List<Vehiculo> listaVehiculos = new List<Vehiculo>();

        int opcion = 0;

        do
        {
            Console.WriteLine("\n--- MENÚ VEHÍCULOS ---");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("1. Agregar Coche");
            Console.WriteLine("2. Agregar Moto");
            Console.WriteLine("3. Agregar Camión");
            Console.WriteLine("4. Mostrar todos los vehículos");
            Console.WriteLine("5. Mostrar info de un vehículo");
            Console.WriteLine("6. Mostrar mantenimiento de un vehículo");
            Console.WriteLine("7. Eliminar vehículo por posición");
            Console.WriteLine("8. Salir");
            Console.WriteLine("----------------------------------------");
            Console.Write("Selecciona una opción: ");

            opcion = Convert.ToInt32(Console.ReadLine());
            /*Este menú va agregando a la lista, quitando de la lista o mostrando información de los vehiculos 
             * seleccionados dependiendo de la opcion escogida*/
            switch (opcion)
            {
                case 1:
                    listaVehiculos.Add(new Coche());
                    Console.WriteLine("Coche agregado correctamente.");
                    break;

                case 2:
                    listaVehiculos.Add(new Moto());
                    Console.WriteLine("Moto agregada correctamente.");
                    break;

                case 3:
                    listaVehiculos.Add(new Camion());
                    Console.WriteLine("Camión agregado correctamente.");
                    break;

                case 4:
                    if (listaVehiculos.Count == 0)
                    {
                        Console.WriteLine("No hay vehículos en la lista aún.");
                    }
                    else
                    {
                        Console.WriteLine("\n---> LISTADO DE VEHÍCULOS COMPLETO<---");
                        for (int i = 0; i < listaVehiculos.Count; i++)
                        {
                            Console.Write($"\n {i + 1}:");
                            listaVehiculos[i].MostrarInfo();
                        }
                    }
                    break;

                case 5:
                    if (listaVehiculos.Count == 0)
                    {
                        Console.WriteLine("No hay vehículos en la lista aún");
                        
                    }
                    else
                    {

                            Console.Write("Ingresa el número del vehículo: ");
                        if (int.TryParse(Console.ReadLine(), out int seleccion))
                        {
                            seleccion -= 1;

                            if (seleccion < 0 || seleccion > listaVehiculos.Count())
                            {
                                Console.Write("No hay ningún vehículo en esa posición");
                            }
                            else
                            {
                                listaVehiculos[seleccion].MostrarInfo(true);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error, introduce un dato válido");
                        }
                    }
                    break;

                case 6:
                    Console.Write("Ingresa el número del vehículo: ");
                    if (int.TryParse(Console.ReadLine(), out int selected))
                    {
                        selected -= 1;

                        if (selected < 0 || selected > listaVehiculos.Count())
                        {
                            Console.Write("No hay ningún vehículo en esa posición");
                        }
                        else
                        {
                            listaVehiculos[selected].RealizarMantenimiento();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error, introduce un dato válido");
                    }
                    break;

                case 7:
                    if (listaVehiculos.Count == 0)
                    {
                        Console.WriteLine("No hay vehículos para eliminar.");
                        break;
                    }

                    Console.Write("Ingresa el número del vehículo que quieres eliminar: ");
                    

                    if (int.TryParse(Console.ReadLine(), out int numero) && numero >= 1 && numero <= listaVehiculos.Count)
                    {
                        listaVehiculos.RemoveAt(numero - 1);
                        Console.WriteLine("Vehículo eliminado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("Número no válido. Debe estar entre 1 y " + listaVehiculos.Count);
                    }
                    break;

                case 8:
                    Console.WriteLine("Saliendo...");
                    break;
                        }
        } while (opcion != 8);
    }
}