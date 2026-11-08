namespace esRistoranteIndiano
{
    public enum CategoriaPiatto
    {
        Antipasto,
        PiattoPrincipale,
        Contorno,
        Pane,
        Dolce,
        Bevanda
    }

    internal class CPiatto
    {
        public string Nome { get; set; }
        public CategoriaPiatto Categoria { get; set; }
        public double Prezzo { get; set; }

        public CPiatto(string nome, CategoriaPiatto categoria, double prezzo)
        {
            Nome = nome;
            Categoria = categoria;
            Prezzo = prezzo;
        }

        public override string ToString()
        {
            return $"{Nome} - {Categoria} - {Prezzo:F2} €";
        }
    }
}
