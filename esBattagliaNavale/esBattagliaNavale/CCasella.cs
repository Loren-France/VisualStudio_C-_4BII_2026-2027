using System;
using System.Collections.Generic;
using System.Text;

namespace esBattagliaNavale
{
    internal class CCasella // ho fatto alcuni cambi di accessibilità per poter fare il passaggio del campo comune utilizzando internal anzichè public
    {
        public bool IsColpita { get; set; }
        public bool IsNave { get; set; }
        public int Riga { get; set; }
        public int Colonna { get; set; }

        public CCasella(int x, int y)
        {
            IsColpita = false;
            IsNave = false;
            Riga = x;
            Colonna = y;
        }

        public void Colpisci()
        {
            IsColpita = true;
        }

        public void PosizionaNave()
        {
            IsNave = true;
        }
    }
}
