using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOrd_Card_Shop.Handler
{
    public class UserHandler
    {
        public async static Task createNewUser(string username, string password, string email, string gender, DateTime DOB)
        {
            if (UserRepository.getUserByName(username) != null)
            {
                throw new Exception("Username already exists");
            }else if(UserRepository.getUserByEmail(email) != null)
            {
                throw new Exception("Email already exists");
            }
            else
            {
                await UserRepository.createNewUser(username, password, email, gender, DOB);
            }
        }

        public static void loginUser(string username, string password, Label errLbl, CheckBox rememberMe, HttpResponse Response, HttpSessionState Session)
        {
            if (UserRepository.loginValidation(username, password) == false)
            {
                throw new Exception("Username or Password invalid!");
            }
            else
            {
                Users dbUserName = UserRepository.getUserByName(username);
                Session["User"] = dbUserName.UserName;
                Session["UserID"] = dbUserName.UserID;
                if (rememberMe.Checked)
                {
                    HttpCookie userCookie = new HttpCookie("user_cookie", dbUserName.UserName);
                    userCookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Set(userCookie);
                    Response.Cookies.Add(userCookie);
                }
            }
        }

        public static Users getUser(int id)
        {
            return UserRepository.getUserById(id);
        }

        public static async Task updateUserData(
            string username,
            string password,
            string newPass,
            string gender,
            string email,
            DateTime DOB,
            int id)
        {
            if (UserRepository.getUserByName(username) != null && UserRepository.getUserById(id).UserName != username)
            {
                throw new Exception("Username already exists");
            }

            if (UserRepository.getUserByEmail(email).UserEmail != null && UserRepository.getUserByEmail(email).UserEmail != UserRepository.getUserById(id).UserEmail)
            {
                throw new Exception("Email already exists");
            }

            if (!string.Equals(gender, "Male") && !string.Equals(gender, "Female"))
            {
                throw new Exception("Please choose valid gender");
            }

            if (!string.Equals(password, ""))
            {
                if (UserRepository.getUserByName(username).UserPassword != password)
                {
                    throw new Exception("Old Password invalid");
                }

                if (UserRepository.getUserByName(username).UserPassword == newPass)
                {
                    throw new Exception("New password cant be same as old one");
                }

                await UserRepository.updateUser(username, password, email, gender, DOB);
            }
            else
            {
                await UserRepository.updateUserWoPass(username, email, gender, DOB);
            } 
        }
    }
}