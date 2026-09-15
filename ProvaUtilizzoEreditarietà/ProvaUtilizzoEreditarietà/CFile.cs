using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaUtilizzoEreditarietà
{
    public class CFile
    {
        private string estensione;
        private double dimensione;

        public string Estensione
        {
            get { return estensione; }
            set { estensione = value; }
        }

        public double Dimensione
        {
            get { return dimensione; }
            set { dimensione = value; }
        }

        public CFile(string est, double dim)
        {
            estensione = est;
            dimensione = dim;
        }
        public string Apri()
        {
            return "File Aperto";
        }
    }

    public class CAudio : CFile
    {
        public int Volume { get; set; }
        public CAudio() : base(".mp3", 3.5) { Volume = 100; }

        public string Riproduci()
        {
            return "Sto riproducendo l’audio.";
        }
    }

    public class CImmagine : CFile
    {
        public int Pixel { get; set; }
        public CImmagine() : base(".jpg", 5.2) { Pixel = 1; }

        public string FiltraBiancoNero()
        {
            return "Ho applicato il filtro bianco e nero all'immagine.";
        }
    }

    public class CVideo : CFile
    {
        public float Durata { get; set; }
        public CVideo() : base(".mp4", 25.0) { Durata = 3.5f; } //Problema con tipologia di input, impossibile mettere un float se con con 'f' alla fine, altrimenti viene considerato un double e da errore.

        public string Visualizza()
        {
            return "Sto visualizzando il video.";
        }
    }
}
