
using System;
using System.Collections.Generic;

namespace SOLID_PRINCIPLES
{
    internal class LSP_Followed
    {
        // Interface for all accounts that support deposits
        public interface IDeposit
        {
            void Deposit(double amount);
        }

        // Interface only for accounts that support withdrawals
        public interface IWithdraw
        {
            void Withdraw(double amount);
        }

        // Saving Account supports both deposit and withdrawal
        public class SavingAccount : IDeposit, IWithdraw
        {
            double balance;

            public SavingAccount()
            {
                balance = 0;
            }

            public void Deposit(double amount)
            {
                balance += amount;
                Console.WriteLine($"Deposited Amount: {amount} in Saving Account, New Balance: {balance}\n");
            }

            public void Withdraw(double amount)
            {
                if (balance >= amount)
                {
                    balance -= amount;
                    Console.WriteLine($"Withdrawn Amount: {amount} from Saving Account. New Balance: {balance}");
                }
                else
                {
                    Console.WriteLine("Insufficient funds in Saving Account");
                }
            }
        }

        // Current Account supports both deposit and withdrawal
        public class CurrentAccount : IDeposit, IWithdraw
        {
            double balance;

            public CurrentAccount()
            {
                balance = 0;
            }

            public void Deposit(double amount)
            {
                balance += amount;
                Console.WriteLine($"Deposited Amount: {amount} in Current Account, New Balance: {balance}\n");
            }

            public void Withdraw(double amount)
            {
                if (balance >= amount)
                {
                    balance -= amount;
                    Console.WriteLine($"Withdrawn Amount: {amount} from Current Account. New Balance: {balance}");
                }
                else
                {
                    Console.WriteLine("Insufficient funds in Current Account");
                }
            }
        }

        // Fixed Deposit Account supports only deposits
        public class FixedDepositAccount : IDeposit
        {
            double balance;

            public FixedDepositAccount()
            {
                balance = 0;
            }

            public void Deposit(double amount)
            {
                balance += amount;
                Console.WriteLine($"Deposited Amount: {amount} in Fixed Deposit Account, New Balance: {balance}\n");
            }
        }

        // Bank Client
        public class BankClient
        {
            List<IDeposit> depositAccounts;
            List<IWithdraw> withdrawAccounts;

            public BankClient(
                List<IDeposit> depositAccounts,
                List<IWithdraw> withdrawAccounts)
            {
                this.depositAccounts = depositAccounts;
                this.withdrawAccounts = withdrawAccounts;
            }

            public void ProcessTransaction()
            {
                // All accounts support deposits
                foreach (IDeposit account in depositAccounts)
                {
                    account.Deposit(1000);
                }

                // Only accounts that support withdrawals are processed
                foreach (IWithdraw account in withdrawAccounts)
                {
                    account.Withdraw(500);
                }
            }
        }

        // Main Function
        public static void Run()
        {
            // Creating account objects
            SavingAccount savingAccount = new SavingAccount();
            CurrentAccount currentAccount = new CurrentAccount();
            FixedDepositAccount fixedDepositAccount = new FixedDepositAccount();

            // Accounts that support deposits
            List<IDeposit> depositAccounts = new List<IDeposit>();

            depositAccounts.Add(savingAccount);
            depositAccounts.Add(currentAccount);
            depositAccounts.Add(fixedDepositAccount);

            // Accounts that support withdrawals
            List<IWithdraw> withdrawAccounts = new List<IWithdraw>();

            withdrawAccounts.Add(savingAccount);
            withdrawAccounts.Add(currentAccount);

            // Creating BankClient Object
            BankClient client = new BankClient(
                depositAccounts,
                withdrawAccounts);

            // Calling Method
            client.ProcessTransaction();
        }
    }
}
