using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esFantasilandia
{
    internal class CSalaGiochi : CAttrazioni, IFixable
    {
        public int GettoniRichiesti { get; }
        public int PrezzoPerGettone { get; }

        public CSalaGiochi(string nome, int capacitaMax, bool stato, int tempoRiparazione, int costoRiparazione,int PrezzoPerGettone, int GettoniRichiesti) : base(nome, capacitaMax, stato, tempoRiparazione, costoRiparazione)
        {
            this.GettoniRichiesti = GettoniRichiesti;
            this.PrezzoPerGettone = PrezzoPerGettone;
        }


        public override string ToString()
        {
            return base.ToString() + $"Gettoni richiesti: {GettoniRichiesti}, Prezzo Gettone: {PrezzoPerGettone}";
        }

        public override int Costo()
        {
            return this.GettoniRichiesti * this.PrezzoPerGettone;
        }

        public override bool VerificaVisitatore(CVisitatore visitatore)
        {
            if (visitatore.Gettoni < this.GettoniRichiesti)
            {
                return false;
            }
            return true;
        }

        public int UsaPerVisitatore(CVisitatore visitatore)
        {
            if (visitatore.Gettoni >= this.GettoniRichiesti)
            {
                visitatore.Gettoni -= this.GettoniRichiesti;
                return this.Costo();
            }
            return 0;
        }

        public override int Vendi(CVisitatore visitatore)
        {
            if (VerificaVisitatore(visitatore))
            {
                visitatore.Gettoni -= this.GettoniRichiesti;
                return Costo();
            }
            return 0;
        }
    }
}
