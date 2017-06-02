
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
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

                string parameters = "userID=" + user.ID + "&key=" + user.Password;
                var port = HttpContext.Current.Request.Url.Port;
                var path = HttpContext.Current.Request.Url.Host + ":" + port + "/Account/Verify?" + parameters;

                mail.From = new MailAddress("testforhallmanager@gmail.com");
                mail.To.Add(user.Email);
                mail.Subject = "Verify Registration";
                mail.Body = "Click this link to verify your account: " + Environment.NewLine + "http://" + path;
                
                smtpServer.Port = 587;
                smtpServer.Credentials = new System.Net.NetworkCredential("testforhallmanager@gmail.com", "hallmanager");
                smtpServer.EnableSsl = true;

                smtpServer.Send(mail);
            }
            catch (Exception ex)
            {

            }
        }
    }
}