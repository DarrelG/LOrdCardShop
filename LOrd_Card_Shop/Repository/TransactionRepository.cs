using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Singleton;
using System.Threading.Tasks;

namespace LOrd_Card_Shop.Repository
{
    public class TransactionRepository : dbSingleton
    {
        public static List<TransactionHeader> GetTransactionHistory(int? userId)
        {
            InitAsync().Wait();
            return ThDb.Where(x => !userId.HasValue || x.CustomerID == userId).ToList();
        }

        public static List<TransactionDetailResult> GetTransactionDetails(int transactionId)
        {
            InitAsync();

            var res = TdDb
                .Where(td => td.TransacttionID == transactionId)
                .Include(td => td.Card)
                .ToList();


            List<TransactionDetailResult> result = new List<TransactionDetailResult>();

            foreach (var item in res)
            {
                {
                    result.Add(new TransactionDetailResult
                    {
                        CardName = item.Card.CardName,
                        Quantity = item.Quantity
                    });
                };
                
            }
            return result;
        }
    }
}