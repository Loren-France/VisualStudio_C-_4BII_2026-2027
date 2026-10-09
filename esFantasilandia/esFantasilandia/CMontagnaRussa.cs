using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esFantasilandia
{
    internal class CMontagnaRussa : CAttrazioni, IFixable
    {

        private int EtàMinima, Prezzo;
        private bool FastPass;

        public CMontagnaRussa(string nome, int capacitaMax, bool stato, int tempoRiparazione, double costoRiparazione, int etàMinima, int prezzo, bool fastPass) : base(nome, capacitaMax, stato, tempoRiparazione, costoRiparazione)
        {
            this.EtàMinima = etàMinima;
            this.Prezzo = prezzo;
            this.FastPass = fastPass;
        }

        public override string ToString()
        {
            return base.ToString() + $"Età Minima: {EtàMinima}, Prezzo: {Prezzo}, FastPass: {FastPass}";
        }
    }
}
