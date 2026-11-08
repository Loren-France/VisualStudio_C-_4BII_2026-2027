using System;
using Avalonia.Controls;

namespace esRistoranteIndiano;

public partial class MainWindow : Window
{
    static CRistorante Ristorante = new CRistorante();
    public MainWindow()
    {
        InitializeComponent();
        Ristorante.CaricaDatiTavoli();
        Ristorante.CaricaDatiStorico();
        lstStorico.ItemsSource = Ristorante.Storico;
        lstMenù.ItemsSource = Ristorante.Menu;
        lstTavoli.ItemsSource = Ristorante.ListaTavoli;
    }

    private void lstTavoli_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (lstTavoli.SelectedItem is CTavolo tavoloSelezionato)
        {
            txtInfoTavolo.Text = tavoloSelezionato.ToString();
            if (tavoloSelezionato.OrdineAssociato == null)
            {
                txtInfoOrdine.Text = "";
                txtTotale.Text = "Totale: 0 €";
            }
            else
            {
                txtInfoOrdine.Text =
                    tavoloSelezionato.OrdineAssociato.ToString();

                txtTotale.Text = $"Totale: {tavoloSelezionato.OrdineAssociato.CalcolaTotale():F2} €";
            }
        }
    }

    private void btnOccupaTavolo_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (lstTavoli.SelectedItem is CTavolo tavoloSelezionato)
        {
            try
            {
                int numeroClienti = (int)NudNumClienti.Value;
                if (numeroClienti > tavoloSelezionato.PostiDisponibili)
                {
                    throw new Exception("Il numero di clienti supera i posti disponibili del tavolo.");
                }
                tavoloSelezionato.NumeroClienti = numeroClienti;
                COrdine NewOrder = new COrdine();
                NewOrder.NumeroTavoloAssociato = tavoloSelezionato.Id;
                tavoloSelezionato.AssegnaOrdine(NewOrder);
                Ristorante.SalvaDatiTavoli();
                txtInfoTavolo.Text = tavoloSelezionato.ToString();
                lstTavoli.ItemsSource = null;
                lstTavoli.ItemsSource = Ristorante.ListaTavoli;
                txtErrorTavolo.Text = "";
            }
            catch (Exception ex)
            {
                txtErrorTavolo.Text = $"Errore: {ex.Message}";
            }
        }
    }

    private void btnChiudiConto_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        try
        {
            if (lstTavoli.SelectedItem is CTavolo tavoloSelezionato && tavoloSelezionato.OrdineAssociato != null)
            {
                Ristorante.AggiungiOrdineAStorico(tavoloSelezionato.OrdineAssociato);
                Ristorante.SalvaDatiTavoli();
                tavoloSelezionato.LiberaTavolo();
                lstTavoli.ItemsSource = null;
                lstTavoli.ItemsSource = Ristorante.ListaTavoli;
                lstStorico.ItemsSource = null;
                lstStorico.ItemsSource = Ristorante.Storico;
                txtTotale.Text = "Totale: 0 €";
                txtInfoTavolo.Text = "";
                txtInfoOrdine.Text = "";
                txtErrorTavolo.Text = "";
            }
            else
            {
                throw new Exception("Seleziona un tavolo con un ordine attivo.");
            }
        }
        catch (Exception ex)
        {
            txtErrorTavolo.Text = $"Errore: {ex.Message}";
        }
    }

    private void btnAggiungiPiatto_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (lstTavoli.SelectedItem is CTavolo tavoloSelezionato && lstMenù.SelectedItem is CPiatto piattoSelezionato)
        {
            try
            {
                int quantità = (int)NudQuantita.Value;

                Ristorante.RichiamoAggiungiPiattoATavolo(tavoloSelezionato, piattoSelezionato, quantità);
                Ristorante.SalvaDatiTavoli();
                txtInfoOrdine.Text = tavoloSelezionato.OrdineAssociato.ToString();
                txtTotale.Text = $"Totale: {tavoloSelezionato.OrdineAssociato.CalcolaTotale():F2} €";
                txtErrorPiatto.Text = "";
            }
            catch (Exception ex)
            {
                txtErrorPiatto.Text = $"Errore: {ex.Message}";
            }
        }
        else
        {
            txtErrorPiatto.Text = "Seleziona un tavolo e un piatto dal menù.";
        }
    }
}