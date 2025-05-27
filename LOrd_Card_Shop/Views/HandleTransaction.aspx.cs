using LOrd_Card_Shop.Controller;
using LOrd_Card_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOrd_Card_Shop.Views
{
    public partial class HandleTransaction : System.Web.UI.Page
    {
        public void refreshGrid()
        {
            List<TransactionHeader> list = TransactionHeaderController.GetTransactionHeaders();
            TransHead.DataSource = list;
            TransHead.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                refreshGrid();
            }
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {

        }

        protected void TransHead_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = TransHead.Rows[e.NewEditIndex];
            int id = int.Parse(row.Cells[0].Text);
            TransactionHeaderController.editStatus(id);
            TransHead.EditIndex = -1;
            refreshGrid();
        }

        protected void TransHead_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}