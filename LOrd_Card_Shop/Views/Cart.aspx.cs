using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LOrd_Card_Shop.Controller;
using LOrd_Card_Shop.Handler;

namespace LOrd_Card_Shop.Views
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null || Request.Cookies["user_cookies"] != null)
                {
                    int userId = Convert.ToInt32(Session["UserID"]);
                    var cartItems = CartController.GetCartItems(userId);

                    if(cartItems.Count == 0)
                    {
                        Response.Redirect("OrderCard.aspx");
                    }

                    rptCartItems.DataSource = cartItems;
                    rptCartItems.DataBind();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            Response.Redirect("CheckOut.aspx");
        }
    }
}