using System;

public class BankingView
{
    public void DisplayHeader(string name)
    {
        Console.WriteLine($"Name: {name}");
        Console.WriteLine("=== Simple ATM System ===");
        Console.WriteLine();
    }

    public void DisplayInitialBalance(double balance)
    {
        Console.WriteLine($"Initial Balance: ₱{balance:F2}");
        Console.WriteLine();
    }

    public void DisplayMenu()
    {
        Console.WriteLine("1: Check Balance");
        Console.WriteLine("2: Deposit Money");
        Console.WriteLine("3: Withdraw Money");
        Console.WriteLine("4: Print Mini Statement");
        Console.WriteLine("5: Exit");
        Console.Write("Select option: ");
    }

    public void DisplayBalance(double balance)
    {
        Console.WriteLine($"Current Balance: ₱{balance:F2}");
        Console.WriteLine();
    }

    public double PromptDeposit()
    {
        Console.Write("Enter amount to deposit: ");
        return Convert.ToDouble(Console.ReadLine());
    }

    public double PromptWithdraw()
    {
        Console.Write("Enter amount to withdraw: ");
        return Convert.ToDouble(Console.ReadLine());
    }

    public void DisplayDepositSuccess(double balance)
    {
        Console.WriteLine("Deposit successful.");
        Console.WriteLine($"Updated Balance: ₱{balance:F2}");
        Console.WriteLine();
    }

    public void DisplayDepositError()
    {
        Console.WriteLine("Invalid deposit amount. Please enter a positive value.");
        Console.WriteLine();
    }

    public void DisplayWithdrawSuccess(double balance)
    {
        Console.WriteLine("Withdrawal successful.");
        Console.WriteLine($"Updated Balance: ₱{balance:F2}");
        Console.WriteLine();
    }

    public void DisplayWithdrawInsufficient()
    {
        Console.WriteLine("Withdrawal failed. Insufficient balance.");
        Console.WriteLine();
    }

    public void DisplayWithdrawInvalid()
    {
        Console.WriteLine("Invalid withdrawal amount. Please enter a positive value.");
        Console.WriteLine();
    }

    public void DisplayMiniStatement(double balance, double lastTransaction)
    {
        Console.WriteLine("--- Mini Statement ---");
        Console.WriteLine($"Current Balance: ₱{balance:F2}");
        Console.WriteLine($"Last Transaction Amount: ₱{lastTransaction:F2}");
        Console.WriteLine();
    }

    public void DisplayInvalidOption()
    {
        Console.WriteLine("Invalid option selected. Please try again.");
        Console.WriteLine();
    }

    public void DisplayExit()
    {
        Console.WriteLine("Thank you for using the ATM. Goodbye!");
    }
}
