using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplikacja_Bankowa
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.Text = "Okno logowania";
        }


        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();

            homePage.Show();

            this.Hide();
        }

        private void buttonCreateUser_Click(object sender, EventArgs e)
        {

        }
    }
}
