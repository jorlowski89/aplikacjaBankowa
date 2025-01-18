using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplikacja_Bankowa.Services;

namespace Aplikacja_Bankowa
{

    internal class Przelewy
    {
        private readonly DatabaseConnection dbConnection;
        protected decimal Amount;
        protected string TransferTitle;
        protected int SenderAccountID;
        protected int RecipientAccountID;
        private int TransferTypeID;
        private Bankomat bankomat;
        private decimal balance;
        private UserManager user;


        public Przelewy(decimal amount, string transferTitle, int senderAccountID, int recipientAccountID, int transferTypeID, DatabaseConnection dbConnection)
        {
            this.dbConnection = dbConnection;
            this.Amount = amount;
            this.TransferTitle = transferTitle;
            this.SenderAccountID = senderAccountID;
            this.RecipientAccountID = recipientAccountID;
            this.TransferTypeID = transferTypeID;

            bankomat = new Bankomat(this.dbConnection);
            user = new UserManager(this.dbConnection);
        }

        public virtual void WykonajPrzelew()
        {
            balance = bankomat.GetBalance();
            string username = user.GetLastLoggedInUser();
            int usernameID = user.GetUserIDByName(username);

            if (balance >= Amount )
            {
                string query = "UPDATE Accounts SET AccountBalance = (SELECT AccountBalance where UserID = @UserID) - @Amount" +
                    " WHERE UserID = @UserID" +
                    " UPDATE Accounts SET AccountBalance = (SELECT AccountBalance where AccountNumber = @AccountNumber ) + @Amount" +
                    " WHERE AccountNumber = @AccountNumber";

                using (var connection = dbConnection.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Amount", Amount);
                        command.Parameters.AddWithValue("@UserID", usernameID);
                        command.Parameters.AddWithValue("@AccountNumber", RecipientAccountID);

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
            } else
            {


            }
                
           



            Console.WriteLine($"Przelew na kwotę {Amount} zł został wysłany do {RecipientAccountID}.");
            Console.WriteLine($"Tytuł: {TransferTitle}, Od: {SenderAccountID}");
        }
    }

    internal class PrzelewyZagraniczne : Przelewy
    {
        private string KrajOdbiorcy; // Dodatkowe pole dla przelewów zagranicznych
        private decimal KursWalutowy; // Kurs wymiany walut

        public PrzelewyZagraniczne(
            decimal amount,
            string transferTitle,
            int senderAccountID,
            int recipientAccountID,
            int transferTypeID,
            DatabaseConnection dbConnection,
            string krajOdbiorcy,
            decimal kursWalutowy)
            : base(amount, transferTitle, senderAccountID, recipientAccountID, transferTypeID, dbConnection)
        {
            this.KrajOdbiorcy = krajOdbiorcy;
            this.KursWalutowy = kursWalutowy;
        }

        public override void WykonajPrzelew()
        {
            // Przed wykonaniem przelewu przelicza kwotę na inną walutę
            decimal przeliczonaKwota = Amount * KursWalutowy;

            Console.WriteLine($"Przelew zagraniczny na kwotę {przeliczonaKwota:F2} w walucie docelowej został wysłany do {RecipientAccountID}.");
            Console.WriteLine($"Kraj odbiorcy: {KrajOdbiorcy}");
            Console.WriteLine($"Tytuł: {TransferTitle}, Od: {SenderAccountID}");
        }
    }


    }
