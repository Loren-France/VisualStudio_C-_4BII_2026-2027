using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esRegistratorediCassa
{
    internal class CArticolo
    {
        protected long codicebarre;
        protected string descrizione;
        protected int prezzo;

        public CArticolo(long codicebarre, string descrizione, int prezzo)
        {
            this.codicebarre = codicebarre;
            this.descrizione = descrizione;
            this.prezzo = prezzo;
        }

        public int Prezzo
        {
            get { return prezzo; }
            set { prezzo = value; }
        }

        public long CodiceBarre
        {
            get { return codicebarre; }
            set { codicebarre = value; }
        }

        public virtual int Sconta()
        {
            int prezzoScontato = prezzo - (prezzo * 5 / 100);
            return prezzoScontato;
        }

        public virtual string StampaArticolo()
        {
            return $"Codice a barre: {codicebarre}, Descrizione: {descrizione}, Prezzo: {prezzo}";
        }

    }
}
