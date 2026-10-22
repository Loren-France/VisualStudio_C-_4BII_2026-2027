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

            List<Object> provvisoria = new List<Object>();

            if (!File.Exists(fileName))
            {
                partite = new List<CPartita>();
                return;
            }

            string jsonString = File.ReadAllText(fileName);

            provvisoria = JsonSerializer.Deserialize<List<object>>(jsonString);

            partite = new List<CPartita>();

            foreach (var partita in provvisoria)
            {
                if (partita is JsonElement jsonElement)
                {
                    if (jsonElement.TryGetProperty("Fase", out JsonElement faseProperty))
                    {
                        string fase = faseProperty.GetString();
                        if (fase == "Girone")
                        {
                            CPartitaGirone partitaGirone = jsonElement.Deserialize<CPartitaGirone>();
                            partite.Add(partitaGirone);
                        }
                        else if (fase == "Finale")
                        {
                            CPartitaFinale partitaFinale = jsonElement.Deserialize<CPartitaFinale>();
                            partite.Add(partitaFinale);
                        }
                        else if (fase == "Eliminazione")
                        {
                            CPartitaEliminazione partitaEliminazione = jsonElement.Deserialize<CPartitaEliminazione>();
                            partite.Add(partitaEliminazione);
                        }
                    }
                }
            }
        }

        public void Salva()
        {
            string fileName = "ResocontoPartite.json";

            List<object> partite = new List<object>();

            foreach (var partita in this.partite)
            {
                if (partita is CPartitaGirone)
                {
                    partite.Add((CPartitaGirone)partita);
                }
                else if (partita is CPartitaFinale)
                {
                    partite.Add((CPartitaFinale)partita);
                }
                else if (partita is CPartitaEliminazione)
                {
                    partite.Add((CPartitaEliminazione)partita);
                }
            }

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
