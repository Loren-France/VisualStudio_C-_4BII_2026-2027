namespace esFontana
{
    internal class CFontana
    {
        private string Nome, Autore;
        private float CAcqua;
        private bool Stato;
        private List<string> Manutenzioni;

        public CFontana(string Nome, string Autore, float CAcqua, bool Stato)
        {
            this.Nome = Nome;
            this.Autore = Autore;
            this.CAcqua = CAcqua;
            this.Stato = Stato;
            this.Manutenzioni = new List<string>();
        }

        public string Name
        {
            get { return Nome; }
            set { Nome = value; }
        }

        public void AggiungiManutenzione(string add)
        {
            Manutenzioni.Add(add);
        }

        public void EliminaManutenzione(string remove)
        {
            Manutenzioni.Remove(remove);
        }

        public void AggiornaLivelloAcqua(float nuovoCAcqua)
        {
            CAcqua = nuovoCAcqua;
        }


    }
}
