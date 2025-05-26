using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Views;

namespace LOrd_Card_Shop.Repository
{
    public class CartRepository
    {
        Database1Entities db = new Database1Entities();

        public List<Carts> GetCartItems(int userID)
        {
            return db.Carts.Include(c => c.Card).Where(c => c.UserID == userID).Include(c=> c.Card).ToList();
        }
        public void ClearCart(int userID)
        {
            var cartItems = db.Carts.Where(c => c.UserID == userID).ToList();
            db.Carts.RemoveRange(cartItems);
            db.SaveChanges();
        }

        public void AddToCart(int userID, int cardID)
        {
            // Masukin ke Handler
            var existingCart = CartDb.FirstOrDefault(c => c.UserID == userID && c.CardID == cardID);
            if (existingCart != null)
            {
                existingCart.Quantity += 1;
            }
            else
            {
                //Masukin ke Factory
                Carts newCart = new Carts
                {
                    UserID = userID,
                    CardID = cardID,
                    Quantity = 1
                };
                CartDb.Add(newCart);
            }

            saveDbChange();
        }
    }
}