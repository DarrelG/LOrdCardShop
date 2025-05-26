using LOrd_Card_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Factory
{
    public class CardFactory
    {
        public static Card createNewCard(string name, decimal price, string desc, string type, bool foil)
        {
            Card newCard = new Card();
            newCard.CardName = name;
            newCard.CardPrice = price;
            newCard.CardDesc = desc;
            newCard.CardType = type;
            newCard.isFoil = foil;
            newCard.CartsCartID = null;

            return newCard;
        }
    }
}