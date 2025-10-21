using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria
{
    public interface ISalud
    {
        void Vacunar(string vacuna);
        void DetectarEnfermedad(string name);
    }
}
