using System;

namespace LorenzoFranceschetto_VerificaQuartiere
{
    internal abstract class CMateriale
    {
        public int Codice { get; set; }
        public string Titolo;
        public int AnnoPubblicazione { get; set; }
        public bool InPrestito { get; set; }
        public string Utente { get; set; }
        public DateOnly DataRestituzione { get; set; }

        public CMateriale(int code, string title, int anno)
        {
            this.Codice = code;
            this.Titolo = title;
            this.AnnoPubblicazione = anno;
            this.InPrestito = false;
            this.Utente = "";
        }

        public abstract double CalcolaPenale();

        public override string ToString()
        {
            return $"Codice: {Codice} | Titolo: {Titolo} | Anno pubblicazione: {AnnoPubblicazione} | Disponibilità: {(InPrestito ? $"In prestito | Utente: {Utente} | Data restituzione: {DataRestituzione}" : "Disponibile")}";
        }

    }
}
