using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace GestorVehículos
{

}
internal class Program
{

    public interface IMantenimiento
    {
        void RealizarMantenimiento();
    }
    public abstract class Vehiculo: IMantenimiento
    {
        protected string Marca { get; set; }
        protected string Modelo { get; set; }
        protected int Año { get; set; }
        protected double Precio { get; set; }
        protected double PrecioBase { get; set; }

        protected Vehiculo()
        {
            DatosUsuario();

        }

        protected virtual void DatosUsuario()
        {
            Console.Write("Ingresa la marca: ");
            Marca = Console.ReadLine();

            Console.Write("Ingresa el modelo: ");
            Modelo = Console.ReadLine();

            Console.Write("Ingresa el año: ");
            if (int.TryParse(Console.ReadLine(), out int año))
            {
                Año = año;
            }
            else
            {
                Año = 2025;
                Console.WriteLine("Valor no válido. Se le asignará por defecto AÑO: 2025....");
                return;
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
                return;
            }


        }
        public void MostrarInfo()
        {
            Console.WriteLine($"{Marca} {Modelo}: Año {Año}");
        }

        public virtual void MostrarInfo(bool detallado)
        {
            if (detallado)
            {
                Console.WriteLine($"{Marca} {Modelo}:\t Año {Año}\t Precio: {Precio}");
            }
            else { MostrarInfo(); }
        }

        public abstract double CalcularPrecio(double precioBase);

        public abstract void RealizarMantenimiento();

    }
    public class Coche : Vehiculo
    {
        public int Puertas { get; set; }

        public Coche()
        {
            Precio = CalcularPrecio(PrecioBase);
        }

        protected override void DatosUsuario()
        {
            base.DatosUsuario();
            Console.Write("Ingresa el nº de puertas: ");
            if (int.TryParse(Console.ReadLine(), out int puertas) && puertas >= 3 && puertas <= 8)
                Puertas = puertas;
            else
            {
                Puertas = 5;
                Console.WriteLine("Valor no válido. Se pondrán por defecto 5 puertas.");
            }

        }

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

        public override double CalcularPrecio(double precioBase)
        {
            return precioBase * 1.21;
        }

        public override void RealizarMantenimiento()
        {

            Console.WriteLine($"Para realizar el mantenimiento del {Marca} {Modelo} sería necesario revisar las ruedas, aceite y filtros");
        }
    }

    public class Moto : Vehiculo
    {
        public bool Casco { get; set; }

        public Moto()
        {

            Precio = CalcularPrecio(PrecioBase);
        }

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

        public override void RealizarMantenimiento()
        {
            Console.WriteLine($"Para realizar el mantenimiento de la {Marca} {Modelo} sería necesario purgar frenos, aceite y cambio de suspensión.");
        }
    }

    public class Camion : Vehiculo
    {

        public bool CapacidadCarga { get; set; }

        public Camion()
        {
            Precio = CalcularPrecio(PrecioBase);
        }


        protected override void DatosUsuario()
        {
            base.DatosUsuario();

            Console.Write("Elige una opción:\n\t1.Menos de 1000 Kg.\n\t2.Más de 1000 Kg.\n\tRespuesta: ");
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
                    $"{(CapacidadCarga ? "Mas de 1000 Kg" : "Menos de 1000 Kg")},\n\t Precio Base: ${PrecioBase:F2},\n\t Precio (0.21 IVA): ${Precio}");
            }
            else
            {
                base.MostrarInfo();
            }
        }

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

        public override void RealizarMantenimiento()
        {
            Console.WriteLine($"Para realizar el mantenimiento del {Marca} {Modelo} sería necesario revisar la cabina, modulo de carga y la suspensión neumática");
        }
    }

    static void Main(string[] args)
    {
        List<Vehiculo> listaVehiculos = new List<Vehiculo>();

        int opcion = 0;

        do
        {
            Console.WriteLine("\n--- MENÚ VEHÍCULOS ---");
            Console.WriteLine("1. Agregar Coche");
            Console.WriteLine("2. Agregar Moto");
            Console.WriteLine("3. Agregar Camión");
            Console.WriteLine("4. Mostrar todos los vehículos");
            Console.WriteLine("5. Mostrar info de un vehículo");
            Console.WriteLine("6. Mostrar mantenimiento de un vehículo");
            Console.WriteLine("7. Eliminar vehículo por posición");
            Console.WriteLine("8. Salir");
            Console.Write("Selecciona una opción: ");

            opcion = Convert.ToInt32(Console.ReadLine());

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
                        Console.WriteLine("No hay vehículos en la lista.");
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