using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 10.	Sistema de gestión de cuentas de usuario (herencia + interfaces + sobreescritura)
•	Crea una interfaz IAutenticable con métodos Login() y Logout().
Define una clase base CuentaUsuario con propiedades Usuario y Email.
Crea clases derivadas CuentaGratuita y CuentaPremium con distintos comportamientos de inicio de sesión y beneficios.

*/

namespace Ejercicio10
{
    internal class Program
    {
        interface IAutenticable
        {
            void Login(string usuario, string contraseña);
            void Logout();
        }

        abstract class CuentaUsuario
        {
            public string Usuario { get; set; }
            public string Email { get; set; }

            public CuentaUsuario(string usuario, string email)
            {
                Usuario = usuario;
                Email = email;
            }

            public abstract void Login(string usuario, string contraseña);

            public virtual void Logout()
            {
                Console.WriteLine($"{Usuario} ha cerrado la sesion.");
            }

            public abstract void MostrarBeneficios();
        }

        class CuentaGratuita : CuentaUsuario
        {
            public CuentaGratuita(string usuario, string email): base(usuario, email) { }

            public override void Login(string usuario, string contraseña)
            {
                Console.WriteLine($"Cuenta Gratuita Bienvenido {Usuario}. Tiene acceso limitado.");
            }

            public override void MostrarBeneficios()
            {
                Console.WriteLine("Acceso básico a contenido público y anuncios visibles");
            }
        }

        class CuentaPremium : CuentaUsuario 
        {
            public CuentaPremium(string usuario, string email): base(usuario, email) { }

            public override void Login(string usuario, string contraseña)
            {
                Console.WriteLine($"Cuenta Premium Bienvenido {Usuario}. Acceso completo concedido.");
            }

            public override void MostrarBeneficios()
            {
                Console.WriteLine("Acceso total a contenido público y SIN ANUNCIOS");
            }

        }

        static void Main(string[] args)
        {

            CuentaUsuario usu1 = new CuentaGratuita("maria123", "mama@mail.com");
            CuentaUsuario usu2 = new CuentaPremium("Paco333", "paco@mail.com");

            usu1.Login(usu1.Usuario, "1234");
            usu1.MostrarBeneficios();
            usu1.Logout();




        }
    }
}
