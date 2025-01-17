using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplikacja_Bankowa.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Aplikacja_Bankowa
{
    public class Bankomat 
    {
        private decimal balance;
        private readonly DatabaseConnection dbConnection;

        public Bankomat(decimal initialBalance, DatabaseConnection dbConnection)
        {
            this.balance = initialBalance;
            this.dbConnection = dbConnection;
        }
 
        public decimal GetBalance()
        {
            return balance;
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {

                string query = "UPDATE Accounts SET AccountBalance = @Amount" +
                    " WHERE UserID = (SELECT UserID FROM Users WHERE Username = 'admin')" +
                    "INSERT INTO Transfers(Amount, TransferTitle, RecipientAccountID, TransferTypeID)" +
                    " VALUES( " +
                    "@Amount," +
                        "'Bankomat wpłata'," +
                        "(SELECT AccountID FROM Users JOIN Accounts ON Users.UserID = Accounts.UserID WHERE Users.Username = 'admin'),"+
                        "(SELECT TransferTypeID FROM TransferTypes WHERE TransferType = 'Wpłata_gotówki')" +
                    " )";

                using (var connection = dbConnection.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Amount", amount);

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


      
                Console.WriteLine($"Deposited: {amount:C}. New balance: {balance:C}");
            }
            else
            {
                Console.WriteLine("Deposit amount must be positive.");
            }
        }

        public void Withdraw(decimal amount)
        {
            //if (amount > 0 && amount <= balance)
            //{
                string query = "UPDATE Accounts SET AccountBalance = @Amount" +
                " WHERE UserID = (SELECT UserID FROM Users WHERE Username = 'admin')" +
                "INSERT INTO Transfers(Amount, TransferTitle, RecipientAccountID, TransferTypeID)" +
                " VALUES( " +
                "@Amount * -1," +
                    "'Wypłata wpłata'," +
                    "(SELECT AccountID FROM Users JOIN Accounts ON Users.UserID = Accounts.UserID WHERE Users.Username = 'admin')," +
                    "(SELECT TransferTypeID FROM TransferTypes WHERE TransferType = 'Wypłata_gotówki')" +
                " )";

                using (var connection = dbConnection.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Amount", amount);
                 
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


                Console.WriteLine($"Withdrawn: {amount:C}. New balance: {balance:C}");
           // }
           // else
          //  {
           //     Console.WriteLine("Insufficient funds or invalid amount.");
           // }
        }
    }
}
