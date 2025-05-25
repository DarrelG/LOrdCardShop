using LOrd_Card_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOrd_Card_Shop.Views
{
    public partial class TransactionHistory : System.Web.UI.Page
    {
        Database1Entities db = new Database1Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<TransactionHeader> list = db.TransactionHeader.ToList();

            GridView1.DataSource = list;
            GridView1.DataBind();
        }
        
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            String id = GridView1.DataKeys[e.NewEditIndex].Value.ToString();
            Response.Redirect("~/Views/TransactionDetail.aspx?id=" + id);
        }
    }
}