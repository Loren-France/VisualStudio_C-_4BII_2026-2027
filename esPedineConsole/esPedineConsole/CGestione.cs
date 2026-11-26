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
        const int MaxCommand = 100;
        public string[] comandi;
        private int ComandNumber = 0;
        public string AfterCommand { get { return comandi[indice + 1]; } }
        public string NomeRe;
        public string[] NomiGuardie;
        public string[] NomiPedoni;
        string FileName = "input.txt";
        private int indice = 3;
        public bool terminato = false;

        //Necessità dell'evento cattura e attacca

        public event EventHandler<string>? Cattura;

        public event EventHandler? AttaccaRe;

        public CGestione()
        {
        }

        public void OnCattura(string nome)
        {
            Cattura?.Invoke(this, nome);
        }

        public void OnAttacca()
        {
            AttaccaRe?.Invoke(this, EventArgs.Empty);
        }

        public void Inizializza()
        {
            if (!File.Exists(FileName))
            {
                throw new FileNotFoundException($"Il file {FileName} non esiste.");
            }

            File.WriteAllText("output.txt", "");

            comandi = File.ReadAllLines(FileName);

            if (comandi.Length < 3)
                throw new InvalidDataException("Il file deve contenere almeno le tre righe con i nomi.");

            NomeRe = comandi[0].Trim();

            NomiGuardie = comandi[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

            NomiPedoni = comandi[2].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }

        //public void EseguiComando(string comando)
        //{

        //    if (indice >= comandi.Length || indice > MaxCommand)
        //    {
        //        terminato = true;
        //        return;
        //    }

        //    Registro.Add($"> {comando}");

        //    string[] parti = comando.Trim().Split(' ');

        //    if (parti[0] == "Attacca" && parti.Length == 2 && parti[1] == "Re")
        //    {
        //        AttaccaRe?.Invoke(this, EventArgs.Empty);
        //        Registro.Add(re.Azione());

        //        foreach (CGuardia g in guardie)
        //        {
        //            Registro.Add(g.Azione());
        //        }

        //        foreach (CPedone p in pedoni)
        //        {
        //            Registro.Add(p.Azione());
        //        }
        //    }
        //    else if (parti[0] == "Cattura" && parti.Length == 2)
        //    {
        //        string nome = parti[1];

        //        for (int i = 0; i < NomiGuardie.Length; i++)
        //        {
        //            if (NomiGuardie[i] == nome)
        //            {
        //                CGuardia guardia = guardie[i];
        //                Cattura?.Invoke(this, nome);
        //                NomiGuardie[i] = null;
        //                return;
        //            }
        //        }

        //        for (int i = 0; i < NomiPedoni.Length; i++)
        //        {
        //            if (NomiPedoni[i] == nome)
        //            {
        //                Cattura?.Invoke(this, nome);
        //                NomiPedoni[i] = null;
        //                return;
        //            }
        //        }
        //    }
        //    else if (comando.Trim() == "End")
        //    {
        //        Registro.Add("Simulazione terminata");

        //        terminato = true;
        //    }
        //    else
        //    {
        //        Registro.Add($"Comando non valido: {comando}");
        //    }
        //}

        public bool EseguiPasso()
        {
            if (terminato)
                return false;
            else if (ComandNumber == MaxCommand)
                return false;

            indice++;
            ComandNumber++;

            string comando = comandi[indice].Trim();

            if (comando == "Attacca Re")
            {
                AttaccaRe?.Invoke(this, EventArgs.Empty);
                return true;
            }

            if (comando.StartsWith("Cattura "))
            {
                string nome = comando.Substring("Cattura ".Length).Trim();
                Cattura?.Invoke(this, nome);
                return true;
            }

            if (comando == "End")
            {
                terminato = true;
                return true;
            }

            return false;
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
