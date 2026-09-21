using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esGarage
{
    internal class CFurgone : CVeicolo
    {
        private int capacità;

        public CFurgone(string marca, int anno, int cilindrata, int capacità) : base(marca, anno, cilindrata)
        {
            this.capacità = capacità;
        }

        public override string InfoVeicolo()
        {
            return base.InfoVeicolo() + $", Capacità: {capacità} kg";
        }

    }
}
