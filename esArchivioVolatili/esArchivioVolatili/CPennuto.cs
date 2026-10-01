using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esArchivioVolatili
{
    internal class CPennuto
    {
        public List<CAvvistamento> Avvistamenti { get; set; }
        public int CodiceUnivoco { get; set; }
        public string Specie { get; set; }
        public string Habitat { get; set; }
        public bool Migratore { get; set; }
        public double AperturaAlare { get; set; }

        public CPennuto(int codiceUnivoco, string specie, string habitat, bool migratore, double aperturaAlare)
        {
            CodiceUnivoco = codiceUnivoco;
            Specie = specie;
            Habitat = habitat;
            Migratore = migratore;
            AperturaAlare = aperturaAlare;
            Avvistamenti = new List<CAvvistamento>();
        }

        public virtual string ToString()
        {
            string builder = "";
            builder += $"Codice Univoco: {CodiceUnivoco}\n";
            builder += $"Specie: {Specie}\n";
            builder += Migratore ? "Migratore: Sì\n" : "Migratore: No\n";
            builder += $"Migratore: {Migratore}\n";
            builder += $"Apertura Alare: {AperturaAlare} cm\n";

            builder += this.StampaAvvistamenti();

            return builder;
        }

        public void AggiungiAvvistamento(CAvvistamento avvistamento)
        {
            Avvistamenti.Add(avvistamento);
        }

        // string migratoreString = Migratore ? "Sì" : "No";

        public string StampaAvvistamenti()
        {
            string builder = "";

            builder += "Avvistamenti:\n";
            foreach (var avvistamento in Avvistamenti)
            {
                builder += $"{avvistamento.StampaAvvistamento()}\n";
            }
            return builder;
        }
    }
}
