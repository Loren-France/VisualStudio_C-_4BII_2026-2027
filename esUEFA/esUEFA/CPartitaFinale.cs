using System;
using System.Collections.Generic;
using System.Text;

namespace esUEFA
{
    internal class CPartitaFinale : CPartitaEliminazione
    {
        public override string Fase { get; } = "Finale";

        public CPartitaFinale(int giornata, string squadraCasa, string squadraOspite, int golCasa, int golOspite, int? rigoriCasa = null, int? rigoriOspite = null, DateTime? data = null)
            : base(giornata, squadraCasa, squadraOspite, golCasa, golOspite, rigoriCasa, rigoriOspite, data)
        {}

        public override int PuntiPer(string squadra)
        {
            return 0;
        }

        public override string Descrizione()
        {
            string build = base.Descrizione();

            build += $"Fase: {Fase}\n";

            return build;
        }
    }
}
