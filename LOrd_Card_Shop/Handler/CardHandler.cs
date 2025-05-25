using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Repository;

namespace LOrd_Card_Shop.Handler
{
    public class CardHandler
    {
        CardRepository repo = new CardRepository();

        public List<Card> GetAllCards()
        {
            return repo.GetAllCards();
        }
        public Card GetCardById(int id)
        {
            return repo.GetCardById(id);
        }
        public string AddToCart(int userID, int cardId)
        {
            if (userID == 0) return "Please login first";
            if (cardId == 0) return "Invalid card";

            repo.AddToCart(userID, cardId);
            return "Item added to cart!";
        }
        public Card GetCardDetails(int cardId)
        {
            return repo.GetCardById(cardId);
        }
    }
}