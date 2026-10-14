using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esContenutiMultimediali
{
    internal abstract class CElementoMultimediale : IComparable<CElementoMultimediale>
    {
        public string Nome {  get; set; }

        public CElementoMultimediale(string nome)
        {
            this.Nome = nome;
        }

        public abstract string ToString();

        public int CompareTo(CElementoMultimediale f)
        {
            return this.Nome.CompareTo(f.Nome);
        }
    }
}
