using AcademyEF.Models;
using AcademyEF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademyEF.Services
{
    public static class AuthenticationService
    {
        public static User LoggedUser { get; set; }

        public static void Authenticate(string username, string password)
        {
            UsersRepository userRepo = new UsersRepository();
            LoggedUser = userRepo.GetAll().FirstOrDefault(u => u.Username == username && u.Password == password);

        }

        public static void Logout()
        {
            LoggedUser = null;
        }
    }
}