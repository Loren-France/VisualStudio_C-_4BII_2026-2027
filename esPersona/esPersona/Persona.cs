using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace esPersona
{
    internal class Persona
    {
        protected string CodiceFiscale, Nome, Cognome;


        public Persona()
        {
            CodiceFiscale = "";
            Nome = "";
            Cognome = "";
        }

        public Persona(string CodiceFiscale, string Nome, string Cognome)
        {
            this.CodiceFiscale = CodiceFiscale;
            this.Nome = Nome;
            this.Cognome = Cognome;
        }

        public virtual string Print()
        {
            return $"Codice Fiscale: {CodiceFiscale}, Nome: {Nome}, Cognome: {Cognome}";
        }

        public string FiscalCode 
        { 
            get; 
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Il codice fiscale non può essere vuoto o nullo.");
                }
                CodiceFiscale = value;
            } 
        
        } // Questo è l'equivalente di mettere "get { return CodiceFiscale; } set { CodiceFiscale = value; }" dato che il compilatore crea il ritorno corretto
        public string Name { get; set; } //get { return Nome; } set { Nome = value; }
        public string Surname { get; set; } // get { return Cognome; } set { Cognome = value; }
    }

    internal class Studente : Persona
    {
        private int Matricola;
        private string Università;

        public Studente() : base ()
        {
            Matricola = 0;
            Università = "";
        }

        public Studente(string CodiceFiscale, string Nome, string Cognome, int Matricola, string Università) : base(CodiceFiscale, Nome, Cognome)
        {
            this.Matricola = Matricola;
            this.Università = Università;
        }

        public override string Print ()
        {
            return base.Print() + $", Matricola: {Matricola}, Università: {Università}";
        }

        public int Number { get; set; } // get { return Matricola; } set { Matricola = value; }
        public string University { get; set; } // get { return Unviersità; } set { Università = value; }

    }

    internal class Docente : Persona
    {
        private string Materia;
        private double Salario;

        public Docente() : base()
        {
            Materia = "";
            Salario = 0;
        }   

        public Docente (string CodiceFiscale, string Nome, string Cognome, string Materia, double Salario) : base (CodiceFiscale, Nome, Cognome)
        {
            this.Materia = Materia;
            this.Salario = Salario;
        }

        public override string Print()
        {
            return base.Print() + $", Materia: {Materia}, Salario: {Salario}";
        }

        public string Subject { get; set; } // get { return Materia; } set { Materia = value; }
        public double Salary { get; set; } // get { return Salario; } set { Salario = value; }
    }
}
