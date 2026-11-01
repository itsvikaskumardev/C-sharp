
using System;
using System.Collections.Generic;

namespace SOLID_PRINCIPLES
{
    internal class LSP_Violated
    {
        public class Account
        {
            public virtual void Deposit(double amount)
            {
            }

            public virtual void Withdraw(double amount)
            {
            }
        }

        public class SavingAccount : Account
        {
            double balance;

            public SavingAccount()
            {
                balance = 0;
            }

            public override void Deposit(double amount)
            {
                balance += amount;
                Console.WriteLine($"Deposited Amount: {amount} in Saving Account, New Balance: {balance}\n");
            }

            public override void Withdraw(double amount)
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

        public class CurrentAccount : Account
        {
            double balance;

            public CurrentAccount()
            {
                balance = 0;
            }

            public override void Deposit(double amount)
            {
                balance += amount;
                Console.WriteLine($"Deposited Amount: {amount} in Current Account, New Balance: {balance}\n");
            }

            public override void Withdraw(double amount)
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

        public class FixedDepositAccount : Account
        {
            double balance;

            public FixedDepositAccount()
            {
                balance = 0;
            }

            public override void Deposit(double amount)
            {
                balance += amount;
                Console.WriteLine($"Deposited Amount: {amount} in Fixed Deposit Account, New Balance: {balance}\n");
            }

            public override void Withdraw(double amount)
            {
                throw new InvalidOperationException("Withdrawal is not allowed in Fixed Deposit Account");
            }
        }

        public class BankClient
        {
            List<Account> accounts;

            public BankClient(List<Account> accounts)
            {
                this.accounts = accounts;
            }

            public void ProcessTransaction()
            {
                foreach (Account account in accounts)
                {
                    account.Deposit(1000); // All accounts allow deposits
                }

                // Assuming all accounts support withdrawal (LSP Violation)

                foreach (Account account in accounts)
                {
                    try
                    {
                        account.Withdraw(500);
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine($"Exception: {e.Message}");
                    }
                }
            }
        }

        // Main Function
        public static void Run()
        {
            List<Account> accounts = new List<Account>();

            accounts.Add(new SavingAccount());
            accounts.Add(new CurrentAccount());
            accounts.Add(new FixedDepositAccount());

            BankClient client = new BankClient(accounts);

            client.ProcessTransaction();
        }
    }
}
