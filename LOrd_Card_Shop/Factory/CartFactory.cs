using LOrd_Card_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Factory
{
    public class CartFactory
    {
        public static Carts addNewCart(int userID, int cardID)
        {
            Carts carts = new Carts();
            carts.UserID = userID;
            carts.CardID = cardID;
            carts.Quantity = 1;
            return carts;
        }
    }
}