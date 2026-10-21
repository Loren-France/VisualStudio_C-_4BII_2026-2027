using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Xml;
//using Newtonsoft.Json;

namespace esUEFA
{
    internal class RepositoryPartite : IRepository<CPartita>
    {
        private List<CPartita> partite;

        public RepositoryPartite()
        {
            partite = new List<CPartita>();
        }

        public void Carica()
        {
            string fileName = "ResocontoPartite.json";

            List<CPartitaEliminazione> provvisoria = new List<CPartitaEliminazione>();

            if (!File.Exists(fileName))
            {
                partite = new List<CPartita>();
                return;
            }

            string jsonString = File.ReadAllText(fileName);

            provvisoria = JsonSerializer.Deserialize<List<CPartitaEliminazione>>(jsonString);

            partite = new List<CPartita>();

            foreach (var partita in provvisoria)
            {
                partite.Add(partita);
            }
        }

        public void Salva()
        {
            string fileName = "ResocontoPartite.json";
            //jsonString += JsonSerializer.Serialize(partite[i], Formatting.Indented);
            string jsonString = JsonSerializer.Serialize(partite, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(fileName, jsonString);
        }

        public bool Aggiungi(CPartita elemento)
        {
            if (elemento == null)
                return false;

            foreach (CPartita partita in partite)
            {
                if (partita.Equals(elemento))
                    return false;
            }

            partite.Add(elemento);

            return true;
        }

        public bool Rimuovi(CPartita elemento)
        {
            if (elemento == null) return false;
            return partite.Remove(elemento);
        }

        public IReadOnlyList<CPartita> GetElenco()
        {
            return partite.AsReadOnly();
        }
    }
}
