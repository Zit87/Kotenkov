using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{


    internal class Program
    {
        class BankAccount
        {
            public decimal balance;

            public BankAccount(decimal balance)
            {
                this.balance = balance;
            }

            
            public void Deposit(decimal amount)
            {
                if (amount <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(amount),
                        "Сумма пополнения должна быть больше 0."
                    );
                }

                balance += amount;




            }
            public void Withdraw(decimal amount)
            {

                if (amount <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(amount),
                        "Сумма списания должна быть больше 0."
                    );
                }

                if (amount > balance)
                {
                    throw new InvalidOperationException(
                        "Недостаточно средств на счёте."
                    );
                }

                balance -= amount;
            }

        }


            static void Main(string[] args)
            {
            Console.WriteLine("Введите начальный баланс:");
            decimal initialBalance;

            while (!decimal.TryParse(Console.ReadLine(), out initialBalance))
            {
                Console.WriteLine("Ошибка! Введите число:");
            }

            BankAccount bank = new BankAccount(initialBalance);

            try
            {
                Console.WriteLine("Пополнить - 1");
                Console.WriteLine("Списать - 2");

                int b;

                if (!int.TryParse(Console.ReadLine(), out b))
                {
                    throw new ArgumentException("Некорректный выбор операции.");
                }

                switch (b)
                {
                    case 1:
                        Console.WriteLine("Введите сумму пополнения:");

                        decimal depositAmount;

                        if (!decimal.TryParse(Console.ReadLine(), out depositAmount))
                        {
                            throw new ArgumentException("Некорректная сумма.");
                        }

                        bank.Deposit(depositAmount);
                        Console.WriteLine("Счёт успешно пополнен.");
                        break;

                    case 2:
                        Console.WriteLine("Введите сумму списания:");

                        decimal withdrawAmount;

                        if (!decimal.TryParse(Console.ReadLine(), out withdrawAmount))
                        {
                            throw new ArgumentException("Некорректная сумма.");
                        }

                        bank.Withdraw(withdrawAmount);
                        Console.WriteLine("Средства успешно списаны.");
                        break;

                    default:
                        throw new ArgumentException("Такой операции нет.");
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка диапазона: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Ошибка операции: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Неизвестная ошибка: {ex.Message}");
            }
            finally
            {
                Console.WriteLine($"Актуальный баланс: {bank.balance}");
            }
            
        
        }

    }
}

