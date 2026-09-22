using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace esGarage
{
    public partial class Form1 : Form
    {
        static CGarage garage = new CGarage();
        int maxnum = 0;

        public Form1()
        {
            InitializeComponent();
            cmbAlimentazione.DataSource = Enum.GetValues(typeof(TipoAlimentazione));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if (!char.IsLetter(c) && !char.IsControl(c))
            {
                e.Handled = true;
            }
        }

        private void txtAnno_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if (!char.IsNumber(c) && !char.IsControl(c))
            {
                e.Handled = true;
            }
        }

        private void txtPosti_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsNumber(c) && !char.IsControl(c))
            {
                e.Handled = true;
            }
        }

        private void txtTempi_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsNumber(c) && !char.IsControl(c) && c != '1' && c != '0' && c != '3' && c != '5' && c != '6' && c != '7' && c != '8' && c != '9')
            {
                e.Handled = true;
            }
        }

        private void txtCapacità_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsNumber(c) && !char.IsControl(c))
            {
                e.Handled = true;
            }
        }

        private void txtCilindrata_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if (!char.IsNumber(c) && !char.IsControl(c))
            {
                e.Handled = true;
            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if (!char.IsNumber(c) && !char.IsControl(c))
            {
                e.Handled = true;
            }
        }

        private void btnCreazione_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMarca.Text) || string.IsNullOrWhiteSpace(txtAnno.Text) || string.IsNullOrWhiteSpace(txtCilindrata.Text) || !rdbAuto.Checked && !rdbFurgone.Checked && !rdbMoto.Checked)
            {
                return;
            }
            else
            {
                string marca = txtMarca.Text;
                int anno = int.Parse(txtAnno.Text);
                int cilindrata = int.Parse(txtCilindrata.Text);

                if (rdbAuto.Checked)
                {

                    int numeroPosti = int.Parse(txtPosti.Text);

                    TipoAlimentazione alimentazione = (TipoAlimentazione)cmbAlimentazione.SelectedItem;

                    CAuto auto = new CAuto(marca, anno, cilindrata, numeroPosti, alimentazione);
                    garage.AggiungiVeicolo(auto);
                    AggiornaListaVeicoli();
                    maxnum++;
                }
                else if (rdbFurgone.Checked)
                {

                    int capacità = int.Parse(txtCapacità.Text);

                    CFurgone furgone = new CFurgone(marca, anno, cilindrata, capacità);
                    garage.AggiungiVeicolo(furgone);
                    AggiornaListaVeicoli();
                    maxnum++;
                }
                else if (rdbMoto.Checked)
                {


                    int tempi = int.Parse(txtTempi.Text);

                    CMoto moto = new CMoto(marca, anno, cilindrata, tempi);
                    garage.AggiungiVeicolo(moto);
                    AggiornaListaVeicoli();
                    maxnum++;
                }

                MessageBox.Show("Veicolo aggiunto con successo!");
            }
        }

        public void AggiornaListaVeicoli()
        {
            lstVisualizza.Items.Clear();
            foreach (CVeicolo veicolo in garage.Veicoli)
            {
                if (veicolo != null)
                {
                    lstVisualizza.Items.Add(veicolo.InfoVeicolo());
                }
            }
        }

        private void btnEstrai_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);

            if (id <= 0 || id > maxnum)
            {
                MessageBox.Show("ID non valido.");
                return;
            }

            garage.EstraiVeicolo(id);

            MessageBox.Show("Veicolo estratto con successo!");
            AggiornaListaVeicoli();

        }

        private void rdbAuto_CheckedChanged(object sender, EventArgs e)
        {
            pnlAuto.Visible = true;
            pnlMoto.Visible = false;
            pnlFurgone.Visible = false;
            cmbAlimentazione.SelectedIndex = 0;
            txtPosti.Text = "";
        }

        private void rdbMoto_CheckedChanged(object sender, EventArgs e)
        {
            pnlAuto.Visible = false;
            pnlMoto.Visible = true;
            pnlFurgone.Visible = false;
            txtTempi.Text = "";
        }

        private void rdbFurgone_CheckedChanged(object sender, EventArgs e)
        {
            pnlAuto.Visible = false;
            pnlMoto.Visible = false;
            pnlFurgone.Visible = true;
            txtCapacità.Text = "";
        }
    }
}
