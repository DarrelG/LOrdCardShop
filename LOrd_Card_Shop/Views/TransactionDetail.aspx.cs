using LOrd_Card_Shop.Handler;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LOrd_Card_Shop.Models;
using TransactionDetails = LOrd_Card_Shop.Models.TransactionDetail;

namespace LOrd_Card_Shop.Views
{
    public partial class TransactionDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);
            List<TransactionDetailResult> data = TransactionHandler.GetTransactionDetails(id);
            GridView1.DataSource = data;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/TransactionList.aspx");
        }
    }
}