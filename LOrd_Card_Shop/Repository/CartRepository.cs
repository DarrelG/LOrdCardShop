using LOrd_Card_Shop.Singleton;
using LOrd_Card_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using LOrd_Card_Shop.Factory;

namespace LOrd_Card_Shop.Repository
{
    public class CartRepository : dbSingleton
    {
        public static List<CartItemResult> GetCartItems(int userID)
        {
            InitAsync();
            return CartDb.Where(c => c.UserID == userID).Include(x => x.Card)
                .Select(c => new CartItemResult
                {
                    CardName = c.Card.CardName,
                    CardPrice = c.Card.CardPrice,
                    Quantity = c.Quantity,
                    CardDesc = c.Card.CardDesc
                })
                .ToList();
        }

        public static void ClearCart(int userID)
        {
            var cartItems = CartDb.Where(c => c.UserID == userID).ToList();
            CartDb.RemoveRange(cartItems);
            saveDbChange();
        }

        public static Carts getCartDataByUserId(int userID)
        {
            InitAsync();
            return CartDb.FirstOrDefault(c => c.UserID == userID);
        }

        public static Carts getCartData(int userId, int cardId)
        {
            InitAsync();
            return CartDb.FirstOrDefault(c => c.UserID == userId && c.CardID == cardId);
        }

        public static void AddToCart(int userID, int cardID)
        {
            Carts newCart = CartFactory.addNewCart(userID, cardID);
            CartDb.Add(newCart);
            saveDbChange();
        }
    }
}