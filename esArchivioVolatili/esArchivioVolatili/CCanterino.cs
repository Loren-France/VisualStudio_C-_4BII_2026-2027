using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esArchivioVolatili
{
    internal class CCanterino : CPennuto
    {
        public string CantoCaratteristico { get; set; }

        public CCanterino(int codiceUnivoco, string specie, string habitat, bool migratore, double aperturaAlare, string canto)
            : base(codiceUnivoco, specie, habitat, migratore, aperturaAlare)
        {
            CantoCaratteristico = canto;
        }

        public override string ToString()
        {
            string builder = base.ToString();
            builder += $"Canto: {CantoCaratteristico}\n";
            return builder;
        }

    }
}
