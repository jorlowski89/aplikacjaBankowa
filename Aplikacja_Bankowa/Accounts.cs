using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplikacja_Bankowa.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Aplikacja_Bankowa
{
    public class Accounts
    {

        private readonly DatabaseConnection dbConnection;

        public Accounts(DatabaseConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public decimal GetAccountBalance(string accountId)
        {
            decimal balance = 0;

            string query = "SELECT AccountBalance FROM Accounts WHERE AccountID = @AccountID";

            using (var connection = dbConnection.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AccountID", accountId);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            balance = Convert.ToDecimal(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Wystąpił błąd: {ex.Message}");
                        throw; // Możesz wywołać wyjątek lub zalogować błąd
                    }
                }
            }

            return balance;
        }
    }
}
