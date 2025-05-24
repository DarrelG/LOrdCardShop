using LOrd_Card_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Factory
{
    public class UserFactory
    {
        public static Users createNewUser(string username, string password, string email, string gender, DateTime DOB)
        {
            Users user = new Users();
            user.UserName = username;
            user.UserPassword = password;
            user.UserEmail = email;
            user.UserGender = gender;
            user.UserDOB = DOB;
            user.UserRole = "customer";
            return user;
        }
    }
}