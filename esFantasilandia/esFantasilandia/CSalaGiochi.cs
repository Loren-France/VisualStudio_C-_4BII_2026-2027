using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esFantasilandia
{
    internal class CSalaGiochi : CAttrazioni
    {
        public int Gettoni { get; set; }

        public CSalaGiochi(string nome, int capacitaMax, bool stato, int tempoRiparazione, double costoRiparazione, int gettoni) : base(nome, capacitaMax, stato, tempoRiparazione, costoRiparazione)
        {
            this.Gettoni = gettoni;
        }

        public override string ToString()
        {
            return base.ToString() + $"Gettoni: {Gettoni}";
        }
    }
}
