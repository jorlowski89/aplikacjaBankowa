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
    public partial class Przelewy : Form
    {
        private readonly DatabaseConnection dbConnection;
        public Przelewy(DatabaseConnection dbConnection)
        {
            InitializeComponent();
            this.Text = "Przelewy";

            // Przypisanie przekazanego połączenia do pola klasy
            this.dbConnection = dbConnection;
        }
    }
}
