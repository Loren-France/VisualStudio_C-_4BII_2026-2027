using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esFantasilandia
{
    internal class CAttrazioni : IFixable
    {
        public string Nome { get; set; }
        public int CapacitaMax { get; set; }
        public bool Stato { get; set; }
    }
}
