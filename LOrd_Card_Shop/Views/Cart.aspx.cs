using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LOrd_Card_Shop.Handler;

namespace LOrd_Card_Shop.Views
{
    public partial class Cart : System.Web.UI.Page
    {
        CartHandler cartHandler = new CartHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null || Request.Cookies["user_cookies"] != null)
                {
                    int userId = Convert.ToInt32(Session["UserID"]);
                    var cartItems = cartHandler.GetCartItems(userId);

                    rptCartItems.DataSource = cartItems;
                    rptCartItems.DataBind();
                }
            }
        }
        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            Response.Redirect("CheckOut.aspx");
        }
    }
}