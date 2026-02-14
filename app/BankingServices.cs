namespace ATMApp.Services
{
    public static class BankingServices
    {
        // Store last transaction amount
        private static double lastTransactionAmount = 0;

        // Option 1: Pass-by-value (Read Only)
        public static double GetBalance(double balance)
        {
            return balance;
        }

        // Option 2: ref (Deposit)
        public static bool Deposit(ref double balance, double amount)
        {
            if (amount <= 0)
            {
                return false;
            }

            balance += amount;
            lastTransactionAmount = amount;
            return true;
        }

        // Option 3: ref + out (Withdraw)
        public static void Withdraw(
            ref double balance,
            double amount,
            out bool isSuccessful)
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

        // Option 4: Mini Statement (Pass-by-value)
        public static (double currentBalance, double lastTransaction) 
            GetMiniStatement(double balance)
        {
            return (balance, lastTransactionAmount);
        }
    }
}
