using System;
using System.Collections.Generic;
using System.Text;

namespace esUEFA
{
    internal class CPartitaGirone : CPartita
    {
        public override string Fase { get; } = "Girone";

        public CPartitaGirone(int giornata, string squadraCasa, string squadraOspite, int golCasa, int golOspite, DateTime? data)
            : base(giornata, squadraCasa, squadraOspite, golCasa, golOspite, data)
        {}

        public override int PuntiPer(string squadra)
        {
            if (squadra.ToLower() == SquadraCasa.ToLower())
            {
                if (GolCasa > GolOspite)
                    return 3;
                else if (GolCasa == GolOspite)
                    return 1;
                else
                    return 0;
            }
            else if (squadra.ToLower() == SquadraOspite.ToLower())
            {
                if (GolOspite > GolCasa)
                    return 3;
                else if (GolOspite == GolCasa)
                    return 1;
                else
                    return 0;
            }
            else
                throw new ArgumentException("La squadra specificata non ha partecipato a questa partita.");
        }


    }
}
