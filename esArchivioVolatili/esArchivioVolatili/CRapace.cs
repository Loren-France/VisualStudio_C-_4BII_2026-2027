using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esArchivioVolatili
{
    internal class CRapace : CPennuto
    {
        public string Dieta { get; set; }

        public CRapace(int codiceUnivoco, string specie, string habitat, bool migratore, double aperturaAlare, string dieta)
            : base(codiceUnivoco, specie, habitat, migratore, aperturaAlare)
        {
            Dieta = dieta;
        }

        public override string ToString()
        {
            string builder = base.ToString();
            builder += $"Dieta: {Dieta}\n";
            return builder;
        }
    }
}
