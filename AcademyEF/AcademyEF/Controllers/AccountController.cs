using System;
using System.Web.Mvc;
using AcademyEF.Models;
using AcademyEF.Filters;
using AcademyEF.ViewModels;
using AcademyEF.Services;

namespace AcademyEF.Controllers
{
    public class AccountController : Controller
    {
        [AuthorizationFilter]
        public ActionResult Register(string str)
        {
            AccountEditVM model = new AccountEditVM();
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizationFilter]
        public ActionResult Register()
        {
            AccountEditVM model = new AccountEditVM();
            TryUpdateModel(model);

            User user = new User();
            UsersService userService = new UsersService();

            if (userService.CheckUsernameOrMail(model) != null)
            {
                ModelState.AddModelError("", "Username or email already exists!");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            user.ID = model.ID;
            user.FirstName = model.LastName;
            user.LastName = model.LastName;
            user.Username = model.Username;
            user.Email = model.Email;

            user.Password = Guid.NewGuid().ToString();
            userService.Save(user);
            EmailService.SendEmail(user, ControllerContext);

            return this.RedirectToAction("Login");
        }

        [AuthorizationFilter]
        // GET: Account
        public ActionResult Login(string RedirectUrl)
        {
            AccountLoginVM model = new AccountLoginVM();
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizationFilter]
        public ActionResult Login()
        {
            AccountLoginVM model = new AccountLoginVM();
            TryUpdateModel(model);

            AuthenticationService.Authenticate(model.Username, model.Password);

            if (AuthenticationService.LoggedUser != null)
            {
                return RedirectToAction("List","Courses");
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View(model);
            }
        }
    }
}
