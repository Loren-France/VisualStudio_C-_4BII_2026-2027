using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esRegistratorediCassa
{
    internal class CArticoloAlimentare : CArticolo
    {
        private int annoScadenza;

        public CArticoloAlimentare(long codicebarre, string descrizione, int prezzo, int annoScadenza) : base(codicebarre, descrizione, prezzo)
        {
            this.annoScadenza = annoScadenza;
        }

        public override int Sconta()
        {
            if (annoScadenza == DateTime.Now.Year)
            {
                return prezzo = prezzo - (prezzo * 20 / 100);
            }
            else
            {
                return prezzo;
            }
        }

        public override string StampaArticolo()
        {
            return base.StampaArticolo() + $", Anno di scadenza: {annoScadenza}";
        }

    }
}
