using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501Server.Database
{
    public class Transaction
    {
        public decimal Amount { get; private set; }
        public TransactionType TransactionType { get; private set; }

        public Transaction(decimal amount, TransactionType transactionType)
        {
            this.Amount = amount;
            this.TransactionType = transactionType;
        }
    }
}
