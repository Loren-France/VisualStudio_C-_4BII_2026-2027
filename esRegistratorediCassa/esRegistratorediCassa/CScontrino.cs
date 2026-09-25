using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esRegistratorediCassa
{
    internal class CScontrino
    {
        private List<CArticolo> articoliAcquistati;
        private double totale;
        private DateTime data;
        private int numero;

        public CScontrino(int numero)
        {
            this.totale = totale;
            this.data = DateTime.Now;
            this.numero = numero;
            this.articoliAcquistati = new List<CArticolo>();
        }

        public List<CArticolo> ArticoliAcquistati
        {
            get { return articoliAcquistati; }
        }

        public DateTime Data
        {
            get { return data; }
        }

        public string Stampa()
        {
            return $"Scontrino n. {numero} - Data: {data.ToString(" dd/MM/yyyy mm:hh ")} - Totale: {totale}";
        }

        public void AggiungiArticolo(CArticolo articolo)
        {
            articoliAcquistati.Add(articolo);
            totale += articolo.Prezzo;
        }
    }
}
