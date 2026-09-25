using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esRegistratorediCassa
{
    internal class CRegistratore
    {
        protected List<CScontrino> scontrini;
        protected static int numeroScontrino = 1;
        protected int num;

        public CRegistratore()
        {
            scontrini = new List<CScontrino>();
            num = numeroScontrino;
        }

        public void EmettiScontrino()
        {
            CScontrino newScontrino = new CScontrino(num);
            scontrini.Add(newScontrino);
            numeroScontrino++;
            num = numeroScontrino;
        }
        public void CancellaScontrino()
        {
            if (scontrini.Count > 0)
            {
                scontrini.RemoveAt(scontrini.Count - 1);
            }
        }

        public void Sort()
        {
            CScontrino temporanea;

            for (int j = 0; j < scontrini.Count - 1; j++)
            {
                if (scontrini[j].Data > scontrini[j + 1].Data)
                {
                    temporanea = scontrini[j];
                    scontrini[j] = scontrini[j + 1];
                    scontrini[j + 1] = temporanea;
                }
            }
        }

        public void RichiamoAggiunta(CArticolo articolo)
        {
            scontrini[scontrini.Count - 1].AggiungiArticolo(articolo);
        }

        public string ListScontrini()
        {
            string builder = "";

            foreach (CScontrino scontrino in scontrini)
            {
                builder += scontrino.Stampa() + "\n";
            }
            return builder;
        }
    }
}