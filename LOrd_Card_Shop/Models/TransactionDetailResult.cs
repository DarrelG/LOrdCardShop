using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Models
{
    public class TransactionDetailResult
    {
        public int Quantity { get; set; }
        public string CardName { get; set; }
        public decimal CardPrice { get; set; }
        public decimal Total => Quantity * CardPrice;
        public string CardDesc { get; set; }
        public string CardType { get; set; }
    }
}