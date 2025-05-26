using LOrd_Card_Shop.Controller;
using LOrd_Card_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOrd_Card_Shop.Views
{
    public partial class ProfilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Users data = UserController.getUser(Session);
            uNameTb.Text = data.UserName;
            emailTb.Text = data.UserEmail;
            Calendar1.SelectedDate = data.UserDOB;
            genderRBList.SelectedValue = data.UserGender;
            pwTb.Attributes["placeholder"] = "Optional";
        }

        protected async void updateBtn_Click(object sender, EventArgs e)
        {
            string username = uNameTb.Text;
            string password = pwTb.Text;
            string newPass = newPwTb.Text;
            string confirmpass = confirmNewTb.Text;
            string gender = genderRBList.SelectedValue;
            string email = emailTb.Text;
            DateTime DOB = Calendar1.SelectedDate;

            await UserController.updateUserData(username, password, newPass, confirmpass, gender, email, DOB, errLbl, Convert.ToInt32(Session["UserID"]));

        }
    }
}