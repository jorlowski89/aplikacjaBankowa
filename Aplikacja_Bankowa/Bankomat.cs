using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacja_Bankowa
{
    public class Bankomat
    {
        private decimal balance;

        public Bankomat( decimal initialBalance)
        {
            this.balance = initialBalance;
        }
 
        public decimal GetBalance()
        {
            return balance;
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"Deposited: {amount:C}. New balance: {balance:C}");
            }
            else
            {
                Console.WriteLine("Deposit amount must be positive.");
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"Withdrawn: {amount:C}. New balance: {balance:C}");
            }
            else
            {
                Console.WriteLine("Insufficient funds or invalid amount.");
            }
        }
    }
}
