using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Handler
{
    public class CartHandler
    {
        public static List<CartItemResult> GetCartItem(int userID)
        {
            var cartItems = CartRepository.GetCartItems(userID);
            return cartItems;
        }
        public static decimal CalculateTotal(List<CartItemResult> items)
        {
            return items.Sum(i => i.CardPrice * i.Quantity);
        }
        public static bool Checkout(int userID)
        {
            try
            {
                CartRepository.ClearCart(userID);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static void AddToCart(int userID, int cardID)
        {
            var existedData = CartRepository.getCartData(userID, cardID);
            if (existedData != null)
            {
                existedData.Quantity += 1;
                CartRepository.saveDbChange();
            }
            else
            {
                CartRepository.AddToCart(userID, cardID);
            }
        }
    }
}