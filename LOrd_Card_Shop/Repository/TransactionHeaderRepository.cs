using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Repository
{
    public class TransactionHeaderRepository : dbSingleton
    {
        public static List<TransactionHeader> getAllTransaction()
        {
            InitAsync().Wait();
            List<TransactionHeader> transactionList = ThDb.ToList();
            return transactionList;
        }

        public static TransactionHeader GetTransactionById(int id)
        {
            InitAsync().Wait();
            return ThDb.FirstOrDefault(t => t.TransactionID == id);
        }

        public static void editStatus(TransactionHeader transaction)
        {
            InitAsync().Wait();
            TransactionHeader transactionChange = GetTransactionById(transaction.TransactionID);

            transactionChange.Status = transaction.Status;

            saveDbChange();
        }
    }
}