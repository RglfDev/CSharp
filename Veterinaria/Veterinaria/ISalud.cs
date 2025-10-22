using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria
{
    public interface ISalud
    {
        //Metodo para vacunar con parametro String
        void Vacunar(string vacuna);
        //Metodo para diagnosticar enfermedades en los animales con String
        void DetectarEnfermedad(string name);
    }
}
