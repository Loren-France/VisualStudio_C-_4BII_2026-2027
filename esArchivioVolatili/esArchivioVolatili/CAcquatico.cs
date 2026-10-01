using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esArchivioVolatili
{
    public enum TipoAcqua
    {
        Dolce, Salata
    }
    internal class CAcquatico : CPennuto
    {

        public TipoAcqua Tipo { get; set; }

        public CAcquatico(int codiceUnivoco, string specie, string habitat, bool migratore, double aperturaAlare, TipoAcqua tipo)
            : base(codiceUnivoco, specie, habitat, migratore, aperturaAlare)
        {
            Tipo = tipo;
        }

        public override string ToString()
        {
            string builder = base.ToString();
            builder += $"Tipo di Acqua: {Tipo.ToString()}\n";
            return builder;
        }

    }
}
