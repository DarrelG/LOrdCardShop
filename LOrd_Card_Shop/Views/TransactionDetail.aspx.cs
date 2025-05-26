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
            Response.Redirect("~/Views/TransactionHistory.aspx");
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (ViewState["GrandTotal"] == null)
                ViewState["GrandTotal"] = 0m;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                decimal rowTotal = 0;
                var rawValue = DataBinder.Eval(e.Row.DataItem, "Total");

                if (rawValue != null)
                    decimal.TryParse(rawValue.ToString(), out rowTotal);

                ViewState["GrandTotal"] = (decimal)ViewState["GrandTotal"] + rowTotal;
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells.Clear();

                TableCell labelCell = new TableCell
                {
                    ColumnSpan = 5,
                    Text = "Subtotal",
                    HorizontalAlign = HorizontalAlign.Right,
                    Font = { Bold = true }
                };
                e.Row.Cells.Add(labelCell);

                TableCell valueCell = new TableCell
                {
                    Text = ((decimal)ViewState["GrandTotal"]).ToString("C"),
                    Font = { Bold = true },
                    HorizontalAlign = HorizontalAlign.Right
                };
                e.Row.Cells.Add(valueCell);
            }
        }
    }
}