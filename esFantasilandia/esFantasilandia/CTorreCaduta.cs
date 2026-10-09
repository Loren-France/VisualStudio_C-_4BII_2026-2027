using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esFantasilandia
{
    internal class CTorreCaduta : CMontagnaRussa, IFixable
    {

        private int PesoMax, Supplemento;

        public CTorreCaduta(string nome, int capacitaMax, bool stato, int tempoRiparazione, double costoRiparazione, int etàMinima, int prezzo, bool fastPass, int pesoMax, int supplemento) : base(nome, capacitaMax, stato, tempoRiparazione, costoRiparazione, etàMinima, prezzo, fastPass)
        {
            this.PesoMax = pesoMax;
            this.Supplemento = supplemento;
        }

        public override string ToString()
        {
            return base.ToString() + $"Peso Max: {PesoMax}, Supplemento: {Supplemento}";
        }
    }
}
