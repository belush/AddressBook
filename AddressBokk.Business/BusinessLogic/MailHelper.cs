using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using AddressBook.Business.BusinessLogic;

namespace AddressBook.Business
{
    public class MailHelper : RepositoryHelper
    {
        public void PasswordRecovery(string emailAddress)
        {
            var emailAddressFrom = "addressbooksender@gmail.com";
            var emailPassword = "addressbook123";

            var users = r.GetUsers();

            var user = users.Single(u => u.UserEmail == emailAddress);

            var mailMessage = new MailMessage(emailAddressFrom, emailAddress);

            mailMessage.Subject = "AddressBook";
            mailMessage.Body = "Здравствуйте!<br> Ваш пароль:<br><b>" + user.UserPassword + "</b>";

            mailMessage.IsBodyHtml = true;
            var smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new NetworkCredential
            {
                UserName = emailAddressFrom,
                Password = emailPassword
            };
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
        }

        public string GetConfirmString()
        {
            var confirmString = Guid.NewGuid().ToString();
            //string confirmString = "123";
            return confirmString;
        }

        public void SendMail(string emailAddressTo, string userLogin, string confirmString)
        {
            var emailAddressFrom = "addressbooksender@gmail.com";
            var emailPassword = "addressbook123";

            var mailMessage = new MailMessage(emailAddressFrom, emailAddressTo);

            var reference = "http://localhost:59833/Home/Confirm?userLogin=" + userLogin + "&confirmString=" +
                            confirmString;

            mailMessage.Subject = "AddressBook";
            mailMessage.Body = "Здравствуйте, <b>" + userLogin + "</b>!<br/>"
                               + "Вы зарегистрировались в проекте <b>AddressBook</b>.<br/>" +
                               "Для завершения регистрации пройдите, пожалуйста, по <a href=" + "\"" + reference + "\"" +
                               ">ссылке</a>";


            mailMessage.IsBodyHtml = true;
            var smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new NetworkCredential
            {
                UserName = emailAddressFrom,
                Password = emailPassword
            };

            smtpClient.EnableSsl = true;

            smtpClient.Send(mailMessage);
        }
    }
}