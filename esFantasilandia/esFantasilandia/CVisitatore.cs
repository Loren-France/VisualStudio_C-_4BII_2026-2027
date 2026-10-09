using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esFantasilandia
{
    internal class CVisitatore
    {
        public bool FastPass { get; set; }
        public int Altezza { get; set; }
        public int Peso { get; set; }
        public int Età { get; set; }

        public CVisitatore(bool fastPass, int altezza, int peso, int età)
        {
            this.FastPass = fastPass;
            this.Altezza = altezza;
            this.Peso = peso;
            this.Età = età;
        }
    }
}
