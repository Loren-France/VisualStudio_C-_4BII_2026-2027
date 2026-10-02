using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esSchedadiLavoro
{
    internal interface ISwitchable
    {
        void Accendi();
        void Spegni();
        bool IsAcceso { get; }

        string MostraDettagli();
    }
}
