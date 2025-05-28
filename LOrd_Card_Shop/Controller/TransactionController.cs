using LOrd_Card_Shop.Handler;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace LOrd_Card_Shop.Controller
{
    public class TransactionController
    {
        public static List<TransactionHeader> GetTransactionHistory(HttpSessionState Session, HttpResponse Response)
        {
            try
            {
                string userRole = Session["UserRole"] as string;
                int? userId = Convert.ToInt32(Session["UserID"]);
                if (userId == null)
                {
                    throw new Exception("User not logged in");
                }
                else
                {
                    return TransactionHandler.GetTransactionHistory((int)userId, userRole);
                }
            }
            catch (Exception ex)
            {
                Response.Write($"Error: {ex.Message}");
                return new List<TransactionHeader>();
            }
        }
        
        public static List<TransactionDetailResult> GetTransactionDetails(int transactionId, HttpResponse Response)
        {
            try
            {
                return TransactionHandler.GetTransactionDetails(transactionId);
            }
            catch (Exception ex)
            {
                Response.Write($"Error: {ex.Message}");
                return new List<TransactionDetailResult>();
            }
        }

        public static List<TransactionHeader> GetTransactionHeaders()
        {
            return TransactionHandler.getAllTransaction();
        }
        public static void editStatus(int id)
        {
            TransactionHandler.editTransactionStatus(id);
        }

        public static List<TransactionReportModel> GetAllReportData()
        {
            return TransactionHandler.GetReportData();
        }
    }
}