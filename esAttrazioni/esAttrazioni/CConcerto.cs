using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esAttrazioni
{
    internal class CConcerto : CAttrazione
    {
        private string orario;
        private int numeroPosti;

        public CConcerto(string nome, double costo, string orario, int numeroPosti) : base(nome, costo)
        {
            this.orario = orario;
            this.numeroPosti = numeroPosti;
        }

        public override string Info()
        {
            return base.Info() + $", Orario: {orario.ToString()}, Numero posti: {numeroPosti}";
        }
    }
}
