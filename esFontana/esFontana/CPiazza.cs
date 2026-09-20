namespace esFontana
{
    internal class CPiazza : CFontana
    {
        protected float Diametro;
        protected string Città, NomePiazza;

        public CPiazza(string Nome, string Autore, float CAcqua, bool Stato, float Diametro, string Città, string NomePiazza) : base(Nome, Autore, CAcqua, Stato)
        {
            this.Diametro = Diametro;
            this.Città = Città;
            this.NomePiazza = NomePiazza;
        }

        public string InfoPiazza()
        {
            return $"Piazza: {NomePiazza}, Città: {Città}, Diametro: {Diametro}";
        }

        public void ModificaPiazza(float nuovoDiametro, string nuovaCittà, string nuovoNomePiazza)
        {
            Diametro = nuovoDiametro;
            Città = nuovaCittà;
            NomePiazza = nuovoNomePiazza;
        }
    }
}
