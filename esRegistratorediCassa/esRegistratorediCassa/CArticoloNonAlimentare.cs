using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace esRegistratorediCassa
{
    public enum Materiale
    {
        Plastica,
        Carta,
        Vetro,
        Metallo,
        Legno
    }
    internal class CArticoloNonAlimentare : CArticolo
    {

        private Materiale materiale;

        public CArticoloNonAlimentare(long codicebarre, string descrizione, int prezzo, Materiale materiale) : base(codicebarre, descrizione, prezzo)
        {
            this.materiale = materiale;
        }

        public override int Sconta()
        {
            if (materiale == Materiale.Plastica || materiale == Materiale.Carta || materiale == Materiale.Vetro)
            {
                return prezzo = prezzo - (prezzo * 10 / 100);
            }
            else
            {
                return prezzo;
            }
        }

        public override string StampaArticolo()
        {
            return base.StampaArticolo() + $", Materiale: {materiale}";
        }
    }
}
