using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace esBattagliaNavale
{
    internal partial class UCPosizionamento : UserControl
    {
        private CCampo campoGiocatore;
        private Button[,] btnCampo = new Button[10, 10];
        private int indice = 0;

        public UCPosizionamento(CCampo campo)
        {
            campoGiocatore = campo;

            InitializeComponent();

            InizializzaCampo();

            lstNavi.ItemsSource = campoGiocatore.navi;

            txtIstruzioni.Text = $"Posiziona nave da {campoGiocatore.navi[0].Dimensione} celle";
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
            int riga = 0, colonna = 0;

            Button btn = (Button)sender;

            if (indice >= campoGiocatore.navi.Count)
            {
                txtIstruzioni.Text = "Tutte le navi posizionate";
                return;
            }

            CNave naveAttuale = campoGiocatore.navi[indice];


            if (btn.Tag is CCasella casella)
            {
                riga = casella.Riga;
                colonna = casella.Colonna;
            }

            if (rbOrizzontale.IsChecked == true)
            {
                if (colonna + naveAttuale.Dimensione > 10)
                {
                    txtIstruzioni.Text = "Posizione non valida";
                    return;
                }

                for (int i = 0; i < naveAttuale.Dimensione; i++)
                {
                    if (campoGiocatore.caselle[riga, colonna + i].IsNave)
                    {
                        txtIstruzioni.Text = "Navi sovrapposte";
                        return;
                    }
                }

                for (int i = 0; i < naveAttuale.Dimensione; i++)
                {
                    CCasella casellaNave = campoGiocatore.caselle[riga, colonna + i];
                    casellaNave.PosizionaNave();
                    btnCampo[riga, colonna + i].Content = "◆";
                    naveAttuale.caselleNave.Add(casellaNave);
                }

            }
            else
            {
                if (riga + naveAttuale.Dimensione > 10)
                {
                    txtIstruzioni.Text = "Posizione non valida";
                    return;
                }

                for (int i = 0; i < naveAttuale.Dimensione; i++)
                {
                    if (campoGiocatore.caselle[riga + i, colonna].IsNave)
                    {
                        txtIstruzioni.Text = "Navi sovrapposte";
                        return;
                    }
                }

                for (int i = 0; i < naveAttuale.Dimensione; i++)
                {
                    CCasella casellaNave = campoGiocatore.caselle[riga + i, colonna];
                    casellaNave.PosizionaNave();
                    btnCampo[riga + i, colonna].Content = "◆";
                    naveAttuale.caselleNave.Add(casellaNave);
                }

            }
            
            indice++;

            if (indice < campoGiocatore.navi.Count)
            {
                txtIstruzioni.Text = $"Posiziona nave da {campoGiocatore.navi[indice].Dimensione} celle";
            }
            else
            {
                txtIstruzioni.Text = "Tutte le navi posizionate";
            }

            lstNavi.ItemsSource = null;
            lstNavi.ItemsSource = campoGiocatore.navi;
        }
    }
}