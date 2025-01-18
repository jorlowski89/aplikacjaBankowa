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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
                    connection.Open();
                    var query = $"SELECT COUNT(1) FROM Users WHERE Username = '{username}' AND PasswordHash = HASHBYTES('SHA2_256', '{password}')";
                    // Bezpieczne zapytanie z użyciem parametrów SQL
                    //var query = $"SELECT COUNT(1) FROM Users WHERE Username = @Username AND PasswordHash = HASHBYTES('SHA2_256', @Password)";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        // Wykonanie zapytania i sprawdzenie wyniku
                        int result = (int)command.ExecuteScalar();

                        if (result > 0)
                        {
                            // Zalogowano użytkownika, zapisz do tabeli LoggedInUsers
                            LogUsername(username);
                            return true;
                        }
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd podczas logowania: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private void LogUsername(string username)
        {
            using (var connection = dbConnection.GetConnection())
            {
                try
                {
                    connection.Open();

                    // Sprawdzenie, czy użytkownik już istnieje w tabeli LoggedInUsers
                    string queryCheck = "SELECT COUNT(1) FROM LoggedInUsers WHERE Username = @Username";
                    using (var commandCheck = new SqlCommand(queryCheck, connection))
                    {
                        commandCheck.Parameters.AddWithValue("@Username", username);
                        int exists = (int)commandCheck.ExecuteScalar();

                        if (exists > 0)
                        {
                            // Aktualizacja rekordu istniejącego użytkownika
                            string queryUpdate = @"UPDATE LoggedInUsers
                                                  SET IsLoggedIn = 1, LoggedAt = @LoggedAt
                                                  WHERE Username = @Username";
                            using (var commandUpdate = new SqlCommand(queryUpdate, connection))
                            {
                                commandUpdate.Parameters.AddWithValue("@Username", username);
                                commandUpdate.Parameters.AddWithValue("@LoggedAt", DateTime.UtcNow);
                                commandUpdate.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            // Wstawienie nowego rekordu użytkownika
                            string queryInsert = @"INSERT INTO LoggedInUsers (Username, IsLoggedIn, LoggedAt)
                                                  VALUES (@Username, 1, @LoggedAt)";
                            using (var commandInsert = new SqlCommand(queryInsert, connection))
                            {
                                commandInsert.Parameters.AddWithValue("@Username", username);
                                commandInsert.Parameters.AddWithValue("@LoggedAt", DateTime.UtcNow);
                                commandInsert.ExecuteNonQuery();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Obsługa błędu przy zapisie do bazy
                    MessageBox.Show($"Błąd podczas logowania użytkownika w bazie danych: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    public class UserManager
    {
        private readonly DatabaseConnection dbConnection;
        private string userName;
        private int userID;

        public UserManager(DatabaseConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public void SetUsername(string username)
        {
            userName = username;
        }

        public string GetLastLoggedInUser()
        {
            using (var connection = this.dbConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT TOP 1 Username FROM LoggedInUsers ORDER BY LoggedAt DESC";
                    using (var command = new SqlCommand(query, connection))
                    {
                        var result = command.ExecuteScalar();
                        return result != null ? result.ToString() : "Brak ostatnio zalogowanego użytkownika.";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Błąd podczas pobierania ostatniego zalogowanego użytkownika: {ex.Message}");
                    return "Błąd podczas pobierania użytkownika.";
                }
            }
        }

        public int GetUserIDByName(string username)
        {
            using (var connection = this.dbConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT TOP 1 UserID FROM Users where Username = @Username";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        var result = command.ExecuteScalar();
                        return result != null && int.TryParse(result.ToString(), out int userID) ? userID : 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Błąd podczas pobierania ostatniego zalogowanego użytkownika: {ex.Message}");
                    return 0;
                }
            }
        }
    }
}
