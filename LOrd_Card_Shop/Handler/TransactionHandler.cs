using LOrd_Card_Shop.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using LOrd_Card_Shop.Repository;
using LOrd_Card_Shop.Views;
using TransactionDetail = LOrd_Card_Shop.Models.TransactionDetail;

namespace LOrd_Card_Shop.Handler
{
    public class TransactionHandler
    {
        public static List<TransactionDetailResult> GetTransactionDetails(int transactionId)
        {
            return TransactionRepository.GetTransactionDetails(transactionId);
        }

        public static List<TransactionHeader> GetTransactionHistory(int userId, string userRole)
        {
            if (UserRepository.getUserById(userId) == null)
            {
                throw new Exception("User not found");
            }
            else if (userRole == "Admin")
            {
                return TransactionRepository.GetTransactionHistory(null);
            }
            else
            {
                return TransactionRepository.GetTransactionHistory(userId);
            }
        }  
    }
}