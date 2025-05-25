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
     
        public static List<TransactionHeader> GetTransactionHistory(HttpSessionState Session, HttpResponse Response)
        {
            try
            {
                if (Session["UserID"] != null)
                {
                    int userId = Convert.ToInt32(Session["UserID"]);
                    Users userData = UserRepository.getUserById(userId);

                    if(string.Equals(userData.UserRole, "Admin"))
                    {
                        return TransactionRepository.GetTransactionHistory(null);
                    }
                    else
                    {
                        return TransactionRepository.GetTransactionHistory(userId);
                    }

                    
                }
                else
                {
                    throw new Exception("User not logged in");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Login.aspx");
                return new List<TransactionHeader>();
            }

        }
    }
}