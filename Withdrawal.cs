using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Simulation_App
{
    // Abstract class for withdrawal
    public abstract class Withdrawal
    {
        protected decimal amount;

        public Withdrawal(decimal amount)
        {
            this.amount = amount;
        }

        public abstract void ProcessWithdrawal(decimal currentBalance);
    }
}
