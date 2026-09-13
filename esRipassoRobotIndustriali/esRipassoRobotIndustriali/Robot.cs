using System;
using System.Collections.Generic;
using System.Text;

namespace esRipassoRobot
{
    internal class Robot
    {
        private string Modello;
        private float Potenza;
        private int Stato;
        private int Anno;

        public Robot(string modello, float potenza, int stato, int anno)
        {
            this.Modello = modello;
            this.Potenza = potenza;
            this.Stato = stato;
            this.Anno = anno;
        }

        public string Visualizza()
        {
            return $"Modello: {this.Modello}, Potenza: {this.Potenza}, Stato: {this.Stato}, Anno: {this.Anno}";
        }

        public float Power
        {
            get
            {
                return this.Potenza;
            }
        }

        public int State
        {
                get { 
                    return this.Stato; 
                }
        }

        public int Year
        {
            get
            {
                return this.Anno;
            }
        }
    }
}
