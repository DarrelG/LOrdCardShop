using LOrd_Card_Shop.Handler;
using LOrd_Card_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Controller
{
    public class TransactionHeaderController
    {
        public static List<TransactionHeader> GetTransactionHeaders()
        {
            return TransactionHeaderHandler.getAllTransaction();
        }
        public static void editStatus(int id)
        {
            TransactionHeaderHandler.editTransactionStatus(id);
        }
    }
}