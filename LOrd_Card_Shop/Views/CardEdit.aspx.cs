using LOrd_Card_Shop.Handler;
using System;
using LOrd_Card_Shop.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LOrd_Card_Shop.Controller;

namespace LOrd_Card_Shop.Views
{
    public partial class CardEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);
            string name = NameTb.Text;
            decimal price = decimal.Parse(PriceTb.Text);
            string description = DescTb.Text;
            string type = TypeTb.Text;
            string foilValue = FoilDd.SelectedValue;

            CardController.editCardController(id, name, price, description, type, foilValue, Message, Response);
        }
    }
}