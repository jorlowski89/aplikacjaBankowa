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
            bankomat = new Bankomat(dbConnection);
            account = new Accounts(dbConnection);
            UpdateBalanceLabel();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }
        private void UpdateBalanceLabel()
        {
            saldoKonta.Text = $"{account.GetAccountBalance("798501DA-12FC-4BC4-83B5-0BBAF298B244"):C}";
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
