using System;
using System.Data.SqlClient;

namespace Aplikacja_Bankowa.Services
{
    public class DatabaseConnection
    {
        private readonly string connectionString;

        public DatabaseConnection()
        {
            // Connection string z uwierzytelnianiem Windows
            connectionString = @"Server=serwerek\SQLEXPRESS;Database=BankApplication;Trusted_Connection=True;";
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public void TestConnection()
        {
            using (var connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Połączenie udane!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Błąd połączenia: {ex.Message}");
                }
            }
        }
    }
}
