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
        private int accNumber;
        private readonly DatabaseConnection dbConnection = new DatabaseConnection();
        private Accounts(int accNumber) 
        {
            this.accNumber = accNumber;
        }

        public int GetBalance()
        {
            using (var connection = dbConnection.GetConnection())
            try
            {
                connection.Open();
                var query = $"SELECT AccountBalance FROM Accounts WHERE AccountNumber = '{this.accNumber}'";
                using (var command = new SqlCommand(query, connection))
                {
                       return command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas logowania: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
    }
}
