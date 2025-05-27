using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Web;

namespace LOrd_Card_Shop.Handler
{
    public class TransactionHeaderHandler
    {
        public static List<TransactionHeader> getAllTransaction()
        {
            return TransactionHeaderRepository.getAllTransaction();
        }

        public static void editTransactionStatus(int id)
        {
            TransactionHeader transaction = TransactionHeaderRepository.GetTransactionById(id);
            if(transaction.Status == "Waiting")
            {
                transaction.Status = "Completed";
            }

            TransactionHeaderRepository.editStatus(transaction);

        }
    }
}