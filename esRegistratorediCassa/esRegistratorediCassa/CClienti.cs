using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esRegistratorediCassa
{
    internal class CClienti
    {
        private bool tesseraFedeltà;
        private string nome, cognome;
        private List<CArticolo> articoliAcquistati;
        private int totaleSpesa;

        public CClienti(string nome, string cognome, bool tesseraFedeltà)
        {
            this.nome = nome;
            this.cognome = cognome;
            this.tesseraFedeltà = tesseraFedeltà;
            articoliAcquistati = new List<CArticolo>();
            totaleSpesa = 0;
        }

        public List<CArticolo> ArticoliAcquistati
        {
            get { return articoliAcquistati; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Cognome
        {
            get { return cognome; }
            set { cognome = value; }
        }

        public void AggiungiArticolo(CArticolo articolo)
        {
            articoliAcquistati.Add(articolo);
            totaleSpesa += articolo.Prezzo;
        }

        public string StampaScontrino()
        {
            string builder = "";
            builder += $"Cliente: {nome} {cognome}\n";
            if (tesseraFedeltà)
            {
                builder += "Tessera fedeltà: Sì\n";

            }
            else
            {
                builder += "Tessera fedeltà: No\n";
            }
                builder += "Articoli acquistati:\n";
            foreach (CArticolo articolo in articoliAcquistati)
            {
                builder += articolo.StampaArticolo() + "\n";
            }
            builder += $"Totale spesa: {totaleSpesa}\n";
            return builder;
        }
    }
}
