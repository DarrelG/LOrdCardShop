using LOrd_Card_Shop.Factory;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Singleton;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LOrd_Card_Shop.Repository
{
    public class UserRepository : dbSingleton
    {
        public static Users getUserById(int user)
        {
            return UserDb.FirstOrDefault(x => x.UserID == user);
        }

        public static Users getUserByName(string name)
        {
            return UserDb.FirstOrDefault(x => x.UserName == name);
        }

        public static bool loginValidation(string name, string password)
        {
            InitAsync().Wait();
            if (UserDb.FirstOrDefault(x => x.UserName == name && x.UserPassword == password) != null)
            {
                return true;
            }
            return false;
        }

        public static async Task createNewUser(string username, string password, string email, string gender, DateTime DOB)
        {
            Users newUser = UserFactory.createNewUser(username, password, email, gender, DOB);
            await InitAsync();
            UserDb.Add(newUser);
            saveDbChange();
        }

        public static async Task updateUser(string username, string password, string email, string gender, DateTime DOB)
        {
            await InitAsync();
            Users user = UserDb.FirstOrDefault(x => x.UserName == username);
            if (user != null)
            {
                user.UserName = username;
                user.UserPassword = password;
                user.UserEmail = email;
                user.UserGender = gender;
                user.UserDOB = DOB;
                UserDb.AddOrUpdate(user);
                saveDbChange();
            }
        }

        public static Users getUserByEmail(string email)
        {
            return UserDb.FirstOrDefault(x => x.UserEmail == email);
        }
    }
}