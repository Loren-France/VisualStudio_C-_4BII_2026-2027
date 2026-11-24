using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using esReGuardiePedoni;
using Microsoft.VisualBasic;
using Microsoft.Win32;

namespace esPedineConsole
{
    internal class CGestione
    {
        string[] comandi;
        public CRe re { get; } = new CRe();
        public ObservableCollection<CGuardia> guardie { get; } = new ObservableCollection<CGuardia>();
        public ObservableCollection<CPedone> pedoni { get; } = new ObservableCollection<CPedone>();
        public ObservableCollection<string> Registro { get; } = new ObservableCollection<string>();
        string FileName = "input.txt";
        private int indice = 3;
        private bool terminato = false;

        public CGestione()
        {
        }

        public void Inizializza()
        {
            if (!File.Exists(FileName))
            {
                throw new FileNotFoundException($"Il file {FileName} non esiste.");
            }

            File.WriteAllText("output.txt", "");

            comandi = File.ReadAllLines(FileName);

            re.Nome = comandi[0].Trim();

            string[] Nomi = comandi[1].Split(' ');

            foreach (string nome in Nomi)
            {
                CGuardia guardia = new CGuardia();
                guardia.Nome = nome.Trim();
                guardie.Add(guardia);
            }

            Nomi = comandi[2].Split(' ');

            foreach (string nome in Nomi)
            {
                CPedone pedone = new CPedone();
                pedone.Nome = nome.Trim();
                pedoni.Add(pedone);
            }
        }

        public void EseguiComando(string comando)
        {
            Registro.Add($"> {comando}");

            string[] parti = comando.Trim().Split(' ');

            if (parti[0] == "Attacca" && parti.Length == 2 && parti[1] == "Re")
            {
                Registro.Add(re.Azione());

                foreach (CGuardia g in guardie)
                {
                    Registro.Add(g.Azione());
                }

                foreach (CPedone p in pedoni)
                {
                    Registro.Add(p.Azione());
                }
            }
            else if (parti[0] == "Cattura" && parti.Length == 2)
            {
                string nome = parti[1];

                for (int i = 0; i < guardie.Count; i++)
                {
                    if (guardie[i].Nome == nome)
                    {
                        guardie.RemoveAt(i);
                        return;
                    }
                }

                for (int i = 0; i < pedoni.Count; i++)
                {
                    if (pedoni[i].Nome == nome)
                    {
                        pedoni.RemoveAt(i);
                        return;
                    }
                }
            }
            else if (comando.Trim() == "End")
            {
                Registro.Add("Simulazione terminata");

                terminato = true;
            }
            else
            {
                Registro.Add($"Comando non valido: {comando}");
            }
        }

        public void EseguiPasso()
        {
            if (terminato)
            {
                return;
            }

            if (indice >= comandi.Length)
            {
                terminato = true;
                return;
            }

            EseguiComando(comandi[indice].Trim());

            indice++;
        }

        public void EseguiTutto()
        {
            while (!terminato)
            {
                EseguiPasso();
            }
        }
    }
}
