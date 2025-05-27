using LOrd_Card_Shop.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LOrd_Card_Shop.Models;

namespace LOrd_Card_Shop.Controller
{
    public class CartController
    {
        public static void AddToCart(int userId, int cardId)
        {
            CartHandler.AddToCart(userId, cardId);
        }

        public static List<CartItemResult> GetCartItems(int userId)
        {
            return CartHandler.GetCartItem(userId);
        }
        public static decimal CalculateTotal(List<CartItemResult> items)
        {
            return CartHandler.CalculateTotal(items);
        }
        public static bool Checkout(int userId)
        {
            return CartHandler.Checkout(userId);
        }
    }
}