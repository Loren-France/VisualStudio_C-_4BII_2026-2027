using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Avalonia.Controls;
using Avalonia.Controls.Platform;

namespace esCanile;

public partial class MainWindow : Window
{
    static CCanile Canile;
    public MainWindow()
    {
        InitializeComponent();
        cmbRazza.ItemsSource = Enum.GetValues(typeof(Razza));
        Canile = new CCanile();
        Canile.LetturaDati();

        lstCani.Items.Clear();

        foreach (var cane in Canile.ListaCani)
        {
            lstCani.Items.Add(cane);
        }

        DataContext = this;
    }

    private void btnAggiungi_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        CCane aggiungere = new CCane();

        if (string.IsNullOrWhiteSpace(txtNome.Text))
        {
            txtMessage.Text = "Errore: il nome non può essere vuoto.";
            return;
        }

        aggiungere.Nome = txtNome.Text;

        if (!int.TryParse(txtEtà.Text, out int age) || age < 0)
        {
            txtMessage.Text = "Errore: l'età deve essere un numero intero positivo.";
            return;
        }

        aggiungere.Eta = age;

        if (cmbRazza.SelectedItem == null)
        {
            txtMessage.Text = "Errore: selezionare una razza.";
            return;
        }

        aggiungere.Razza = (Razza)cmbRazza.SelectedItem;

        if (calData.SelectedDate == null)
        {
            txtMessage.Text = "Errore: selezionare una data di arrivo.";
            return;
        }

        aggiungere.Data = (DateTime)calData.SelectedDate;

        if (In_salute.IsChecked == true)
        {
            aggiungere.Stato = true;
        }
        else if (Malato.IsChecked == true)
        {
            aggiungere.Stato = false;
        }
        else
        {
            txtMessage.Text = "Errore: selezionare lo stato di salute.";
            return;
        }

        if (string.IsNullOrWhiteSpace(txtDescrizione.Text))
        {
            aggiungere.Descrizione = "Nessuna descrizione";
        }
        else
        {
            aggiungere.Descrizione = txtDescrizione.Text;
        }

        Canile.AggiungiCane(aggiungere);
        Canile.SalvataggioDati();

        txtMessage.Text = "Il cane " + aggiungere.Nome + " aggiunto con successo!";
        txtMessage.IsVisible = true;

        lstCani.Items.Clear();

        foreach (var cane in Canile.ListaCani)
        {
            lstCani.Items.Add(cane);
        }

        return;
    }

    private void btnAdotta_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (lstCani.SelectedItem is CCane caneSelezionato)
        {
            Canile.AdottaCane(caneSelezionato);
            Canile.SalvataggioDati();

            txtMessage.Text = $"Il cane {caneSelezionato.Nome} è stato adottato!";
            txtMessage.IsVisible = true;
        }
        else
        {
            txtMessage.Text = "Errore: selezionare un cane da adottare.";
            txtMessage.IsVisible = true;
        }

        lstCani.Items.Clear();

        foreach (var cane in Canile.ListaCani)
        {
            lstCani.Items.Add(cane);
        }
    }
}