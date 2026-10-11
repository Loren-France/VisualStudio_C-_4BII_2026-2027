using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esFantasilandia
{
    internal interface IFixable
    {
        bool IsGuasto { get; set; }

        string Ripara();
        string SegnalaGuasto();
    }
}
