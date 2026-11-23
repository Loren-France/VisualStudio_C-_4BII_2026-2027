using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Documents;
using Avalonia.Interactivity;

namespace esBattagliaNavale
{
    internal partial class UCGioco : UserControl
    {
        private CCampo campoGiocatore;
        private Button[,] btnCampo = new Button[10, 10];
        private int mosse = 0;
        private bool partitaFinita = false;

        public delegate void DColpo(CCasella casella);
        public event DColpo? Colpito;
        public event DColpo? Acqua;

        public UCGioco(CCampo campo)
        {
            campoGiocatore = campo;

            InitializeComponent();

            InizializzaCampo();

            Colpito += GestisciColpito;
            Acqua += GestisciAcqua;

            txtMosse.Text = $"Mosse: {mosse}";

            txtNavi.Text = $"Navi rimaste: {NaviRimanenti()}";
        }

        private void InizializzaCampo()
        {
            for (int r = 0; r < 10; r++)
            {
                for (int c = 0; c < 10; c++)
                {
                    Button btn = new Button();

                    btn.Name = $"btn{r}_{c}";
                    btn.Content = "⁓";
                    btn.FontWeight = Avalonia.Media.FontWeight.Bold;
                    btn.HorizontalContentAlignment = Avalonia.Layout.HorizontalAlignment.Center;
                    btn.Tag = campoGiocatore.caselle[r, c];

                    btn.Width = 30;
                    btn.Height = 30;
                    btn.Margin = new Thickness(1);


                    btn.Click += Btn_Click;

                    btnCampo[r, c] = btn;
                    ugCampo.Children.Add(btn);
                }
            }
        }

        private void Btn_Click(object? sender, RoutedEventArgs e)
        {
            if (partitaFinita)
            {
                return;
            }

            Button btn = (Button)sender;

            if (btn.Tag is CCasella casella)
            {
                if (casella.IsColpita)
                {
                    return;
                }

                casella.Colpisci();

                if (casella.IsNave)
                {
                    btn.Content = "●";

                    Colpito?.Invoke(casella);
                }
                else
                {
                    btn.Content = "○";

                    Acqua?.Invoke(casella);
                }

                mosse++;

                txtMosse.Text = $"Mosse: {mosse}";
            }

            txtNavi.Text = $"Navi rimaste: {NaviRimanenti()}";

            if (NaviRimanenti() == 0)
            {
                txtIstruzioni.Text = "HAI VINTO!";
                partitaFinita = true;
            }
        }

        public int NaviRimanenti()
        {
            int cont = 0;

            foreach (CNave nave in campoGiocatore.navi)
            {
                if (!nave.Affondata())
                {
                    cont++;
                }
            }

            return cont;
        }

        private void GestisciColpito(CCasella casella)
        {
            lstLog.Items.Add($"Colpito in ({casella.Riga + 1},{casella.Colonna + 1})");
        }

        private void GestisciAcqua(CCasella casella)
        {
            lstLog.Items.Add("Acqua !!");
        }
    }
}