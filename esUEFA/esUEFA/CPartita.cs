using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esUEFA
{
    internal abstract class CPartita : IRisultato, IStampabile, IComparable<CPartita>, IEquatable<CPartita>
    {
        private static string criterio;

        private int giornata;
        private string squadraCasa;
        private string squadraOspite;
        private int golCasa;
        private int golOspite;
        private DateTime? data;

        public CPartita(int giornata, string squadraCasa, string squadraOspite, int golCasa, int golOspite, DateTime? data)
        {
            this.Giornata = giornata;
            this.SquadraCasa = squadraCasa;
            this.SquadraOspite = squadraOspite;
            this.GolCasa = golCasa;
            this.GolOspite = golOspite;
            this.data = data;
        }

        public static string Criterio
        {
            get { return criterio; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Il criterio non può essere vuoto.");

                criterio = value;
            }
        }

        public int Giornata
        {
            get { return giornata; }
            set
            {
                if (value < 1)
                    throw new ArgumentException("La giornata deve essere un numero positivo.");

                giornata = value;
            }
        }

        public string SquadraCasa
        {
            get { return squadraCasa; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La squadra di casa non può essere vuota.");

                squadraCasa = value;
            }
        }

        public string SquadraOspite
        {
            get { return squadraOspite; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La squadra ospite non può essere vuota.");

                squadraOspite = value;
            }
        }

        public int GolCasa
        {
            get { return golCasa; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("I gol della squadra di casa non possono essere negativi.");

                golCasa = value;
            }
        }

        public int GolOspite
        {
            get { return golOspite; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("I gol della squadra ospite non possono essere negativi.");

                golOspite = value;
            }
        }

        public DateTime? Data
        {
            get { return data; }
            set { data = value; }
        }

        public abstract string Fase { get; }

        public abstract int PuntiPer(string squadra);

        public virtual string Descrizione()
        {
            string build = "Squadra di casa: " + SquadraCasa + "\n";
            build += "Squadra ospite: " + SquadraOspite + "\n";
            build += $"Risultato: {GolCasa} - {GolOspite}\n";
            if (Data != null)
                build += $"Data: {Data.Value.ToShortDateString()}\n";
            return build;
        }

        public virtual string? CalcolaVincitore()
        {
            if (GolCasa > GolOspite)
                return SquadraCasa;
            else if (GolOspite > GolCasa)
                return SquadraOspite;
            else if (GolCasa == GolOspite)
                return null;
            else
                return "Caso impossibile";
        }

        public bool Equals(CPartita? partita)
        {
            if (partita == null)
                return false;

            if (this.Giornata == partita.Giornata && this.SquadraCasa.ToLower() == partita.SquadraCasa.ToLower() && this.SquadraOspite.ToLower() == partita.SquadraOspite.ToLower())
                return true;

            return false;
        }

        // OVERLOADING OPERATORE
        // public static bool operator ==(CPartita p1, CPartita p2)
        // public static bool operator !=(CPartita p1, CPartita p2) { return !(p1 == p2); }
        // Comparable confronta un oggetto con un altro, comparer confronta due oggetti tra loro

        public static bool operator ==(CPartita p1, CPartita p2)
        {
            if (p1 is null || p2 is null)
                return false;

            return p1.Equals(p2);
        }

        public static bool operator !=(CPartita p1, CPartita p2)
        {
            return !(p1 == p2);
        }

        public int CompareTo(CPartita? partita)
        {
            string criterio = Criterio.ToLower();

            if (criterio == "naturale")
            {
                if (this.Giornata < partita.Giornata)
                    return -1;
                else if (this.Giornata > partita.Giornata)
                    return 1;
                else
                    return this.SquadraCasa.CompareTo(partita.SquadraCasa);
            }
            else if (criterio == "gol")
            {
                if (this.GolCasa + this.GolOspite > partita.GolCasa + partita.GolOspite)
                    return -1;
                else if (this.GolCasa + this.GolOspite < partita.GolCasa + partita.GolOspite)
                    return 1;
                else
                    return 0;
            }
            else if (criterio == "scarto")
            {
                if (this.CalcolaScarto() > partita.CalcolaScarto())
                    return -1;
                else if (this.CalcolaScarto() < partita.CalcolaScarto())
                    return 1;
                else
                    return 0;
            }
            else if (criterio == "casaAZ")
            {
                if (this.SquadraCasa.ToLower() == partita.SquadraCasa.ToLower())
                    return 0;
                else if (this.SquadraCasa.ToLower().CompareTo(partita.SquadraCasa.ToLower()) < 0)
                    return -1;
                else
                    return 1;
            }
            else if (criterio == "casaZA")
            {
                if (this.SquadraCasa.ToLower() == partita.SquadraCasa.ToLower())
                    return 0;
                else if (this.SquadraCasa.ToLower().CompareTo(partita.SquadraCasa.ToLower()) < 0)
                    return 1;
                else
                    return -1;
            }
            else if (criterio == "data")
            {
                if (this.Data == null && partita.Data == null)
                    return 0;
                else if (this.Data == null)
                    return 1;
                else if (partita.Data == null)
                    return -1;
                else if (this.Data < partita.Data)
                    return -1;
                else if (this.Data > partita.Data)
                    return 1;
                else
                    return 0;
            
            }
            else
            {
                throw new ArgumentException("Criterio di ordinamento non valido.");
            }

            return 0;
        }

        public int CalcolaGolTotali()
        {
            return GolCasa + GolOspite;
        }

        public int CalcolaScarto()
        {
            return Math.Abs(GolCasa - GolOspite);
        }

        public Esito CalcolaEsito()
        {
            if (GolCasa > GolOspite)
                return Esito.VittoriaCasa;
            else if (GolOspite > GolCasa)
                return Esito.VittoriaOspite;
            else
                return Esito.Pareggio;
        }
    }
}
