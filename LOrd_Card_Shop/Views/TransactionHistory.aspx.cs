using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LOrd_Card_Shop.Controller;

namespace LOrd_Card_Shop.Views
{
    public partial class TransactionHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<TransactionHeader> list = TransactionController.GetTransactionHistory(Session, Response);

            GridView1.DataSource = list;
            GridView1.DataBind();
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string id = GridView1.DataKeys[e.NewEditIndex].Value.ToString();
            Response.Redirect("~/Views/TransactionDetail.aspx?id=" + id);
        }    
    }
}