using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LOrd_Card_Shop.Controller;
using LOrd_Card_Shop.Models;

namespace LOrd_Card_Shop.Views
{
    public partial class CheckOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null || Request.Cookies["user_cookies"] != null)
                {
                    int userId = Convert.ToInt32(Session["UserID"]);
                    var cartItems = CartController.GetCartItems(userId);
                    decimal total = CartController.CalculateTotal(cartItems);

                    rptCheckoutItems.DataSource = cartItems;
                    rptCheckoutItems.DataBind();
                    lblTotal.Text = total.ToString("C");
                }
            }
        }
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["UserID"]);
            bool success = CartController.Checkout(userId);

            if (success)
            {
                string script = "alert('Checkout successful!'); window.location='OrderCard.aspx';";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Checkout failed.');", true);
            }
        }
    }
}