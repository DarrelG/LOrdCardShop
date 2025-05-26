using System;
using System.Collections.Generic;
using LOrd_Card_Shop.Singleton;
using System.Linq;
using System.Web;
using LOrd_Card_Shop.Models;
using System.Threading.Tasks;
using LOrd_Card_Shop.Factory;

namespace LOrd_Card_Shop.Repository
{
    public class CardRepository : dbSingleton
    {
        public static List<Card> GetAllCards()
        {
            InitAsync().Wait();
            List<Card> cards = CardDb.ToList();
            return cards;
        }

        public static Card GetCardById(int id)
        {
            return CardDb.Find(id);
        }

        public static void deleteCard(int id)
        {
            //InitAsync().Wait();
            Card deleteCard = CardDb.FirstOrDefault(x => x.CardID == id);
            if (deleteCard != null)
            {
                CardDb.Remove(deleteCard);
                saveDbChange();
                //try
                //{
                    
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex);
                //}
            }
        }

        public static void editCard(int id, string name, decimal price, string desc, string type, bool isCurFoil)
        {
            InitAsync().Wait();
            Card existingCard = CardDb.FirstOrDefault(x => x.CardID == id);
            if (existingCard != null)
            {
                try
                {
                    existingCard.CardName = name;
                    existingCard.CardPrice = price;
                    existingCard.CardDesc = desc;
                    existingCard.CardType = type;
                    existingCard.isFoil = isCurFoil;
                    saveDbChange();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
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