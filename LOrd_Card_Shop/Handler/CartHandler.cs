using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LOrd_Card_Shop.Repository;

namespace LOrd_Card_Shop.Handler
{
    public class CartHandler
    {
        CartRepository repo = new CartRepository();
        
        public List<CartItem> GetCartItems(int userID)
        {
            return repo.GetCartItems(userID).Select(c => new CartItem
            {
                CardName = c.Card.CardName,
                CardPrice = c.Card.CardPrice,
                Quantity = c.Quantity,
                CardDesc = c.Card.CardDesc
            }).ToList();
        }
        public decimal CalculateTotal(List<CartItem> items)
        {
            return items.Sum(i => i.CardPrice * i.Quantity);
        }
        public bool Checkout(int userID)
        {
            try
            {
                repo.ClearCart(userID);
                return true;
            }
            catch 
            { 
                return false; 
            }
        }
    }
    public class CartItem
    {
        public string CardName { get; set; }
        public decimal CardPrice { get; set; }
        public int Quantity { get; set; }
        public string CardDesc { get; set; }
    }
}