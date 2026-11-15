using System;
using System.Collections.Generic;
using LorenzoFranceschetto_VerificaQuartiere;

namespace Biblioteca_Fraceschetto
{
    public enum TipoMateriale
    {
        Libro,
        Audiolibro,
        Rivista
    }
    internal class CGetioneBiblioteca
    {
        public List<CMateriale> Materiali { get; }

        public CGetioneBiblioteca()
        {
            Materiali = new List<CMateriale>();
            InizializzaBiblioteca();
        }

        public void AggiungiMateriale(CMateriale mat)
        {
            Materiali.Add(mat);
        }

        public void PrestaMateriale(CMateriale mat, string utente, DateOnly date)
        {
            mat.InPrestito = true;
            mat.Utente = utente;
            mat.DataRestituzione = date;
        }

        public void RestituisciMateriale(CMateriale mat)
        {
            mat.InPrestito = false;
            mat.Utente = "";
        }

        public void InizializzaBiblioteca()
        {
            CLibro book = new CLibro(125, "Libro 1", 1990, "Autore 1");
            CAudiolibro audio = new CAudiolibro(256, "Audiolibro 1", 2005, "Autore 2", 35);
            CRivista rivista = new CRivista(504, "Rivista 1", 1965, 12);

            AggiungiMateriale(book);
            AggiungiMateriale(audio);
            AggiungiMateriale(rivista);
        }
    }
}
