using GardenGroupModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using GardenGroupDAO;

namespace GardenGroupLogic
{
    public class UserService
    {
        UserDAO user_DAO = new UserDAO();

        public List<User> GetAll()
        {
            return user_DAO.GetAll();
        }

        public User GetById(string id)
        {
            return user_DAO.FindById(id);
        }

        public void SendEmail(string email)
        {
            string pass = GetNewPassword();
            user_DAO.SendEmail(email, pass);
            user_DAO.ResetPassword(email, pass);
        }

        public string GetNewPassword()
        {
            var validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = validChars[random.Next(validChars.Length)];
            }

            var finalString = new string(stringChars);
            return finalString;
        }
    }
}