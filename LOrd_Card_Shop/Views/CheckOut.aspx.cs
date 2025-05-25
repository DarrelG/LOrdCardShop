using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LOrd_Card_Shop.Handler;

namespace LOrd_Card_Shop.Views
{
    public partial class CheckOut : System.Web.UI.Page
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
                    decimal total = cartHandler.CalculateTotal(cartItems);

                    rptCheckoutItems.DataSource = cartItems;
                    rptCheckoutItems.DataBind();
                    lblTotal.Text = total.ToString("C");
                }
            }
        }
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["UserID"]);
            bool success = cartHandler.Checkout(userId);

            if (success)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Checkout successful!');", true);
                Response.Redirect("OrderCard.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Checkout failed.');", true);
            }
        }
    }
}