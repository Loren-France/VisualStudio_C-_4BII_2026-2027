using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esSchedadiLavoro
{
    public abstract class CDispositivoSmart : ISwitchable
    {
        public string Nome { get; protected set; }
        public string Stanza { get; protected set; }

        public bool IsAcceso { get; protected set; }

        public CDispositivoSmart()
        {
            IsAcceso = false;
        }

        public CDispositivoSmart(string nome, string stanza)
        {
            Nome = nome;
            Stanza = stanza;
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

        public abstract string MostraDettagli();
    }
}
