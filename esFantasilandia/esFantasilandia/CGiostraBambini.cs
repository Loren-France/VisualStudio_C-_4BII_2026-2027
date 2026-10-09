using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esFantasilandia
{
    internal class CGiostraBambini : CAttrazioni, IFixable
    {

        private int EtàMassima, Prezzo;

        public CGiostraBambini(string nome, int capacitaMax, bool stato, int tempoRiparazione, double costoRiparazione, int etàMassima, int prezzo) : base(nome, capacitaMax, stato, tempoRiparazione, costoRiparazione)
        {
            this.EtàMassima = etàMassima;
            this.Prezzo = prezzo;
        }

        public override string ToString()
        {
            return base.ToString() + $"Età Massima: {EtàMassima}, Prezzo: {Prezzo}";
        }
    }
}
