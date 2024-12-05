using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov_DZ
{
    public enum AccountType
    {
        Savings,
        Current
    }
    internal class BankAccount      
    {
        private static int nextAccountNumber = 1000000;
        private string AccountNumber;
        private decimal Balance;
        private AccountType AccountType;

        public BankAccount(decimal balance, AccountType accountType)
        {
            AccountNumber = GenerateAccountNumber();
            Balance = balance;
            AccountType = accountType;
        }

        public void SetAccountInfo(string accountNumber, decimal balance, AccountType accountType)
        {
            AccountType=  accountType;
            Balance = balance;
            AccountNumber = accountNumber;
        }
        public string GetAccountInfo()
        {
            return AccountNumber;
        }
        public decimal GetBalance()
        {
            return Balance;
        }

        public AccountType GetAccountType()
        {
            return AccountType;
        }
        private static string GenerateAccountNumber()
        {
            return (nextAccountNumber++).ToString("D10"); 
        }
        public void PrintAccountDetails()
        {
            Console.WriteLine("Информация о счете");
            Console.WriteLine($"Номер счета:{AccountNumber}");
            Console.WriteLine($"Баланс:{Balance}");
            Console.WriteLine($"Тип счета: {AccountType}");
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"Счет пополнен на сумму: {amount.ToString("C", CultureInfo.CreateSpecificCulture("en-US"))}");
            }
            else
            {
                Console.WriteLine("Ошибка: Сумма для пополнения должна быть больше нуля.");
            }
        }
        public void Withdraw(decimal amount)
        {
            if (amount > 0)
            {
                if (amount <= Balance)
                {
                    Balance -= amount;
                    Console.WriteLine($"Со счета снята сумма: {amount.ToString("C", CultureInfo.CreateSpecificCulture("en-US"))}");
                }
                else
                {
                    Console.WriteLine("Ошибка: Недостаточно средств на счете.");
                }
            }
            else
            {
                Console.WriteLine("Ошибка: Сумма для снятия должна быть больше нуля.");
            }
        }
    }
}
