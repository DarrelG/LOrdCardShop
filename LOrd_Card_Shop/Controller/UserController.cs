using LOrd_Card_Shop.Handler;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace LOrd_Card_Shop.Controller
{
    public class UserController
    {
        public static async Task registerUser(
            string username,
            string password,
            string confirmPass,
            string gender,
            string email,
            DateTime DOB,
            Label errLbl,
            HttpResponse Response,
            HttpSessionState Session)
        {
            try
            {
                username = Regex.IsMatch(username, @"^[A-Za-z]{5,30}$") ? username : throw new Exception("Username Invalid");
                email = email.Contains("@") ? email : throw new Exception("Email must contain '@'");
                password = Regex.IsMatch(password, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$") ? password = Regex.IsMatch(password, confirmPass) ? password : throw new Exception("Confirm password must be same as password") : throw new Exception("Password must at least 8 length and contain Alphabeth and Number Combination");
                gender = gender == null || (gender != "Male" && gender != "Female") ? throw new Exception("Please choose valid gender") : gender;
                DOB = DOB == null ? throw new Exception("Please fill your Birth of Date") : DOB;

                
                await UserHandler.createNewUser(username, password, email, gender, DOB);

                Response.Redirect("Login.aspx", false);
            }
            catch (Exception ex)
            {
                errLbl.Visible = true;
                errLbl.Text = (ex.Message);
            }
        }

        public static void loginUser(string username,
            string password,
            Label errLbl,
            CheckBox rememberMe,
            HttpResponse Response,
            HttpSessionState Session)
        {
            try
            {
                if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
                {
                    throw new Exception("Username and Password must be filled!");
                }
                else
                {
                    UserHandler.loginUser(username, password, errLbl, rememberMe, Response, Session);
                }

                Response.Redirect("Home.aspx");
            }
            catch(Exception ex)
            {
                errLbl.Visible = true;
                errLbl.Text = ex.Message;
            }
        }

        public static Users getUser(HttpSessionState Session)
        {
            int userId = Convert.ToInt32(Session["UserID"]);
            return UserHandler.getUser(userId);
        }

        public async static Task updateUserData(
            string username,
            string password,
            string newPass,
            string confirmPass,
            string gender,
            string email,
            DateTime DOB,
            Label err,
            int Id,
            HttpResponse response)
        {
            try
            {
                if(!string.Equals(password, ""))
                {
                    password = Regex.IsMatch(password, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$") ? password : throw new Exception("Old Password not valid");
                    newPass = Regex.IsMatch(password, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$") ? newPass : throw new Exception("New Password must at least 8 length");
                    confirmPass = Regex.IsMatch(newPass, confirmPass) ? newPass : throw new Exception("Confirm Password is invalid");
                }

                username = Regex.IsMatch(username, @"^[A-Za-z]{5,30}$") ? username : throw new Exception("Username Invalid");
                email = email.Contains("@") ? email : throw new Exception("Email must contain '@'");
                gender = gender == null || (gender != "Male" && gender != "Female") ? throw new Exception("Please choose valid gender") : gender;
                DOB = DOB == null ? throw new Exception("Please fill your Birth of Date") : DOB;

                await UserHandler.updateUserData(username, password, newPass, gender, email, DOB, Id);

                response.Redirect("Home.aspx", false);
            } catch (Exception ex)
            {
                err.Visible = true;
                err.Text = ex.Message;
            }
        }
    }
}