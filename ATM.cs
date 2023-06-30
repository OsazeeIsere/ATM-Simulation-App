using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Simulation_App
{
    // ATM class
    public class ATM
    {

        private Dictionary<int, string> userAccounts;
        private Dictionary<int, string> userPINs;
        private Dictionary<int, string> userMobileNumbers;
        private Dictionary<int, decimal> accountBalances;
        private BankStatement bankStatement;

        public ATM()
        {
            userAccounts = new Dictionary<int, string>();
            userPINs = new Dictionary<int, string>();
            userMobileNumbers = new Dictionary<int, string>();
            accountBalances = new Dictionary<int, decimal>();
            bankStatement = new BankStatement();
        }

        public void RegisterAccount()
        {

            userAccounts.Add(12345678, "Osazee Isere");
            userPINs.Add(12345678, "123");
            userMobileNumbers.Add(12345678, "081234567");
            accountBalances.Add(12345678, 500);
            //register second account
            userAccounts.Add(23456789, "Osaro Mark");
            userPINs.Add(23456789, "234");
            userMobileNumbers.Add(23456789, "0822234567");
            accountBalances.Add(23456789, 400);

            //register a third account
            userAccounts.Add(34567812, "Joe Dan");
            userPINs.Add(34567812,"345");
            userMobileNumbers.Add(34567812, "084567123");
            accountBalances.Add(34567812, 600);

            //register the fourth account
            userAccounts.Add(45678123, "Osazee Isere");
            userPINs.Add(45678123,"456");
            userMobileNumbers.Add(45678123, "084567123");
            accountBalances.Add(45678123, 700);
        }
       
        public bool VerifyCard(int cardNumber)
        {
            // Check if the card number is recorded correctly
            return userAccounts.ContainsKey(cardNumber);
        }

        public bool VerifyPIN(int cardNumber, string pin)
        {
            // Verify user by comparing PIN
            if (userPINs.ContainsKey(cardNumber))
            {
                string storedPIN = userPINs[cardNumber];
                return pin == storedPIN;
            }
            return false;
        }

        public void WithdrawCash(int cardNumber,decimal amount, Withdrawal withdrawal)
        {
           if(VerifyCard(cardNumber))
            {
                decimal currentBalance = accountBalances[cardNumber];
                withdrawal.ProcessWithdrawal(currentBalance);
                // Update account balance and perform other necessary operations
                accountBalances[cardNumber] = currentBalance - amount;
                bankStatement.AddTransaction($"Withdrawal: {amount:C}");
                bankStatement.LogTransaction(cardNumber);
                // ...
            }
            
        }

        public void PrintBankStatement(int cardNumber)
        {
            bankStatement.PrintStatement();
        }
        public void CheckBalance(int cardNumber)
        {
            Console.WriteLine($"Your Account Balance is: {accountBalances[cardNumber]:C}");

        }
        public bool CheckTheNumberOfTransaction(int cardNumber)
        {
           if(bankStatement.CheckTransaction(cardNumber))
           {
                return  true;
           }
           return false;
        }
    }
}
