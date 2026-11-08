using System;

namespace esRistoranteIndiano
{
    internal class CTavolo
    {
        private static int idTavolo = 0;
        public int Id { get; set; }
        public int PostiDisponibili { get; set; }
        public int NumeroClienti { get; set; }
        public bool Occupato { get; set; }
        public COrdine? OrdineAssociato { get; set; }
        public CTavolo()
        {
            idTavolo++;
            Id = idTavolo;
            PostiDisponibili = 0;
            Occupato = false;
            OrdineAssociato = null;
        }

        public override string ToString()
        {
            return $"Tavolo {Id} - Posti: {PostiDisponibili} - Clienti: {NumeroClienti} - Occupato: {(Occupato ? $"Sì" : "No")}";
        }

        public void AssegnaOrdine(COrdine ordine)
        {
            if (!Occupato)
            {
                OrdineAssociato = ordine;
                Occupato = true;
            }
            else
            {
                throw new Exception("Il tavolo è già occupato.");
            }
        }

        public void LiberaTavolo()
        {
            if (Occupato)
            {
                OrdineAssociato = null;
                Occupato = false;
                NumeroClienti = 0;
            }
            else
            {
                throw new Exception("Il tavolo non è occupato.");
            }
        }

        public void AggiungiPiatto(CPiatto piatto, int quantità)
        {
            if (OrdineAssociato != null)
            {
                OrdineAssociato.AggiungiPiatto(piatto, quantità);
            }
            else
            {
                throw new Exception("Non è possibile aggiungere un piatto a un tavolo senza ordine associato.");
            }
        }
    }
}
