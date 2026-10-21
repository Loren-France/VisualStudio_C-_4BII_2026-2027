using System;
using System.Collections.Generic;
using System.Text;

namespace esUEFA
{
    internal class CStatisticheSquadra : IComparable<CStatisticheSquadra>, IEquatable<CStatisticheSquadra>, IStampabile
    {
        public string Squadra { get; set; }
        public int PartiteGiocate { get; set; }
        public int Vittorie { get; set; }
        public int Pareggi { get; set; }
        public int Sconfitte { get; set; }
        public int GolFatti { get; set; }
        public int GolSubiti { get; set; }
        public int Punti { get; set; }
        public CStatisticheSquadra(string squadra)
        {
            Squadra = squadra;
            PartiteGiocate = 0;
            Vittorie = 0;
            Pareggi = 0;
            Sconfitte = 0;
            GolFatti = 0;
            GolSubiti = 0;
            Punti = 0;
        }

        public int DifferenzaReti
        {
            get
            {
                return GolFatti - GolSubiti;
            }
        }

        public bool Equals(CStatisticheSquadra other)
        {
            if (other == null)
                return false;
            
            if (this.Squadra.ToLower() == other.Squadra.ToLower())
                return true;
            else
                return false;
        }

        public int CompareTo(CStatisticheSquadra cStatisticheSquadra)
        {
            if (this.Punti > cStatisticheSquadra.Punti)
                return -1;
            else if (this.Punti < cStatisticheSquadra.Punti)
                return 1;
            else
                if (this.DifferenzaReti > cStatisticheSquadra.DifferenzaReti)
                    return -1;
                else if (this.DifferenzaReti < cStatisticheSquadra.DifferenzaReti)
                    return 1;
                else
                    if (this.GolFatti > cStatisticheSquadra.GolFatti)
                        return -1;
                    else if (this.GolFatti < cStatisticheSquadra.GolFatti)
                        return 1;
                    else
                        return this.Squadra.CompareTo(cStatisticheSquadra.Squadra);
        }

        public string Descrizione()
        {
            string build = "Squadra: " + Squadra + "\n";
            build += "Partite giocate: " + PartiteGiocate + "\n";
            build += "Vittorie: " + Vittorie + "\n";
            build += "Pareggi: " + Pareggi + "\n";
            build += "Differenza di reti: " + DifferenzaReti + "\n";
            build += "Sconfitte: " + Sconfitte + "\n";
            build += "Gol fatti: " + GolFatti + "\n";
            build += "Gol subiti: " + GolSubiti + "\n";
            build += "Punti: " + Punti + "\n";
            return build;
        }
    }
}
