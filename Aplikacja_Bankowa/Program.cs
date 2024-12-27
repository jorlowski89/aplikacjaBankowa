using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplikacja_Bankowa.Services;

namespace Aplikacja_Bankowa
{
    internal static class Program
    {
        // Jednorazowa inicjalizacja obiektu DatabaseConnection
        public static DatabaseConnection DbConnection { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Tworzenie instancji DatabaseConnection
            DbConnection = new DatabaseConnection();

            // Test połączenia przy starcie aplikacji (opcjonalnie)
            DbConnection.TestConnection();

            // Przekazanie połączenia do HomePage
            Application.Run(new Login(DbConnection));

        }
    }
}
