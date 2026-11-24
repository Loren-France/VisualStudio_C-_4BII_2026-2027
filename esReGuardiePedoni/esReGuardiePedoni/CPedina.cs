using System;
using System.Collections.Generic;
using System.Text;

namespace esReGuardiePedoni
{
    internal abstract class CPedina
    {
        public string Nome { get; set; }

        public CPedina(string nome)
        {
            this.Nome = nome;
        }

        public abstract string Azione();
    }
}
