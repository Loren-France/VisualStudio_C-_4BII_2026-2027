using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace esRistoranteIndiano
{
    internal class CRistorante
    {
        public List<CPiatto> Menu { get; }
        public List<CTavolo> ListaTavoli { get; }
        public List<COrdine> Storico { get; }
        public CRistorante()
        {
            Menu = new List<CPiatto>();
            InizializzaMenu();
            ListaTavoli = new List<CTavolo>();
            InizializzaTavoli();
            Storico = new List<COrdine>();
        }

        public void InizializzaTavoli()
        {
            /*ListaTavoli.Add(new CTavolo() { PostiDisponibili = 2 });
            ListaTavoli.Add(new CTavolo() { PostiDisponibili = 4 });
            ListaTavoli.Add(new CTavolo() { PostiDisponibili = 6 });
            ListaTavoli.Add(new CTavolo() { PostiDisponibili = 8 });*/
            ListaTavoli.Add(new CTavolo());
            ListaTavoli.Add(new CTavolo());
            ListaTavoli.Add(new CTavolo());
            ListaTavoli.Add(new CTavolo());
            for (int i = 0; i < ListaTavoli.Count; i++)
            {
                ListaTavoli[i].PostiDisponibili = (i + 1) * 2;
            }
        }

        public void InizializzaMenu()
        {
            CPiatto piatto1 = new CPiatto("Samosa", CategoriaPiatto.Antipasto, 4.50);
            CPiatto piatto2 = new CPiatto("Pakora", CategoriaPiatto.Antipasto, 4.00);
            CPiatto piatto3 = new CPiatto("Chicken Tikka", CategoriaPiatto.PiattoPrincipale, 11.00);
            CPiatto piatto4 = new CPiatto("Butter Chicken", CategoriaPiatto.PiattoPrincipale, 12.50);
            CPiatto piatto5 = new CPiatto("Chicken Curry", CategoriaPiatto.PiattoPrincipale, 12.00);
            CPiatto piatto6 = new CPiatto("Palak Paneer", CategoriaPiatto.PiattoPrincipale, 10.50);
            CPiatto piatto7 = new CPiatto("Dal", CategoriaPiatto.Contorno, 6.00);
            CPiatto piatto8 = new CPiatto("Biryani", CategoriaPiatto.PiattoPrincipale, 11.50);
            CPiatto piatto9 = new CPiatto("Naan", CategoriaPiatto.Pane, 2.50);
            CPiatto piatto10 = new CPiatto("Gulab Jamun", CategoriaPiatto.Dolce, 4.50);

            Menu.Add(piatto1);
            Menu.Add(piatto2);
            Menu.Add(piatto3);
            Menu.Add(piatto4);
            Menu.Add(piatto5);
            Menu.Add(piatto6);
            Menu.Add(piatto7);
            Menu.Add(piatto8);
            Menu.Add(piatto9);
            Menu.Add(piatto10);
        }

        public void AggiungiOrdineAStorico(COrdine ordine)
        {
            Storico.Add(ordine);
            SalvaDatiStorico();
        }

        public void RichiamoAggiungiPiattoATavolo(CTavolo tavolo, CPiatto piatto, int quantità)
        {
            tavolo.AggiungiPiatto(piatto, quantità);
        }

        public void SalvaDatiTavoli()
        {
            string filePath = "lista_Tavoli.json";

            string json = JsonSerializer.Serialize(ListaTavoli, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public void CaricaDatiTavoli()
        {
            string filePath = "lista_Tavoli.json";
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                List<CTavolo>? tavoliCaricati = JsonSerializer.Deserialize<List<CTavolo>>(json);
                if (tavoliCaricati != null)
                {
                    ListaTavoli.Clear();
                    foreach (CTavolo tavolo in tavoliCaricati)
                    {
                        ListaTavoli.Add(tavolo);
                    }
                }
            }
        }

        public void SalvaDatiStorico()
        {
            string filePath = "storico_Ordini.json";
            string json = JsonSerializer.Serialize(Storico, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public void CaricaDatiStorico()
        {
            string filePath = "storico_Ordini.json";
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                List<COrdine>? storicoCaricato = JsonSerializer.Deserialize<List<COrdine>>(json);
                if (storicoCaricato != null)
                {
                    Storico.Clear();
                    foreach (COrdine ordine in storicoCaricato)
                    {
                        Storico.Add(ordine);
                    }
                }
            }
        }
    }
}
