using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esAttrazioni
{
    internal class CMostraArte : CAttrazione
    {
        private string autore;
        private List<string> opere;

        public CMostraArte(string nome, double costo, string autore, List<string> opere) : base(nome, costo)
        {
            this.autore = autore;
            this.opere = opere;
        }

        public string Autor
        {
            get { return autore; }
            set { autore = value; }
        }

        public override string Info()
        {
            return base.Info() + $", Autore: {autore}, Opere: {string.Join("/ ", opere)}";
        }

        public string MostreAutore(string autore)
        {
            if (this.autore == autore)
            {
                return Info();
            }
            else
            {
                return $"Nessuna mostra dell'autore {autore} trovata.";
            }
        }
    }
}
