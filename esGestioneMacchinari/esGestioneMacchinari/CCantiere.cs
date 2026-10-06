using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esGestioneMacchinari
{
    internal class CCantiere
    {
        public string Nome { get; set; }
        public List<CMacchinariPesanti> Macchinari { get; set; }

        public CCantiere(string nome)
        {
            this.Nome = nome;
            this.Macchinari = new List<CMacchinariPesanti>();
        }

        public void AggiungiMacchinario(CMacchinariPesanti macchinario)
        {
            this.Macchinari.Add(macchinario);
            macchinario.AssegnaMacchinario();
        }

        public void LiberaMacchinario(CMacchinariPesanti macchinario)
        {
            this.Macchinari.Remove(macchinario);
            macchinario.LiberaMacchinario();
        }
    }
}
