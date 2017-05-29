using AcademyEF.Models;
using AcademyEF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademyEF.Services
{
    public class UsersService : BaseService<User>
    {
        public User CheckUsernameOrMail(AccountEditVM user)
        {
            UsersService userService = new UsersService();
            User userMail = userService.GetAll().FirstOrDefault((u => u.Email == user.Email || u.Username == user.Username.ToLower()));
            if (userMail != null)
            {
                return userMail;
            }
            else
                return null;
        }
    }
}