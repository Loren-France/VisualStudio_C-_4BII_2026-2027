using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace esAutonoleggio;

public partial class MainWindow : Window
{
    static List<CVeicolo> Flotta = new List<CVeicolo>();
    public MainWindow()
    {
        InitializeComponent();
        CAuto AutoDiProva = new CAuto("AB123CD", "Pandino");
        CMoto MotoDiProva1 = new CMoto("AE456FG", "Kawasaki Ninja H2");
        CMoto MotoDiProva2 = new CMoto("FA123CT", "Stark Varg");
        CFurgone FurgoneDiProva = new CFurgone("CF789HI", "Iveco Daily");
        CAutoElettrica AutoElettricaDiProva = new CAutoElettrica("RF123GH", "Tesla Model 3", 500);
        Flotta.Add(AutoDiProva);
        Flotta.Add(MotoDiProva1);
        Flotta.Add(MotoDiProva2);
        Flotta.Add(FurgoneDiProva);
        Flotta.Add(AutoElettricaDiProva);
        lstVeicoli.ItemsSource = null;
        lstVeicoli.ItemsSource = Flotta;
    }

    private void cmbTipo_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (cmbTipo.SelectedIndex == 3)
        {
            Electric.IsVisible = true;
        }
        else
        {
            Electric.IsVisible = false;
        }
        return;
    }

    private void btnNuovo_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {

        if (cmbTipo.SelectedItem == null)
        {
            txtError.Text = "Selezionare un tipo di veicolo.";
            return;
        }
        else if (string.IsNullOrWhiteSpace(txtTarga.Text) || string.IsNullOrWhiteSpace(txtModello.Text))
        {
            txtError.Text = "Inserire targa e modello del veicolo.";
            return;
        }
        else if (cmbTipo.SelectedItem == "Auto Elettrica" && string.IsNullOrWhiteSpace(txtAutonomia.Text))
        {
            txtError.Text = "Inserire l'autonomia dell'auto elettrica.";
            return;
        }
        else
        {
            string targa = txtTarga.Text;

            if (targa.Length != 7)
            {
                txtError.Text = "La targa deve essere lunga 6 caratteri.";
                return;
            }

            string modello = txtModello.Text;
            CVeicolo nuovoVeicolo;
            switch (cmbTipo.SelectedIndex)
            {
                case 0:
                    nuovoVeicolo = new CAuto(targa, modello);
                    break;
                case 1:
                    nuovoVeicolo = new CMoto(targa, modello);
                    break;
                case 2:
                    nuovoVeicolo = new CFurgone(targa, modello);
                    break;
                case 3:
                    int autonomiaKm = 0;
                    if (!int.TryParse(txtAutonomia.Text, out autonomiaKm))
                    {
                        txtError.Text = "L'autonomia deve essere un numero intero.";
                        return;
                    }
                    nuovoVeicolo = new CAutoElettrica(targa, modello, autonomiaKm);
                    break;
                default:
                    txtError.Text = "Tipo di veicolo non valido.";
                    return;
            }

            foreach (CVeicolo veicolo in Flotta)
            {
                if (veicolo.Targa == nuovoVeicolo.Targa)
                {
                    txtError.Text = "Esiste già un veicolo con questa targa.";
                    return;
                }
            }

            Flotta.Add(nuovoVeicolo);
            txtError.Text = "Veicolo aggiunto con successo!";
            lstVeicoli.ItemsSource = null;
            lstVeicoli.ItemsSource = Flotta;
        }
    }

    private void btnPreventivo_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        string preventivo = "";
        int giorni = (int)nupGiorni.Value;
        double totalCosto = 0;

        if (lstVeicoli.SelectedItem != null)
        {
            CVeicolo veicoloSelezionato = (CVeicolo)lstVeicoli.SelectedItem;
            
            preventivo += $"Preventivo per {veicoloSelezionato.Modello} ({veicoloSelezionato.Tipo}) - Targa: {veicoloSelezionato.Targa}\n";
            preventivo += $"Giorni di noleggio: {giorni}\n";
            preventivo += $"Assicurazione: {(ckbAssicurazione.IsChecked == true ? "Sì" : "No")}\n";

            totalCosto = veicoloSelezionato.CalcolaCosto(giorni);
            if (ckbAssicurazione.IsChecked == true)
            {
                totalCosto += 15 * giorni;
            }

            preventivo += $"Costo totale: {totalCosto} €\n";

            if (veicoloSelezionato is CAutoElettrica autoElettrica)
            {
                preventivo += $"Ricarica inclusa - Autonomia: {autoElettrica.AutonomiaKm} km\n";
            }
        }
        else
        {
            preventivo = "Selezionare un veicolo dalla lista.";
        }
        txtPreventivo.Text = preventivo;
    }

    private void btnRimuovi_Click(object? sender, RoutedEventArgs e)
    {
        if (lstVeicoli.SelectedItem != null)
        {
            CVeicolo veicoloSelezionato = (CVeicolo)lstVeicoli.SelectedItem;
            Flotta.Remove(veicoloSelezionato);

            lstVeicoli.ItemsSource = null;
            lstVeicoli.ItemsSource = Flotta;

            txtPreventivo.Text = "Veicolo rimosso con successo.";
            btnPreventivo.IsEnabled = false;
            btnRimuovi.IsEnabled = false;
        }
    }

    private void lstVeicoli_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (lstVeicoli.SelectedItem != null)
        {
            btnPreventivo.IsEnabled = true;
            btnRimuovi.IsEnabled = true;
        }
        else
        {
            btnPreventivo.IsEnabled = false;
            btnRimuovi.IsEnabled = false;
        }
    }
}