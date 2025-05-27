using LOrd_Card_Shop.Factory;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Singleton;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace LOrd_Card_Shop.Repository
{
    public class CardRepository : dbSingleton
    {
        public static List<Card> GetAllCards()
        {
            InitAsync().Wait();
            return CardDb.ToList();
        }

        public static Card GetCardById(int id)
        {
            return CardDb.FirstOrDefault(x => x.CardID == id);
        }

        public static void deleteCard(Card removedCard)
        {
            CardDb.Remove(removedCard);
            saveDbChange();
        }

        public static void editCard(int id, string name, decimal price, string desc, string type, bool foil)
        {
            InitAsync().Wait();
            Card selectedData = CardDb.FirstOrDefault(x => x.CardID == id);
            selectedData.CardName = name;
            selectedData.CardPrice = price;
            selectedData.CardDesc = desc;
            selectedData.CardType = type;
            selectedData.isFoil = foil;
            saveDbChange();

        }

        public async static Task addCard(string name, decimal price, string desc, string type, bool isCurFoil)
        {
            Card addCard = CardFactory.createNewCard(name, price, desc, type, isCurFoil);
            await InitAsync();
            CardDb.Add(addCard);
            saveDbChange();            
        }
    }
}