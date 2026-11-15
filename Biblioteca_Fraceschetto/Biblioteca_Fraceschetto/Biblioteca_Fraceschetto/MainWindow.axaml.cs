using System;
using Avalonia.Controls;
using LorenzoFranceschetto_VerificaQuartiere;

namespace Biblioteca_Fraceschetto;

public partial class MainWindow : Window
{
    static CGetioneBiblioteca Biblioteca = new CGetioneBiblioteca();

    public MainWindow()
    {
        InitializeComponent();
        cmbTipiMateriale.ItemsSource = Enum.GetValues(typeof(TipoMateriale));
        lstMateriali.ItemsSource = null;
        lstMateriali.ItemsSource = Biblioteca.Materiali;
    }

    private void btnPrestito_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        CMateriale? selected = (CMateriale)lstMateriali.SelectedItem;

        if (selected == null)
        {
            txtInfoMateriale.Text = "Selezionare un materiale in biblioteca.";
            return;
        }

        if (selected.InPrestito)
        {
            txtInfoMateriale.Text = "Il materiale selezionato è già in prestito.";
            return;
        }

        string utente = txtUtente.Text;

        if (string.IsNullOrWhiteSpace(utente))
        {
            txtInfoMateriale.Text = "Inserire il nome di un utente.";
            return;
        }

        if (cdtDate.SelectedDate == null)
        {
            txtInfoMateriale.Text = "Selezionare la data prevista di restituzione.";
            return;
        }

        DateOnly dataRestituzione = DateOnly.FromDateTime((DateTime)cdtDate.SelectedDate);
        if (dataRestituzione < DateOnly.FromDateTime(DateTime.Now))
        {
            txtInfoMateriale.Text = "La data prevista di restituzione non può essere precedente alla data odierna.";
            return;
        }

        Biblioteca.PrestaMateriale(selected, utente, dataRestituzione);
        txtInfoMateriale.Text = "Materiale preso in prestito correttamente.";
        lstMateriali.ItemsSource = null;
        lstMateriali.ItemsSource = Biblioteca.Materiali;
    }

    private void lstMateriali_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        CMateriale? selected = (CMateriale)lstMateriali.SelectedItem;


        if (selected == null)
        {
            txtInfoMateriale.Text = "Selezionare un materiale in biblioteca.";
            return;
        }

        txtInfoMateriale.Text = $"Materiale selezionato: \n {selected.ToString()}";
    }

    private void btnRestituisci_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        CMateriale? selected = (CMateriale)lstMateriali.SelectedItem;

        if (selected == null)
        {
            txtInfoMateriale.Text = "Selezionare un materiale in biblioteca.";
            return;
        }

        if (!selected.InPrestito)
        {
            txtInfoMateriale.Text = "Il materiale selezionato non è in prestito.";
            return;
        }

        double penale = selected.CalcolaPenale();
        Biblioteca.RestituisciMateriale(selected);
        txtPenale.Text = $"Costo penale: {penale:F2} €";
        txtInfoMateriale.Text = "Materiale restituito correttamente.";
        lstMateriali.ItemsSource = null;
        lstMateriali.ItemsSource = Biblioteca.Materiali;
    }

    private void btnAggiungi_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (cmbTipiMateriale.SelectedItem == null)
        {
            txtInfoMateriale.Text = "Selezionare il tipo di materiale.";
            return;
        }

        string titolo = txtTitolo.Text;

        if (string.IsNullOrWhiteSpace(titolo))
        {
            txtInfoMateriale.Text = "Inserire il titolo del materiale.";
            return;
        }

        int codice = (int)numCodice.Value;

        if (codice <= 0)
        {
            txtInfoMateriale.Text = "Inserire un codice valido (maggiore di 0).";
            return;
        }

        int anno = (int)numAnno.Value;

        if (anno <= 0 || anno > DateTime.Now.Year)
        {
            txtInfoMateriale.Text = "Inserire un anno valido (maggiore di 0 e minore o uguale all'anno corrente).";
            return;
        }

        CMateriale materiale;

        TipoMateriale tipo = (TipoMateriale)cmbTipiMateriale.SelectedItem;

        switch (tipo)
        {
            case TipoMateriale.Libro:
                string autoreLibro = txtAutore.Text;
                if (string.IsNullOrWhiteSpace(autoreLibro))
                {
                    txtInfoMateriale.Text = "Inserire l'autore del libro.";
                    return;
                }

                materiale = new CLibro(codice, titolo, anno, autoreLibro);
                break;

            case TipoMateriale.Audiolibro:
                string autoreAudiolibro = txtAutore.Text;
                if (string.IsNullOrWhiteSpace(autoreAudiolibro) || numDurata.Value is not decimal durataValue)
                {
                    txtInfoMateriale.Text = "Inserire autore e durata dell'audiolibro.";
                    return;
                }

                materiale = new CAudiolibro(codice, titolo, anno, autoreAudiolibro, Convert.ToInt32(durataValue));
                break;

            case TipoMateriale.Rivista:
                
                int numeroUscitaValue = (int)numNumeroUscita.Value;

                materiale = new CRivista(codice, titolo, anno, numeroUscitaValue);
                break;

            default:
                txtInfoMateriale.Text = "Tipo di materiale non valido.";
                return;
        }

        Biblioteca.AggiungiMateriale(materiale);
        lstMateriali.ItemsSource = null;
        lstMateriali.ItemsSource = Biblioteca.Materiali;
        txtInfoMateriale.Text = "Materiale aggiunto correttamente.";
    }
}