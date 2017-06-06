using AcademyEF.Filters;
using AcademyEF.Models;
using AcademyEF.Services;
using AcademyEF.ViewModels.UsersVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcademyEF.Controllers
{
    public class UsersController : Controller
    {
        public UsersService usersService { get; set; }
        public UsersController()
        {
            usersService = new UsersService();
        }

        [AuthenticationFilter]
        [AuthorizationFilter]
        public ActionResult List()
        {
            List<User> users = usersService.GetAll();
            UserListVM userListVM = new UserListVM();
            userListVM.Users = users;
            return View(userListVM);
        }


        public ActionResult Details(int id)
        {
            return View();
        }

        [AuthenticationFilter]
        [AuthorizationFilter]
        public ActionResult Edit(int? id)
        {
            EditVM model = new EditVM();
            User user;
            if (id.HasValue)
            {
                user = usersService.GetByID(id.Value);
                if (user == null)
                {
                    return RedirectToAction("List");
                }
            }
            else
            {
                user = new User();
            }
            model.Username = user.Username;
            model.Password = user.Password;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.Email = user.Email;
            model.IsAdmin = user.IsAdmin;
            model.ID = user.ID;
            return View(model);
        }

        [AuthenticationFilter]
        [AuthorizationFilter]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            EditVM model = new EditVM();
            TryUpdateModel(model);
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            User user;
            if (model.ID != 0)
            {
                user = usersService.GetByID(model.ID);
            }
            else
            {
                user = new User();
            }
            if (user == null)
            {
                return RedirectToAction("List");
            }
            user.Username = model.Username;
            user.Password = model.Password;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.IsAdmin = model.IsAdmin;
            user.ID = model.ID;
            usersService.Save(user);
            return RedirectToAction("List");            
        }

        [AuthenticationFilter]
        [AuthorizationFilter]
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                User user = usersService.GetByID(id.Value);
                usersService.Delete(id.Value);
            }
            return RedirectToAction("List");
        }
    }
}
