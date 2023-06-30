using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Simulation_App
{
    // Custom withdrawal subclass
    public class CustomWithdrawal : Withdrawal
    {
        public CustomWithdrawal(decimal amount) : base(amount)
        {
        }

        public override void ProcessWithdrawal(decimal currentBalance)
        {
            
            // Implement custom withdrawal logic
            if (amount <= 1000)//Setting the limit of each transaction to $1000
            {
                Console.WriteLine($"Withdrawing {amount:C} using the custom withdrawal method.");
                // Deduct the amount from the current balance
                decimal updatedBalance = currentBalance - amount;
                Console.WriteLine($"New balance: {updatedBalance:C}");

                // setting a counter for the maximum number of transactions
                // a day to 10
                int transactionCount = 0;
            }
            else
            {
                Console.WriteLine($"Please You Can't Withdraw More Than $1000 Per Transaction");

            }

        }
    }
}
