using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esSchedadiLavoro
{
    internal class CAllarme : ISwitchable
    {

        public bool IsAcceso { get; private set; }
        public CAllarme()
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
        public string MostraDettagli()
        {
            return $"Allarme: Stato: {(IsAcceso ? "Acceso" : "Spento")}";
        }
    }
}
