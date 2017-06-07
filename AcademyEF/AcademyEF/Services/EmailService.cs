
using AcademyEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace AcademyEF.Services
{
    public static class EmailService
    {
        public static void SendEmail(User user, ControllerContext context)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("no-reply@management.com");
            mail.Subject = "Registration successfull";
            mail.To.Add(user.Email);
            mail.Body = "Hello " + user.FirstName + Environment.NewLine
                + "Thank you for registering. Confirm your registration by visiting the following link: "
                + Environment.NewLine
                + "http://taskmanager-14.apphb.com/Account/Verify?guid=" + user.Password;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            #region Private
            smtp.Credentials = new System.Net.NetworkCredential("testforhallmanager@gmail.com", "hallmanager");
            #endregion

            smtp.Send(mail);
        }
    }
}