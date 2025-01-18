using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplikacja_Bankowa.Services;

namespace Aplikacja_Bankowa
{
    public partial class BankomatView : Form
    {
        private Bankomat bankomat; 
        private readonly DatabaseConnection dbConnection;
        public BankomatView(DatabaseConnection dbConnection)
        {
            InitializeComponent();
            this.dbConnection = dbConnection;
            this.Text = "Bankomat";
            bankomat = new Bankomat(dbConnection);
            UpdateBalanceLabel();
        }

        private void UpdateBalanceLabel()
        {
            saldoKontaValue.Text = $"{bankomat.GetBalance():C}";
        }

        private void wplataNaKonto_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(kwotaValue.Text, out decimal amount))
            {
                bankomat.Deposit(amount);
                UpdateBalanceLabel();
            }
            else
            {
                MessageBox.Show("Podaj prawidłową kwotę.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void wyplataZKonta_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(kwotaValue.Text, out decimal amount))
            {
                bankomat.Withdraw(amount);
                UpdateBalanceLabel();
            }
            else
            {
                MessageBox.Show("Podaj prawidłową kwotę.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage(dbConnection);
            homePage.Show();
            this.Hide();
        }

        private void BankomatView_Load(object sender, EventArgs e)
        {

        }

        private void kwotaValue_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
