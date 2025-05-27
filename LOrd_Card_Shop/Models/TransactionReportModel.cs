using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Models
{
    public class TransactionReportModel
    {
        public int TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CustomerName { get; set; }
        public string CardName { get; set; }
        public decimal CardPrice { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
    }
}