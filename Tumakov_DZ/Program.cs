using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov_DZ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task7_1();
            Task7_4();

        }
        //Задание 7.1/7.2/7.3
        static void Task7_1()
        {
            Console.WriteLine("Создание банковского счета...");

            // Ввод баланса
            decimal balance;
            Console.Write("Введите начальный баланс: ");
            while (!decimal.TryParse(Console.ReadLine(), out balance) || balance < 0)
            {
                Console.WriteLine("Ошибка: Баланс должен быть числом и не меньше нуля. Попробуйте снова.");
                Console.Write("Введите начальный баланс: ");
            }

            // Ввод типа счета
            int accountTypeChoice;
            do
            {
                Console.WriteLine("Тип счета (введите номер): ");
                Console.WriteLine("1. Сберегательный (Savings)");
                Console.WriteLine("2. Расчетный (Checking)");
                Console.Write("Ваш выбор: ");
            }
            while (!int.TryParse(Console.ReadLine(), out accountTypeChoice) || accountTypeChoice < 1 || accountTypeChoice > 3);
            AccountType accountType = (AccountType)(accountTypeChoice - 1);
            BankAccount userAccount = new BankAccount(balance, accountType);


            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Посмотреть информацию о счете");
                Console.WriteLine("2. Положить деньги на счет");
                Console.WriteLine("3. Снять деньги со счета");
                Console.WriteLine("4. Выход");
                Console.Write("Ваш выбор: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            userAccount.PrintAccountDetails();
                            break;
                        case 2:
                            Console.Write("Введите сумму для пополнения: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                            {
                                userAccount.Deposit(depositAmount);
                            }
                            else
                            {
                                Console.WriteLine("Ошибка: Неверный ввод суммы.");
                            }
                            break;
                        case 3:
                            Console.Write("Введите сумму для снятия: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
                            {
                                userAccount.Withdraw(withdrawAmount);
                            }
                            else
                            {
                                Console.WriteLine("Ошибка: Неверный ввод суммы.");
                            }
                            break;
                        case 4:
                            exit = true;
                            Console.WriteLine("Выход из программы.");
                            break;
                        default:
                            Console.WriteLine("Ошибка: Неверный выбор. Попробуйте снова.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка: Неверный ввод. Попробуйте снова.");
                }
            }
        }
        //Домашнее Задание 7.1
        static void Task7_4()
        {
            Console.WriteLine("\n\nДомашнее Задание 7.1");
            Building building = new Building();
            building.SetBuildingDetails();
            building.PrintBuildingInformation();
        }

    }
}
