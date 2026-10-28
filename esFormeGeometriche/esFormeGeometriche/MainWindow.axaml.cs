using Avalonia.Controls;

namespace esFormeGeometriche;

public partial class MainWindow : Window
{
    CFigura? figura = null;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void CmbSelezione_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (CmbSelezione.SelectedIndex == 0)
        {
            figura = new CRettangolo("Rettangolo");

            PanelRettangolo.IsVisible = true;
            PanelQuadrato.IsVisible = false;
            PanelCerchio.IsVisible = false;
        }
        else if (CmbSelezione.SelectedIndex == 1)
        {
            figura = new CQuadrato("Quadrato");

            PanelRettangolo.IsVisible = false;
            PanelQuadrato.IsVisible = true;
            PanelCerchio.IsVisible = false;
        }
        else if (CmbSelezione.SelectedIndex == 2)
        {
            figura = new CCerchio("Cerchio");

            PanelRettangolo.IsVisible = false;
            PanelQuadrato.IsVisible = false;
            PanelCerchio.IsVisible = true;
        }
    }

    private void BtnCalcola_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (CmbSelezione.SelectedIndex == -1)
        {
            TbkRisultato.Text = "Errore: Selezionare una forma geometrica.";
            return;
        }

        if (figura != null)
        {
            if (figura is CQuadrato quadrato)
            {
                if (string.IsNullOrWhiteSpace(TxtLato.Text))
                {
                    TbkRisultato.Text = "Errore: Inserire un valore valido per il lato del quadrato.";
                    return;
                }
                quadrato.Base = double.Parse(TxtLato.Text);
            }
            else if (figura is CRettangolo rettangolo)
            {
                if (string.IsNullOrWhiteSpace(TxtBase.Text) || string.IsNullOrWhiteSpace(TxtAltezza.Text) || double.TryParse(TxtBase.Text, out _) == false || double.TryParse(TxtAltezza.Text, out _) == false)
                {
                    TbkRisultato.Text = "Errore: Inserire valori validi per base e altezza del rettangolo.";
                    return;
                }
                rettangolo.Base = double.Parse(TxtBase.Text);
                rettangolo.Altezza = double.Parse(TxtAltezza.Text);
            }
            else if (figura is CCerchio cerchio)
            {
                if (string.IsNullOrWhiteSpace(TxtRaggio.Text) || double.TryParse(TxtRaggio.Text, out _) == false)
                {
                    TbkRisultato.Text = "Errore: Inserire un valore valido per il raggio del cerchio.";
                    return;
                }
                cerchio.Raggio = double.Parse(TxtRaggio.Text);
            }

            TbkRisultato.Text = figura.Descrizione();
        }
    }
}