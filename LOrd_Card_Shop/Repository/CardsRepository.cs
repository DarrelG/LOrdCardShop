using LOrd_Card_Shop.Factory;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Singleton;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LOrd_Card_Shop.Repository
{
    public class CardRepository : dbSingleton
    {
        Database1Entities db = new Database1Entities();

        public List<Card> GetAllCards()
        {
            return db.Card.ToList();
        }

        public Card GetCardById(int id)
        {
            return db.Card.Find(id);
        }
        public void AddToCart(int userID, int cardID)
        {
            var existingCart = db.Carts.FirstOrDefault(c => c.UserID == userID && c.CardID == cardID);
            if (existingCart != null)
            {
                existingCart.Quantity += 1;
            }
            else
            {
                Carts newCart = new Carts
                {
                    UserID = userID,
                    CardID = cardID,
                    Quantity = 1
                };
                db.Carts.Add(newCart);
            }
            
            db.SaveChanges();
        }
    }
}