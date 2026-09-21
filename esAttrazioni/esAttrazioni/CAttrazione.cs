using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace esAttrazioni
{
    internal class CAttrazione
    {
        protected string nome;
        protected double costo;

        public CAttrazione(string nome, double costo)
        {
            this.nome = nome;
            this.costo = costo;
        }

        public virtual string Info()
        {
            return $"Nome: {nome}, Costo biglietto: {costo} euro";
        }


    }
}
