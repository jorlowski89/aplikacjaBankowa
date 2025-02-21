﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Aplikacja_Bankowa.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Aplikacja_Bankowa
{
    public class Bankomat 
    {
        private decimal balance;
        private Accounts account;
        private readonly DatabaseConnection dbConnection;
        private UserManager user;
        private int userId;
        private string userName;

        public Bankomat(DatabaseConnection dbConnection)
        {
            this.dbConnection = dbConnection;
            account = new Accounts(this.dbConnection);
            user = new UserManager(this.dbConnection);
            userId = user.GetUserIDByName(user.GetLastLoggedInUser());
            userName = user.GetLastLoggedInUser();
        }
 
        public decimal GetBalance()
        {

            this.balance = account.GetAccountBalance(this.userId);
            return balance;
        }

        public void Deposit(decimal amount)
        {
            this.balance = account.GetAccountBalance(this.userId);
            if (amount > 0)
            {

                string query = "UPDATE Accounts SET AccountBalance = @Amount" +
                    " WHERE UserID = (SELECT UserID FROM Users WHERE Username = @userName)" +
                    "INSERT INTO Transfers(Amount, TransferTitle, RecipientAccountID, TransferTypeID)" +
                    " VALUES( " +
                    "@AmountValue," +
                        "'Bankomat wpłata'," +
                        "(SELECT AccountID FROM Users JOIN Accounts ON Users.UserID = Accounts.UserID WHERE Users.Username = @userName)," +
                        "(SELECT TransferTypeID FROM TransferTypes WHERE TransferType = 'Wpłata_gotówki')" +
                    " )";

                using (var connection = dbConnection.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Amount", this.balance + amount);
                        command.Parameters.AddWithValue("@AmountValue", amount);
                        command.Parameters.AddWithValue("@userName", this.userName);
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

                this.balance = account.GetAccountBalance(this.userId);

                Console.WriteLine($"Deposited: {amount:C}. New balance: {balance:C}");
            }
            else
            {
                Console.WriteLine("Deposit amount must be positive.");
            }
        }

        public void Withdraw(decimal amount)
        {
            this.balance = account.GetAccountBalance(this.userId);
            if (amount > 0 && amount <= balance)
            {
            string query = "UPDATE Accounts SET AccountBalance = @Amount" +
                " WHERE UserID = (SELECT UserID FROM Users WHERE Username = @userName)" +
                "INSERT INTO Transfers(Amount, TransferTitle, RecipientAccountID, TransferTypeID)" +
                " VALUES( " +
                "@AmountValue * -1," +
                    "'Wypłata wpłata'," +
                    "(SELECT AccountID FROM Users JOIN Accounts ON Users.UserID = Accounts.UserID WHERE Users.Username = @userName)," +
                    "(SELECT TransferTypeID FROM TransferTypes WHERE TransferType = 'Wypłata_gotówki')" +
                " )";

                using (var connection = dbConnection.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Amount", this.balance - amount);
                        command.Parameters.AddWithValue("@AmountValue", amount);
                        command.Parameters.AddWithValue("@userName", this.userName);
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

                this.balance = account.GetAccountBalance(this.userId);

                Console.WriteLine($"Withdrawn: {amount:C}. New balance: {balance:C}");
            }
            else
            {
                Console.WriteLine("Insufficient funds or invalid amount.");
            }
        }
    }
}
