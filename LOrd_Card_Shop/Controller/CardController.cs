using System;
using System.Collections.Generic;
using LOrd_Card_Shop.Handler;
using LOrd_Card_Shop.Models;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Controller
{
    public class CardController
    {
        public static List<Card> GetAllCards()
        {
            return CardHandler.GetAllCards();
        }

        public static Card GetCardById(int id)
        {
            return CardHandler.GetCardById(id);
        }
        public static List<Card> SearchCards(string query)
        {
            return CardHandler.SearchCards(query);
        }
    }
}