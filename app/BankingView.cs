using System;
using ATMApp.Services;

namespace ATMApp.View
{
    public static class BankingView
    {
        public static void Run()
        {
            double balance = 1000.00;
            int choice;

            Console.WriteLine("Kenjay Lungayan");
            Console.WriteLine("=== Simple ATM System ===");
            Console.WriteLine();
            Console.WriteLine($"Initial Balance: ₱{balance:F2}");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("1: Check Balance");
                Console.WriteLine("2: Deposit Money");
                Console.WriteLine("3: Withdraw Money");
                Console.WriteLine("4: Print Mini Statement");
                Console.WriteLine("5: Exit");
                Console.Write("Select option: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid option selected. Please try again.");
                    Console.WriteLine();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        double currentBalance = BankingServices.GetBalance(balance);
                        Console.WriteLine($"Current Balance: ₱{currentBalance:F2}");
                        Console.WriteLine();
                        break;

                    case 2:
                        Console.Write("Enter amount to deposit: ");
                        if (!double.TryParse(Console.ReadLine(), out double depositAmount))
                        {
                            Console.WriteLine("Invalid deposit amount. Please enter a positive value.");
                            Console.WriteLine();
                            continue;
                        }

                        if (!BankingServices.Deposit(ref balance, depositAmount))
                        {
                            Console.WriteLine("Invalid deposit amount. Please enter a positive value.");
                            Console.WriteLine();
                            continue;
                        }

                        Console.WriteLine("Deposit successful.");
                        Console.WriteLine($"Updated Balance: ₱{balance:F2}");
                        Console.WriteLine();
                        break;

                    case 3:
                        Console.Write("Enter amount to withdraw: ");
                        if (!double.TryParse(Console.ReadLine(), out double withdrawAmount))
                        {
                            Console.WriteLine("Invalid withdrawal amount. Please enter a positive value.");
                            Console.WriteLine();
                            continue;
                        }

                        BankingServices.Withdraw(ref balance, withdrawAmount, out bool isSuccessful);

                        if (!isSuccessful)
                        {
                            if (withdrawAmount <= 0)
                            {
                                Console.WriteLine("Invalid withdrawal amount. Please enter a positive value.");
                            }
                            else
                            {
                                Console.WriteLine("Withdrawal failed. Insufficient balance.");
                            }
                            Console.WriteLine();
                            continue;
                        }

                        Console.WriteLine("Withdrawal successful.");
                        Console.WriteLine($"Updated Balance: ₱{balance:F2}");
                        Console.WriteLine();
                        break;

                    case 4:
                        var statement = BankingServices.GetMiniStatement(balance);
                        Console.WriteLine("--- Mini Statement ---");
                        Console.WriteLine($"Current Balance: ₱{statement.currentBalance:F2}");
                        Console.WriteLine($"Last Transaction Amount: ₱{statement.lastTransaction:F2}");
                        Console.WriteLine();
                        break;

                    case 5:
                        Console.WriteLine("Thank you for using the ATM. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid option selected. Please try again.");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
