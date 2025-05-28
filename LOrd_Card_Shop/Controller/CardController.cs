using System;
using System.Collections.Generic;
using LOrd_Card_Shop.Handler;
using LOrd_Card_Shop.Models;
using System.Linq;
using System.Web;
using LOrd_Card_Shop.Repository;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

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
        public static void deleteCardHandler(int id)
        {
            CardHandler.deleteCardHandler(id);
        }

        public async static Task addCardController(string name, decimal price, string desc, string type, string foil, Label error, HttpResponse response)
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

                await CardHandler.addCardHandler(name, price, desc, type, isFoil);
            }
            catch (Exception ex)
            {
                error.Text = ex.Message;
            }
        }

        public static void editCardController(int id, string name, decimal price, string desc, string type, string foil, Label error, HttpResponse response)
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
    }
}