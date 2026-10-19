using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esCampionatoCalcistico_UsoJSON_
{
    internal class CPartita
    {
        public List<string> SquadraCasa { get; set; }
        public List<string> SquadraOspite { get; set; }
        public int GolCasa { get; set; }
        public int GolOspite { get; set; }

        public CPartita(List<string> squadraCasa, List<string> squadraOspite, int golCasa, int golOspite)
        {
            SquadraCasa = squadraCasa;
            SquadraOspite = squadraOspite;
            GolCasa = golCasa;
            GolOspite = golOspite;
        }

    }
}
