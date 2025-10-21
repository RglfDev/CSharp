using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * 6.	Sistema de pagos electrónicos (interfaces + clases derivadas + sobrecarga)
        •	Crea una interfaz IPago con un método ProcesarPago(double monto).
        •   Crea clases PagoTarjeta, PagoEfectivo y PagoTransferencia.
        •   Cada una debe implementar la interfaz y comportarse diferente.
        •   Sobrecarga ProcesarPago para incluir variantes con comisión.
*/
namespace Ejercicio6
{
    internal class Program
    {
        public interface IPago
        {
            double ProcesarPago(double monto);
        }


        public abstract class PagoBase : IPago
        {
            public string Moneda { get; set; }
            protected PagoBase (string moneda)
            {
                Moneda = moneda;
            }

            public abstract void ProcesarPago(double monto);

            public void ProcesarPago(double monto, double comision)
            {
                double total = monto + comision;
                Console.WriteLine("Procesando pago de {total: 0.00")
            }
        }

        public class PagoTarjeta : PagoBase
        {


        }

        public class PagoEfectivo : PagoBase
        {

        }

        public class PagoTransferenia : PagoBase
        {

        }


        static void Main(string[] args)
        {
        }
    }
}
