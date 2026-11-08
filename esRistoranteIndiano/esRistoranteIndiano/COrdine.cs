using System;
using System.Collections.Generic;

namespace esRistoranteIndiano
{
    internal class COrdine
    {
        public List<CPiatto> PiattiOrdinati { get; set; }
        public List<int> QuantitàPiatti { get; set; }
        public int NumeroTavoloAssociato { get; set; }
        public DateTime DataOraOrdine { get; set; }
        public double TotaleOrdine { get; set; }

        public COrdine()
        {
            PiattiOrdinati = new List<CPiatto>();
            QuantitàPiatti = new List<int>();
            DataOraOrdine = DateTime.Now;
            NumeroTavoloAssociato = 0;
            TotaleOrdine = 0;
        }

        public override string ToString()
        {
            string builder = "Ordine per il tavolo " + NumeroTavoloAssociato + " del " + DataOraOrdine.ToString() + ": \n";
            for (int i = 0; i < PiattiOrdinati.Count; i++)
            {
                builder += $"{PiattiOrdinati[i].Nome} - Quantità: {QuantitàPiatti[i]} - Prezzo: {PiattiOrdinati[i].Prezzo * QuantitàPiatti[i]:F2} €\n";
            }
            builder += $"Totale Ordine: {CalcolaTotale():F2} €";
            return builder;
        }

        public void AggiungiPiatto(CPiatto piatto, int quantità)
        {
            PiattiOrdinati.Add(piatto);
            QuantitàPiatti.Add(quantità);
        }

        public void RimuoviPiatto(CPiatto piatto, int quantità)
        {
            PiattiOrdinati.Remove(piatto);
            QuantitàPiatti.Remove(quantità);
        }

        public double CalcolaTotale()
        {
            double totale = 0;
            for (int i = 0; i < PiattiOrdinati.Count; i++)
            {
                totale += PiattiOrdinati[i].Prezzo * QuantitàPiatti[i];
            }
            TotaleOrdine = totale;
            return TotaleOrdine;
        }
    }
}
