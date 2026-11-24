using System;
using System.Collections.Generic;
using System.Text;

namespace esReGuardiePedoni
{
    internal abstract class CPedina
    {
        public string Nome { get; set; }

        public CPedina()
        {
        }

        public abstract string Azione();
    }
}
