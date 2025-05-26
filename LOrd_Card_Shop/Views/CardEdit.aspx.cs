using LOrd_Card_Shop.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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


            CardHandler.editCardHandler(id, name, price, description, type, foilValue, Message, Response);
        }
    }
}