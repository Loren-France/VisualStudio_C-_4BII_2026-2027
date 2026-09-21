using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esGarage
{
    internal class CMoto : CVeicolo
    {
        private int tempi;

        public CMoto(string marca, int anno, int cilindrata, int tempi) : base(marca, anno, cilindrata)
        {
            this.tempi = tempi;
        }

        public override string InfoVeicolo()
        {
            return base.InfoVeicolo() + $", Tempi: {tempi}";
        }

    }
}
