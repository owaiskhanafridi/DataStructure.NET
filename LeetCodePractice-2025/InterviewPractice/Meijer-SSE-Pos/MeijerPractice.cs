using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace LeetCodePractice_2025.InterviewPractice.Meijer_SSE_Pos
{
    public class MeijerPractice
    {

        public static void Execute()
        {
            MeijerPractice mp = new();

            var transactions = new List<Transaction>()
            {
                new Transaction {UserId ="u1", Amount = 100, TimeStamp = 1000},
                new Transaction {UserId ="u1", Amount = 100, TimeStamp = 1020},
                new Transaction {UserId ="u3", Amount = 50, TimeStamp = 2000},
            };

            //var value = mp.DuplicateTransaction(transactions);
            //Console.Write(value.ToString());
        }

        

        /// <summary>
        /// Find all transactions that are duplicates, 
        /// where: 
        /// Same userId 
        /// Same amount 
        /// Occur within 60 seconds 
        /// 
        /// Return indices or transaction IDs.
        /// </summary>
        /// <param name="transactions"></param>
        /// <returns></returns>
        //public List<int> DuplicateTransaction(List<Transaction> transactions)
        //{
        //    var duplicates = transactions
        //}

    }

    public class Transaction
    {
        public string UserId { get; set; }
        public decimal Amount { get; set; }
        public int TimeStamp { get; set; }
    }
}
