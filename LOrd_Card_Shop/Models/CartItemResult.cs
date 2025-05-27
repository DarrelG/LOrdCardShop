using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Models
{
    public class CartItemResult
    {
        public string CardName { get; set; }
        public decimal CardPrice { get; set; }
        public int Quantity { get; set; }
        public string CardDesc { get; set; }
    }
}