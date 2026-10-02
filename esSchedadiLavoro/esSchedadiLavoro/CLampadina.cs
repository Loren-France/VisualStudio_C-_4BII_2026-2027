using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esSchedadiLavoro
{
    internal class CLampadina : CDispositivoSmart
    {
        int Luminosità;

        public CLampadina(string nome, string stanza, int luminosità) : base(nome, stanza)
        {
            this.Luminosità = luminosità;
        }

        public override string MostraDettagli()
        {
            return $"Lampadina: {Nome} / Stanza: {Stanza} / Luminosità: {Luminosità} / Stato: {(IsAcceso ? "Accesa" : "Spenta")}";
        }
    }
}
