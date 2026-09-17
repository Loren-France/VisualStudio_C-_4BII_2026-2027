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
            get { return CodiceFiscale; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length != 16)
                {
                    throw new Exception("Codice fiscale non valido.");
                }
                CodiceFiscale = value;
            }
        }

        public string Name
        {
            get { return Nome; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Nome non valido.");
                }
                Nome = value;
            }
        }

        public string Surname
        {
            get { return Cognome; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Cognome non valido.");
                }
                Cognome = value;
            }
        }
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

        public int Number
        {
            get { return Matricola; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Matricola non può essere negativa.");
                }

                Matricola = value;
            }
        }

        public string University
        {
            get { return Università; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Università non valida.");
                }

                Università = value;
            }
        }

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

        public string Subject
        {
            get { return Materia; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Materia non valida.");
                }
                Materia = value;
            }
        }

        public double Salary
        {
            get { return Salario; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Salario non può essere negativo.");
                }
                Salario = value;
            }
        }
    }
}
