using LOrd_Card_Shop.Handler;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;

namespace LOrd_Card_Shop.Views
{
    public partial class ManageCard : System.Web.UI.Page
    {
        //CardRepository repo = new CardRepository();

        public void refreshGrid()
        {
            List<Card> list = CardRepository.GetAllCards();
            CardsGV.DataSource = list;
            CardsGV.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"].ToString() != "Admin")
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                refreshGrid();
            }
            
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("CardAdd.aspx");
        }

        protected void CardsGV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void CardsGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = CardsGV.Rows[e.NewEditIndex];
            int id = int.Parse(row.Cells[0].Text);
            Response.Redirect($"CardEdit.aspx?id={id}");
            //refreshGrid();
        }

        protected void CardsGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = CardsGV.Rows[e.RowIndex];
            int id = int.Parse(row.Cells[0].Text);
            CardHandler.deleteCardHandler(id);  
            refreshGrid();
        }
    }
}