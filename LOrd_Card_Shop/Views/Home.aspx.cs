using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOrd_Card_Shop.Views
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowWelcomeMessage();
            }
        }

        private void ShowWelcomeMessage()
        {
            if (Session["user"] != null || Request.Cookies["user_cookies"] != null)
            {
                string username = Session["user"].ToString();
                welcome.Text = $"<div class='username'  >Welcome, {username}!</div>";
            }
        }
    }
}