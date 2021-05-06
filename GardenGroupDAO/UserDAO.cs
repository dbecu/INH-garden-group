using GardenGroupModel;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace GardenGroupDAO
{
    public class UserDAO : BaseDAO, IUserDAO
    {
        private const string TABLE_NAME = "Users";
        // (MVL)
        public void Create(User newUser)
        {
            User user = FindOneByEmail(newUser.Email);

            if (user != null)
            {
                throw new Exception("Email already in use!");
            }

            db.InsertDocument<User>(TABLE_NAME, newUser);
        }

        // (MVL)
        public void Delete(string id)
        {
            db.DeleteDocument<User>(TABLE_NAME, id);
        }

        // (MVL)
        public User FindOneByEmail(string email)
        {
            var filter = Builders<User>.Filter.Eq("Email", email);
            List<User> users = db.FindByQuery<User>(TABLE_NAME, filter);

            return users.Count > 0 ? users[0] : null;
        }

        // (MVL)
        public User FindById(string id)
        {
            return db.GetDocumentById<User>(TABLE_NAME, id);
        }

        // (MVL)
        public List<User> GetAll()
        {
            return db.GetDocuments<User>(TABLE_NAME);
        }

        // (MVL)
        public void Update(string id, User user)
        {
            db.UpdateDocument<User>(id, TABLE_NAME, user);
        }
        
        public void SendEmail(string email, string tempPass)
        {
            var fromAddress = new MailAddress("nosqltestmail@gmail.com", "Admin");
            var toAddress = new MailAddress(email);
            const string fromPassword = "random@123";
            const string subject = "Password reset request.";
            string body = $"Here is a temporary password for you to login: <b>" +
                tempPass+"</b>.\nMake sure to change your password afterwards.<br/>Ignore this email if you did " +
                "not request a reset of password or if you do not know the reason of this email.";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
            {
                smtp.Send(message);
            }
        }

        public void ResetPassword(string email, string pass)
        {
             db.UpdateDocumentbyEmail<User>(TABLE_NAME, email,pass);
        }
    }
}
