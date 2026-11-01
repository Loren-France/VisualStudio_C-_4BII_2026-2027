using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;

namespace esCanile
{
    internal class CCanile
    {
        public List<CCane> ListaCani { get; set; }

        public CCanile()
        {
            ListaCani = new List<CCane>();
        }

        public void AggiungiCane(CCane cane)
        {
            ListaCani.Add(cane);
        }

        public void AdottaCane(CCane cane)
        {
            ListaCani.Remove(cane);
        }

        public void LetturaDati()
        {
            string fileName = "ResocontoCanile.json";

            if (!File.Exists(fileName))
            {
                ListaCani = new List<CCane>();
                return;
            }

            string jsonString = File.ReadAllText(fileName);

            ListaCani = JsonSerializer.Deserialize<List<CCane>>(jsonString);
        }

        public void SalvataggioDati()
        {
            string fileName = "ResocontoCanile.json";

            //jsonString += JsonSerializer.Serialize(partite[i], Formatting.Indented);
            string jsonString = JsonSerializer.Serialize(ListaCani, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(fileName, jsonString);
        }
    }
}
