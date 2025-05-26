using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Repository
{
    public class TransactionReportRepository : dbSingleton
    {
        public static List<TransactionReportModel> GetTransactionReportData()
        {
            InitAsync().Wait();

            var result = from td in TdDb
                         join th in ThDb on td.TransacttionID equals th.TransactionID
                         join u in UserDb on th.CustomerID equals u.UserID
                         join c in CardDb on td.CardID equals c.CardID
                         select new TransactionReportModel
                         {
                             TransactionID = th.TransactionID,
                             TransactionDate = th.TransactionDate,
                             CustomerName = u.UserName,
                             CardName = c.CardName,
                             Quantity = td.Quantity,
                             CardPrice = c.CardPrice,
                             SubTotal = td.Quantity * c.CardPrice
                         }; 
            return result.ToList();
        }
    }
}