using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Simulation_App
{
    // Fast withdrawal subclass
    public class FastWithdrawal : Withdrawal
    {
        public FastWithdrawal(decimal amount) : base(amount)
        {
        }

        public override void ProcessWithdrawal(decimal currentBalance)
        {
             // Implement fast withdrawal logic
            if(amount==20|| amount==50|| amount == 100)
            {
                Console.WriteLine($"Withdrawing {amount:C} using the fast withdrawal method.");
                // Deduct the amount from the current balance
                decimal updatedBalance = currentBalance - amount;
                Console.WriteLine($"New balance: {updatedBalance:C}");
            }
            else
            {
                Console.WriteLine("Please, you can only withdraw $20,$50 or $100 under fast withdrawal provision ");

            }

        }
    }
}
