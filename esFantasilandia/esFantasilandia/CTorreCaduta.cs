using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esFantasilandia
{
    internal class CTorreCaduta : CMontagnaRussa, IFixable
    {

        private int PesoMax, Supplemento, Prezzo;

        public CTorreCaduta(string nome, int capacitaMax, bool stato, int tempoRiparazione, int costoRiparazione, int etàMinima, int prezzo, bool fastPass, int pesoMax, int supplemento) : base(nome, capacitaMax, stato, tempoRiparazione, costoRiparazione, etàMinima, prezzo, fastPass)
        {
            this.PesoMax = pesoMax;
            this.Supplemento = supplemento;
            this.Prezzo = prezzo;
        }

        public override string ToString()
        {
            return base.ToString() + $"Peso Max: {PesoMax}, Supplemento: {Supplemento}";
        }

        public override int Costo()
        {
            return this.Prezzo + this.Supplemento;
        }

        public override bool VerificaVisitatore(CVisitatore visitatore)
        {
           if (visitatore.Peso > this.PesoMax || base.VerificaVisitatore(visitatore))
           {
                return false;
           }
           return true;
        }
    }
}
