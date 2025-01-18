using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplikacja_Bankowa.Services;

namespace Aplikacja_Bankowa
{

    internal class Przelewy
    {
        private readonly DatabaseConnection dbConnection;
        private decimal Amount;
        private string TransferTitle;
        private int SenderAccountID;
        private int RecipientAccountID;
        private int TransferTypeID;

        public Przelewy(decimal amount, string transferTitle, int senderAccountID, int recipientAccountID, int transferTypeID, DatabaseConnection dbConnection)
        {
            this.dbConnection = dbConnection;
            this.Amount = amount;
            this.TransferTitle = transferTitle;
            this.SenderAccountID = senderAccountID;
            this.RecipientAccountID = recipientAccountID;
            this.TransferTypeID = transferTypeID;
        }

        public virtual void WykonajPrzelew()
        {


            Console.WriteLine($"Przelew na kwotę {Amount} zł został wysłany do {RecipientAccountID}.");
            Console.WriteLine($"Tytuł: {TransferTitle}, Od: {SenderAccountID}");
        }

    }


}
