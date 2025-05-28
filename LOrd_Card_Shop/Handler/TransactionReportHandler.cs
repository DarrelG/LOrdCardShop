using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Handler
{
    public class TransactionReportHandler
    {
        public static List<TransactionReportModel> GetReportData()
        {
            return TransactionRepository.GetTransactionReportData();
        }
    }
}