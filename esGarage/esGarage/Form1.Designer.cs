namespace esGarage
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitolo = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.rdbAuto = new System.Windows.Forms.RadioButton();
            this.rdbFurgone = new System.Windows.Forms.RadioButton();
            this.rdbMoto = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAnno = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCilindrata = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCreazione = new System.Windows.Forms.Button();
            this.lstVisualizza = new System.Windows.Forms.ListBox();
            this.pnlAuto = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbAlimentazione = new System.Windows.Forms.ComboBox();
            this.txtPosti = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlMoto = new System.Windows.Forms.Panel();
            this.txtTempi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlFurgone = new System.Windows.Forms.Panel();
            this.txtCapacità = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnEstrai = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.pnlAuto.SuspendLayout();
            this.pnlMoto.SuspendLayout();
            this.pnlFurgone.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitolo
            // 
            this.lblTitolo.AutoSize = true;
            this.lblTitolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitolo.Location = new System.Drawing.Point(375, 9);
            this.lblTitolo.Name = "lblTitolo";
            this.lblTitolo.Size = new System.Drawing.Size(132, 38);
            this.lblTitolo.TabIndex = 0;
            this.lblTitolo.Text = "Garage";
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(184, 360);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(153, 22);
            this.txtMarca.TabIndex = 1;
            this.txtMarca.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMarca_KeyPress);
            // 
            // rdbAuto
            // 
            this.rdbAuto.AutoSize = true;
            this.rdbAuto.Location = new System.Drawing.Point(323, 442);
            this.rdbAuto.Name = "rdbAuto";
            this.rdbAuto.Size = new System.Drawing.Size(55, 20);
            this.rdbAuto.TabIndex = 3;
            this.rdbAuto.TabStop = true;
            this.rdbAuto.Text = "Auto";
            this.rdbAuto.UseVisualStyleBackColor = true;
            this.rdbAuto.CheckedChanged += new System.EventHandler(this.rdbAuto_CheckedChanged);
            // 
            // rdbFurgone
            // 
            this.rdbFurgone.AutoSize = true;
            this.rdbFurgone.Location = new System.Drawing.Point(541, 442);
            this.rdbFurgone.Name = "rdbFurgone";
            this.rdbFurgone.Size = new System.Drawing.Size(78, 20);
            this.rdbFurgone.TabIndex = 4;
            this.rdbFurgone.TabStop = true;
            this.rdbFurgone.Text = "Furgone";
            this.rdbFurgone.UseVisualStyleBackColor = true;
            this.rdbFurgone.CheckedChanged += new System.EventHandler(this.rdbFurgone_CheckedChanged);
            // 
            // rdbMoto
            // 
            this.rdbMoto.AutoSize = true;
            this.rdbMoto.Location = new System.Drawing.Point(432, 442);
            this.rdbMoto.Name = "rdbMoto";
            this.rdbMoto.Size = new System.Drawing.Size(58, 20);
            this.rdbMoto.TabIndex = 5;
            this.rdbMoto.TabStop = true;
            this.rdbMoto.Text = "Moto";
            this.rdbMoto.UseVisualStyleBackColor = true;
            this.rdbMoto.CheckedChanged += new System.EventHandler(this.rdbMoto_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(181, 337);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Inserisci marca: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(382, 341);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Inserisci anno di produzione: ";
            // 
            // txtAnno
            // 
            this.txtAnno.Location = new System.Drawing.Point(385, 360);
            this.txtAnno.Name = "txtAnno";
            this.txtAnno.Size = new System.Drawing.Size(153, 22);
            this.txtAnno.TabIndex = 7;
            this.txtAnno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAnno_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(601, 341);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Inserisci cilincrata: ";
            // 
            // txtCilindrata
            // 
            this.txtCilindrata.Location = new System.Drawing.Point(604, 360);
            this.txtCilindrata.Name = "txtCilindrata";
            this.txtCilindrata.Size = new System.Drawing.Size(153, 22);
            this.txtCilindrata.TabIndex = 9;
            this.txtCilindrata.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCilindrata_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(320, 404);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Inserisci tipo veicolo da creare: ";
            // 
            // btnCreazione
            // 
            this.btnCreazione.Location = new System.Drawing.Point(491, 483);
            this.btnCreazione.Name = "btnCreazione";
            this.btnCreazione.Size = new System.Drawing.Size(210, 37);
            this.btnCreazione.TabIndex = 12;
            this.btnCreazione.Text = "Crea veicolo";
            this.btnCreazione.UseVisualStyleBackColor = true;
            this.btnCreazione.Click += new System.EventHandler(this.btnCreazione_Click);
            // 
            // lstVisualizza
            // 
            this.lstVisualizza.FormattingEnabled = true;
            this.lstVisualizza.ItemHeight = 16;
            this.lstVisualizza.Location = new System.Drawing.Point(12, 63);
            this.lstVisualizza.Name = "lstVisualizza";
            this.lstVisualizza.ScrollAlwaysVisible = true;
            this.lstVisualizza.Size = new System.Drawing.Size(904, 260);
            this.lstVisualizza.TabIndex = 13;
            // 
            // pnlAuto
            // 
            this.pnlAuto.Controls.Add(this.label8);
            this.pnlAuto.Controls.Add(this.cmbAlimentazione);
            this.pnlAuto.Controls.Add(this.txtPosti);
            this.pnlAuto.Controls.Add(this.label5);
            this.pnlAuto.Location = new System.Drawing.Point(27, 483);
            this.pnlAuto.Name = "pnlAuto";
            this.pnlAuto.Size = new System.Drawing.Size(210, 189);
            this.pnlAuto.TabIndex = 14;
            this.pnlAuto.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(142, 16);
            this.label8.TabIndex = 18;
            this.label8.Text = "Inserisci numero posti: ";
            // 
            // cmbAlimentazione
            // 
            this.cmbAlimentazione.FormattingEnabled = true;
            this.cmbAlimentazione.Location = new System.Drawing.Point(6, 130);
            this.cmbAlimentazione.Name = "cmbAlimentazione";
            this.cmbAlimentazione.Size = new System.Drawing.Size(153, 24);
            this.cmbAlimentazione.TabIndex = 12;
            // 
            // txtPosti
            // 
            this.txtPosti.Location = new System.Drawing.Point(6, 43);
            this.txtPosti.Name = "txtPosti";
            this.txtPosti.Size = new System.Drawing.Size(153, 22);
            this.txtPosti.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(202, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Inserisci tipo alimentazione auto: ";
            // 
            // pnlMoto
            // 
            this.pnlMoto.Controls.Add(this.txtTempi);
            this.pnlMoto.Controls.Add(this.label6);
            this.pnlMoto.Location = new System.Drawing.Point(237, 483);
            this.pnlMoto.Name = "pnlMoto";
            this.pnlMoto.Size = new System.Drawing.Size(210, 92);
            this.pnlMoto.TabIndex = 15;
            this.pnlMoto.Visible = false;
            // 
            // txtTempi
            // 
            this.txtTempi.Location = new System.Drawing.Point(6, 43);
            this.txtTempi.Name = "txtTempi";
            this.txtTempi.Size = new System.Drawing.Size(153, 22);
            this.txtTempi.TabIndex = 17;
            this.txtTempi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTempi_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Inserisci i tempi della moto: ";
            // 
            // pnlFurgone
            // 
            this.pnlFurgone.Controls.Add(this.txtCapacità);
            this.pnlFurgone.Controls.Add(this.label7);
            this.pnlFurgone.Location = new System.Drawing.Point(237, 581);
            this.pnlFurgone.Name = "pnlFurgone";
            this.pnlFurgone.Size = new System.Drawing.Size(210, 91);
            this.pnlFurgone.TabIndex = 16;
            this.pnlFurgone.Visible = false;
            // 
            // txtCapacità
            // 
            this.txtCapacità.Location = new System.Drawing.Point(6, 43);
            this.txtCapacità.Name = "txtCapacità";
            this.txtCapacità.Size = new System.Drawing.Size(153, 22);
            this.txtCapacità.TabIndex = 17;
            this.txtCapacità.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCapacità_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(165, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "Inserisci capacità furgone: ";
            // 
            // btnEstrai
            // 
            this.btnEstrai.Location = new System.Drawing.Point(491, 641);
            this.btnEstrai.Name = "btnEstrai";
            this.btnEstrai.Size = new System.Drawing.Size(210, 37);
            this.btnEstrai.TabIndex = 17;
            this.btnEstrai.Text = "Estrai veicolo";
            this.btnEstrai.UseVisualStyleBackColor = true;
            this.btnEstrai.Click += new System.EventHandler(this.btnEstrai_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(488, 558);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(143, 16);
            this.label9.TabIndex = 19;
            this.label9.Text = "Inserisci ID da estrarre:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(491, 581);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(153, 22);
            this.txtID.TabIndex = 18;
            this.txtID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtID_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 777);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.pnlFurgone);
            this.Controls.Add(this.btnEstrai);
            this.Controls.Add(this.pnlMoto);
            this.Controls.Add(this.pnlAuto);
            this.Controls.Add(this.lstVisualizza);
            this.Controls.Add(this.btnCreazione);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCilindrata);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAnno);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdbMoto);
            this.Controls.Add(this.rdbFurgone);
            this.Controls.Add(this.rdbAuto);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.lblTitolo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.pnlAuto.ResumeLayout(false);
            this.pnlAuto.PerformLayout();
            this.pnlMoto.ResumeLayout(false);
            this.pnlMoto.PerformLayout();
            this.pnlFurgone.ResumeLayout(false);
            this.pnlFurgone.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitolo;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.RadioButton rdbAuto;
        private System.Windows.Forms.RadioButton rdbFurgone;
        private System.Windows.Forms.RadioButton rdbMoto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAnno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCilindrata;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCreazione;
        private System.Windows.Forms.ListBox lstVisualizza;
        private System.Windows.Forms.Panel pnlAuto;
        private System.Windows.Forms.Panel pnlMoto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbAlimentazione;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlFurgone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTempi;
        private System.Windows.Forms.TextBox txtCapacità;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPosti;
        private System.Windows.Forms.Button btnEstrai;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtID;
    }
}

