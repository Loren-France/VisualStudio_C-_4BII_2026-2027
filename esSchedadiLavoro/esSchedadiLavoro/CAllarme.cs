using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esSchedadiLavoro
{
    internal class CAllarme : CDispositivoSmart, ISwitchable
    {
        public bool IsAcceso { get; private set; }
        public CAllarme() : base()
        {
            IsAcceso = false;
        }

        public void Accendi()
        {
            IsAcceso = true;
        }
        public void Spegni()
        {
            IsAcceso = false;
        }
        public override string MostraDettagli()
        {
            return $"Allarme: Stato: {(IsAcceso ? "Acceso" : "Spento")}";
        }
    }
}
