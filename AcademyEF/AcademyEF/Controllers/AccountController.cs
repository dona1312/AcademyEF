using System;
using System.Web.Mvc;
using AcademyEF.Models;
using AcademyEF.Filters;
using AcademyEF.ViewModels.AccountVM;
using AcademyEF.Services;
using System.Linq;

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

        [AuthorizationFilter]
        public ActionResult Verify(int userID)
        {
            AccountVerifyVM model = new AccountVerifyVM();
            if (userID < int.MinValue || userID > int.MaxValue)
            {
                ModelState.AddModelError("", "There is no such user!");
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizationFilter]
        public ActionResult Verify(int userID, string key)
        {
            AccountVerifyVM model = new AccountVerifyVM();
            TryUpdateModel(model);
            UsersService userService = new UsersService();

            User user = userService.GetByID(userID);
            if (user == null)
            {
                ModelState.AddModelError("", "There is no such user!");
            }
            else
            {
                Guid guidValue = Guid.NewGuid();
                if (!Guid.TryParse(key, out guidValue))
                {
                    ModelState.AddModelError("", "Inavlid key! Please check your e-mail for correct activation link!");
                }
                if (user.Password == key)
                {
                    user.Password = model.Password;
                    userService.Save(user);
                }
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return this.RedirectToAction("Login");
        }
        public ActionResult Reset(string str)
        {
            AccountResetVM model = new AccountResetVM();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizationFilter]
        public ActionResult Reset()
        {
            AccountResetVM model = new AccountResetVM();
            TryUpdateModel(model);

            UsersService usersService = new UsersService();
            User user = usersService.GetAll(u => u.Email == model.Email).FirstOrDefault();
            user.Password = Guid.NewGuid().ToString();

            usersService.Save(user);

            EmailService.SendEmail(user, ControllerContext);
            
            return View(model);
        }
        public ActionResult Logout()
        {
            AuthenticationService.Logout();
            return this.RedirectToAction("Login");
        }
    }
}
