using System;

public class BankingService
{
    private double lastTransactionAmount = 0.00;

    // OPTION 1 – Pass-by-value (Read only)
    public void CheckBalance(double balance)
    {
        // No modification needed (display handled in View)
    }

    // OPTION 2 – Deposit using ref
    public bool Deposit(ref double balance, double amount)
    {
        if (amount <= 0)
        {
            return false;
        }

        balance += amount;
        lastTransactionAmount = amount;
        return true;
    }

    // OPTION 3 – Withdraw using ref and out
    public void Withdraw(ref double balance, double amount, out bool isSuccessful)
    {
        if (amount <= 0)
        {
            isSuccessful = false;
            return;
        }

        if (amount > balance)
        {
            isSuccessful = false;
            return;
        }

        balance -= amount;
        lastTransactionAmount = amount;
        isSuccessful = true;
    }

    // OPTION 4 – Mini Statement (Pass-by-value)
    public double GetLastTransaction()
    {
        return lastTransactionAmount;
    }

    public void PrintMiniStatement(double balance, double lastTransaction)
    {
        // Display handled in View
    }
}
