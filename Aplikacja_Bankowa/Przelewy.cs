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
        protected decimal Amount;
        protected string TransferTitle;
        protected int SenderAccountID;
        protected int RecipientAccountID;
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
