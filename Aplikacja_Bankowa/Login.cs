using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplikacja_Bankowa.Services;

namespace Aplikacja_Bankowa
{
    public partial class Login : Form
    {

        private readonly DatabaseConnection dbConnection;
        public Login(DatabaseConnection dbConnection)
        {
            InitializeComponent();
            this.Text = "Okno logowania";

            // Przypisanie przekazanego połączenia do pola klasy
            this.dbConnection = dbConnection;
        }


        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (ValidateUser(username, password))
            {
                // Jeśli poprawne dane logowania, otwórz HomePage
                HomePage homePage = new HomePage(dbConnection);
                homePage.Show();
                this.Hide(); // Ukryj okno logowania
            }
            else
            {
                MessageBox.Show("Niepoprawna nazwa użytkownika lub hasło.", "Błąd logowania", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCreateUser_Click(object sender, EventArgs e)
        {

        }

        private bool ValidateUser(string username, string password)
        {
            using (var connection = dbConnection.GetConnection())
            {
                try
                {
                    // Debugowanie wartości i długości parametrów
                    Console.WriteLine($"Username: '{username}', Length: {username?.Length ?? 0}");
                    Console.WriteLine($"Password: '{password}', Length: {password?.Length ?? 0}");

                    connection.Open();
                    // Zapytanie SQL do weryfikacji użytkownika
                    // UWAGA! nieodporne na sql injection!
                    // TODO: Przepisac
                    var query = $"SELECT COUNT(1) FROM Users WHERE Username = '{username}' AND PasswordHash = HASHBYTES('SHA2_256', '{password}')";
                    using (var command = new SqlCommand(query, connection))
                    {
                        // Wykonanie zapytania i sprawdzenie wyniku
                        int result = (int)command.ExecuteScalar();

                        return result > 0; // Jeśli wynik > 0, dane są poprawne
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd podczas logowania: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

    }
}
