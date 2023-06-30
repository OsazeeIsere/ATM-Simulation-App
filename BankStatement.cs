using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Simulation_App
{
    // Bank statement class
    public class BankStatement
    {
        private List<string> transactions;
        private Dictionary<DateTime, int> transactionCount;
        public BankStatement()
        {
            transactions = new List<string>();
            transactionCount = new Dictionary<DateTime, int>();
        }

        public void AddTransaction(string transaction)
        {
            transactions.Add(transaction);
        }
        public void LogTransaction(int cardNum)
        {
            transactionCount.Add(DateTime.Now, cardNum);
        }

        public bool CheckTransaction(int cardNum)
        {
            int count = 0;
            for(int i = 0; i < transactionCount.Count; i++)
            {
                if (transactionCount.ContainsKey(DateTime.Today) && transactionCount.ContainsValue(cardNum))
                {
                 count++;
                }
            }
            if (count <= 10)
            {
                return true;
            }
            return false;
            
        }
        public void PrintStatement()
        {
            Console.WriteLine("Bank Statement:");
            foreach (string transaction in transactions)
            {
                Console.WriteLine(transaction);
            }
        }
    }
}
