using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esAttrazioni
{
    internal class CGiostra : CAttrazione
    {
        private int numeroPosti;
        private string tema;

        public CGiostra(string nome, double costo, int numeroPosti, string tema) : base(nome, costo)
        {
            this.numeroPosti = numeroPosti;
            this.tema = tema;
        }

        public override string Info()
        {
            return base.Info() + $", Numero posti: {numeroPosti}, Tema: {tema}";
        }
    }
}
