using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Repository;
using System.Threading.Tasks;
using System.CodeDom;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace LOrd_Card_Shop.Handler
{
    public class CardHandler
    {
        public static List<Card> GetAllCards()
        {
            return CardRepository.GetAllCards();
        }
        public static Card GetCardById(int id)
        {
            return CardRepository.GetCardById(id);
        }

        public static Card GetCardDetails(int cardId)
        {
            return CardRepository.GetCardById(cardId);
        }

        public static void editCardHandler(int id, string name, decimal price, string desc, string type, string foil, Label error, HttpResponse response)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name) || name.Length < 5 || name.Length > 50 || !Regex.IsMatch(name, @"^[A-Za-z\s]+$"))
                {
                    throw new Exception("Name must be 5-50 characters and alphabetic with spaces only.");
                }
                if (price < 10000)
                {
                    throw new Exception("Price must be a valid number and >= 10000.");
                }
                else if (string.IsNullOrWhiteSpace(desc))
                {
                    throw new Exception("Description must not be empty.");
                }
                else if (type != "Spell" && type != "Monster")
                {
                    throw new Exception("Type must be 'Spell' or 'Monster'.");
                }
                else if (foil != "yes" && foil != "no")
                {
                    throw new Exception("Foil must be 'yes' or 'no'.");
                }

                bool isFoil = foil == "yes";

                CardRepository.editCard(id, name, price, desc, type, isFoil);

                response.Redirect("ManageCard.aspx");

            }
            catch (Exception ex)
            {
                error.Text = ex.Message;
            }
        }
        public static void deleteCardHandler(int id)
        {
            Card cardToDelete = CardRepository.GetCardById(id);
            CardRepository.deleteCard(cardToDelete);
        }

        public async static Task addCardHandler(string name, decimal price, string desc, string type, string foil, Label error, HttpResponse response)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name) || name.Length < 5 || name.Length > 50 || !Regex.IsMatch(name, @"^[A-Za-z\s]+$"))
                {
                    throw new Exception("Name must be 5-50 characters and alphabetic with spaces only.");
                }
                if (price < 10000)
                {
                    throw new Exception("Price must be a valid number and >= 10000.");
                }
                if (string.IsNullOrWhiteSpace(desc))
                {
                    throw new Exception("Description must not be empty.");
                }
                if (type != "Spell" && type != "Monster")
                {
                    throw new Exception("Type must be 'Spell' or 'Monster'.");
                }
                if (foil != "yes" && foil != "no")
                {
                    throw new Exception("Foil must be 'yes' or 'no'.");
                }

                bool isFoil = foil == "yes";

                await CardRepository.addCard(name, price, desc, type, isFoil);
            }
            catch (Exception ex)
            {
                error.Text = ex.Message;
            }
        }
        public static List<Card> SearchCards(string query)
        {
            return GetAllCards().Where(c => c.CardName.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }
    }
}
