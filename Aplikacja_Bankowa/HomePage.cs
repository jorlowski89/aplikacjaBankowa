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
    public partial class HomePage : Form
    {
        private readonly DatabaseConnection dbConnection;
        public HomePage(DatabaseConnection dbConnection)
        {
            InitializeComponent();

            this.Text = "Strona Domowa";

            // Przypisanie przekazanego połączenia do pola klasy
            this.dbConnection = dbConnection;
        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }

        private void bankomat_Click(object sender, EventArgs e)
        {

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
