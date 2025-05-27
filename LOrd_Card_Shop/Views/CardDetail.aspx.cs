using LOrd_Card_Shop.Handler;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;

namespace LOrd_Card_Shop.Views
{
    public partial class CardDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null || Request.Cookies["user_cookies"] != null)
                {
                    LoadCardDetails();
                }
            }
        }
        private void LoadCardDetails()
        {
            if (!int.TryParse(Request.QueryString["cardId"], out int cardId))
            {
                Response.Redirect("OrderCard.aspx");
                return;
            }

            var card = CardController.GetCardById(cardId);

            if (card == null)
            {
                Response.Redirect("OrderCard.aspx");
                return;
            }

            lblName.Text = card.CardName;
            lblPrice.Text = card.CardPrice.ToString("C");
            lblType.Text = card.CardType;
            lblDescription.Text = card.CardDesc;
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderCard.aspx");
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["UserID"]);
            int cardId = Convert.ToInt32(Request.QueryString["CardID"]);

            CartController.AddToCart(userId, cardId);
            ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Card Added');", true);
        }
    }
}