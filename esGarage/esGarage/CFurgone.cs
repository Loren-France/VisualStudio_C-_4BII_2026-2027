using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esGarage
{
    internal class CFurgone : CVeicolo
    {
        private int capacita;

        public CFurgone(string marca, int anno, int cilindrata, int capacita) : base(marca, anno, cilindrata)
        {
            this.capacita = capacita;
        }

        public override string InfoVeicolo()
        {
            return base.InfoVeicolo() + $", Capacità: {capacita} kg";
        }

    }
}
