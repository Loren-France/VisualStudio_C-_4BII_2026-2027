using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace esBattagliaNavale
{
    public partial class MainWindow : Window
    {
        static CCampo CampoGiocatore = new CCampo();
        public MainWindow()
        {
            InitializeComponent();

            Principale.Content = new UCPosizionamento(CampoGiocatore);
        }

        private void btnInizia_Click(object? sender, RoutedEventArgs e)
        {
            txtMode.Text = "Modalità di gioco";
            Principale.Content = new UCGioco(CampoGiocatore);
        }

        private void btnEsci_Click(object? sender, RoutedEventArgs e)
        {
            CampoGiocatore = new CCampo();
            txtMode.Text = "Modalità di posizionamento";
            Principale.Content = new UCPosizionamento(CampoGiocatore);
        }
    }
}