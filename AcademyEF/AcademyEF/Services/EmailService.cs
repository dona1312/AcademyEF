
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
            string parameters = "userID=" + user.ID + "&key=" + user.Password;

            mail.From = new MailAddress("info@beITacademy.com");
            mail.Subject = "Registration successfull";
            mail.To.Add(user.Email);
            mail.Body = "Hello " + user.FirstName + Environment.NewLine
                + "Confirm your registration by visiting the following link: "
                + Environment.NewLine
                + "http://academyef.apphb.com/Account/Verify?" + parameters;

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