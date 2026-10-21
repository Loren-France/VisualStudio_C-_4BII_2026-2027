using System;
using System.Collections.Generic;
using System.Text;

namespace esUEFA
{
    internal class CPartitaEliminazione : CPartita
    {
        public override string Fase { get; } = "Eliminazione";
        public int? RigoriCasa { get; set; }
        public int? RigoriOspite { get; set; }

        public CPartitaEliminazione(int giornata, string squadraCasa, string squadraOspite, int golCasa, int golOspite, int? rigoriCasa = null, int? rigoriOspite = null)
            : base(giornata, squadraCasa, squadraOspite, golCasa, golOspite)
        {
            RigoriCasa = rigoriCasa;
            RigoriOspite = rigoriOspite;
        }

        public override int PuntiPer(string squadra)
        {
            return 0;
        }

        public override string? CalcolaVincitore()
        {
            if (GolCasa > GolOspite)
                return SquadraCasa;
            else if (GolOspite > GolCasa)
                return SquadraOspite;
            else if (RigoriCasa > RigoriOspite)
                return SquadraCasa;
            else
                return SquadraOspite;
        }

        public override string Descrizione()
        {
            return base.Descrizione() + $"Rigori: {RigoriCasa} - {RigoriOspite}\n";
        }
    }
}
