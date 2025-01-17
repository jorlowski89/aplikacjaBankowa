using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplikacja_Bankowa.Services;

namespace Aplikacja_Bankowa
{
    public partial class HomePage : Form
    {
        private Bankomat bankomat;
        private readonly DatabaseConnection dbConnection;
        private Accounts account;

        public HomePage(DatabaseConnection dbConnection)
        {
            InitializeComponent();

            this.Text = "Strona Domowa";

            // Przypisanie przekazanego połączenia do pola klasy
            this.dbConnection = dbConnection;
            bankomat = new Bankomat(0);
            account = new Accounts(dbConnection);
            UpdateBalanceLabel();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }
        private void UpdateBalanceLabel()
        {
            saldoKonta.Text = $"{account.GetAccountBalance("6E3E8B29-593F-4466-8214-AD6474374013"):C}";
        }


        private void bankomat_Click(object sender, EventArgs e)
        {
            BankomatView bankomatView = new BankomatView(dbConnection);
            bankomatView.Show();
            this.Hide();
        }

        private void przelewy_Click(object sender, EventArgs e)
        {
            PrzelewyView przelewyPage = new PrzelewyView(dbConnection);
            przelewyPage.Show();
            this.Hide();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            Login login = new Login(dbConnection);
            login.Show();
            this.Hide();
        }
    }
}
