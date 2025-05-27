using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Controller;
using LOrd_Card_Shop.Handler;

namespace LOrd_Card_Shop.Views
{
    public partial class OrderCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCards();
            }
        }
        private void LoadCards()
        {
            List<Card> cards = CardController.GetAllCards();

            if (cards == null || cards.Count == 0)
            {
                lblMessage.Text = "No cards available.";
                lblMessage.Visible = true;
                return;
            }

            rptCards.DataSource = cards;
            rptCards.DataBind();
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            if (Session["user"] == null && Request.Cookies["user_cookies"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            int userId = Convert.ToInt32(Session["UserID"]);
            int cardId = Convert.ToInt32((sender as Button).CommandArgument);

            CartController.AddToCart(userId, cardId);
            ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Card Added');", true);
        }
    }
}