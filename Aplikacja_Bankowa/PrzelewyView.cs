using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplikacja_Bankowa.Services;

namespace Aplikacja_Bankowa
{
    public partial class PrzelewyView : Form
    {
        private readonly DatabaseConnection dbConnection;
        private Przelewy Przelew;
        public PrzelewyView(DatabaseConnection dbConnection)
        {
            InitializeComponent();
            this.Text = "Przelewy";

            // Przypisanie przekazanego połączenia do pola klasy
            this.dbConnection = dbConnection;
        }

        private void InitializeComponent()
        {
            this.stanKontaLabel = new System.Windows.Forms.Label();
            this.stanKontaValue = new System.Windows.Forms.Label();
            this.kwotaPrzelewuValue = new System.Windows.Forms.TextBox();
            this.kwotaPrzelewuLabel = new System.Windows.Forms.Label();
            this.daneObiorcyLabel = new System.Windows.Forms.Label();
            this.daneObiorcyValue = new System.Windows.Forms.TextBox();
            this.numerKontaValue = new System.Windows.Forms.TextBox();
            this.numerKontaLabel = new System.Windows.Forms.Label();
            this.tytulPrzelewuLabel = new System.Windows.Forms.Label();
            this.tytulPrzelewuValue = new System.Windows.Forms.TextBox();
            this.wykonajPrzelew = new System.Windows.Forms.Button();
            this.anulujPrzelew = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // stanKontaLabel
            // 
            this.stanKontaLabel.AutoSize = true;
            this.stanKontaLabel.Location = new System.Drawing.Point(38, 52);
            this.stanKontaLabel.Name = "stanKontaLabel";
            this.stanKontaLabel.Size = new System.Drawing.Size(62, 13);
            this.stanKontaLabel.TabIndex = 0;
            this.stanKontaLabel.Text = "Stan konta:";
            // 
            // stanKontaValue
            // 
            this.stanKontaValue.AutoSize = true;
            this.stanKontaValue.Location = new System.Drawing.Point(106, 52);
            this.stanKontaValue.Name = "stanKontaValue";
            this.stanKontaValue.Size = new System.Drawing.Size(28, 13);
            this.stanKontaValue.TabIndex = 1;
            this.stanKontaValue.Text = "0,00";
            // 
            // kwotaPrzelewuValue
            // 
            this.kwotaPrzelewuValue.Location = new System.Drawing.Point(41, 292);
            this.kwotaPrzelewuValue.Name = "kwotaPrzelewuValue";
            this.kwotaPrzelewuValue.Size = new System.Drawing.Size(128, 20);
            this.kwotaPrzelewuValue.TabIndex = 2;
            // 
            // kwotaPrzelewuLabel
            // 
            this.kwotaPrzelewuLabel.AutoSize = true;
            this.kwotaPrzelewuLabel.Location = new System.Drawing.Point(46, 279);
            this.kwotaPrzelewuLabel.Name = "kwotaPrzelewuLabel";
            this.kwotaPrzelewuLabel.Size = new System.Drawing.Size(85, 13);
            this.kwotaPrzelewuLabel.TabIndex = 3;
            this.kwotaPrzelewuLabel.Text = "Kwota przelewu:";
            // 
            // daneObiorcyLabel
            // 
            this.daneObiorcyLabel.AutoSize = true;
            this.daneObiorcyLabel.Location = new System.Drawing.Point(46, 90);
            this.daneObiorcyLabel.Name = "daneObiorcyLabel";
            this.daneObiorcyLabel.Size = new System.Drawing.Size(73, 13);
            this.daneObiorcyLabel.TabIndex = 4;
            this.daneObiorcyLabel.Text = "Dane obiorcy:";
            this.daneObiorcyLabel.Click += new System.EventHandler(this.obriorcaLabel_Click);
            // 
            // daneObiorcyValue
            // 
            this.daneObiorcyValue.Location = new System.Drawing.Point(41, 106);
            this.daneObiorcyValue.Name = "daneObiorcyValue";
            this.daneObiorcyValue.Size = new System.Drawing.Size(443, 20);
            this.daneObiorcyValue.TabIndex = 5;
            // 
            // numerKontaValue
            // 
            this.numerKontaValue.Location = new System.Drawing.Point(41, 172);
            this.numerKontaValue.Name = "numerKontaValue";
            this.numerKontaValue.Size = new System.Drawing.Size(443, 20);
            this.numerKontaValue.TabIndex = 7;
            // 
            // numerKontaLabel
            // 
            this.numerKontaLabel.AutoSize = true;
            this.numerKontaLabel.Location = new System.Drawing.Point(46, 156);
            this.numerKontaLabel.Name = "numerKontaLabel";
            this.numerKontaLabel.Size = new System.Drawing.Size(71, 13);
            this.numerKontaLabel.TabIndex = 6;
            this.numerKontaLabel.Text = "Numer konta:";
            // 
            // tytulPrzelewuLabel
            // 
            this.tytulPrzelewuLabel.AutoSize = true;
            this.tytulPrzelewuLabel.Location = new System.Drawing.Point(46, 217);
            this.tytulPrzelewuLabel.Name = "tytulPrzelewuLabel";
            this.tytulPrzelewuLabel.Size = new System.Drawing.Size(80, 13);
            this.tytulPrzelewuLabel.TabIndex = 9;
            this.tytulPrzelewuLabel.Text = "Tytuł przelewu:";
            // 
            // tytulPrzelewuValue
            // 
            this.tytulPrzelewuValue.Location = new System.Drawing.Point(41, 230);
            this.tytulPrzelewuValue.Name = "tytulPrzelewuValue";
            this.tytulPrzelewuValue.Size = new System.Drawing.Size(443, 20);
            this.tytulPrzelewuValue.TabIndex = 8;
            // 
            // wykonajPrzelew
            // 
            this.wykonajPrzelew.Location = new System.Drawing.Point(41, 369);
            this.wykonajPrzelew.Name = "wykonajPrzelew";
            this.wykonajPrzelew.Size = new System.Drawing.Size(137, 43);
            this.wykonajPrzelew.TabIndex = 10;
            this.wykonajPrzelew.Text = "Wykonaj przelew";
            this.wykonajPrzelew.UseVisualStyleBackColor = true;
            this.wykonajPrzelew.Click += new System.EventHandler(this.wykonajPrzelew_Click);
            // 
            // anulujPrzelew
            // 
            this.anulujPrzelew.Location = new System.Drawing.Point(347, 369);
            this.anulujPrzelew.Name = "anulujPrzelew";
            this.anulujPrzelew.Size = new System.Drawing.Size(137, 43);
            this.anulujPrzelew.TabIndex = 11;
            this.anulujPrzelew.Text = "Anuluj przelew";
            this.anulujPrzelew.UseVisualStyleBackColor = true;
            this.anulujPrzelew.Click += new System.EventHandler(this.anulujPrzelew_Click);
            // 
            // Przelewy
            // 
            this.ClientSize = new System.Drawing.Size(535, 446);
            this.Controls.Add(this.anulujPrzelew);
            this.Controls.Add(this.wykonajPrzelew);
            this.Controls.Add(this.tytulPrzelewuLabel);
            this.Controls.Add(this.tytulPrzelewuValue);
            this.Controls.Add(this.numerKontaValue);
            this.Controls.Add(this.numerKontaLabel);
            this.Controls.Add(this.daneObiorcyValue);
            this.Controls.Add(this.daneObiorcyLabel);
            this.Controls.Add(this.kwotaPrzelewuLabel);
            this.Controls.Add(this.kwotaPrzelewuValue);
            this.Controls.Add(this.stanKontaValue);
            this.Controls.Add(this.stanKontaLabel);
            this.Name = "Przelewy";
            this.Load += new System.EventHandler(this.Przelewy_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void obriorcaLabel_Click(object sender, EventArgs e)
        {

        }

        private void Przelewy_Load(object sender, EventArgs e)
        {

        }

        private void wykonajPrzelew_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage(dbConnection);

            if (string.IsNullOrWhiteSpace(kwotaPrzelewuValue.Text))
            {
                MessageBox.Show("Proszę uzupełnić pole 'Kwota przelewu'!",
                                "Błąd",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                kwotaPrzelewuValue.Focus();
                return;
            }


            if (string.IsNullOrWhiteSpace(tytulPrzelewuValue.Text))
            {
                MessageBox.Show("Proszę uzupełnić pole 'Tytul przelewu'!",
                                "Błąd",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                tytulPrzelewuValue.Focus();
                return;
            }


            if (string.IsNullOrWhiteSpace(numerKontaValue.Text))
            {
                MessageBox.Show("Proszę uzupełnić pole 'Numer konta'!",
                                "Błąd",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                numerKontaValue.Focus();
                return;
            }


            Przelew = new Przelewy(int.Parse(kwotaPrzelewuValue.Text), tytulPrzelewuValue.Text, 1, int.Parse(numerKontaValue.Text), 3, dbConnection);
            Przelew.WykonajPrzelew();

            MessageBox.Show("Wykonano przelew'!",
                              "Wykonano",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);

            homePage.Show();
            this.Hide();
        }

        private void anulujPrzelew_Click(object sender, EventArgs e)
        {

            HomePage homePage = new HomePage(dbConnection);
            homePage.Show();

            this.Hide();
        }
    }
}
