using AcademyEF.Models;
using AcademyEF.Services;
using AcademyEF.ViewModels.CoursesVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using AcademyEF.Filters;
using AcademyEF.Repositories;

namespace AcademyEF.Controllers
{
    public class CoursesController : Controller
    {
        public CoursesService coursesService { get; set; }

        public CoursesController()
        {
            coursesService = new CoursesService();
        }
        
        public ActionResult List()
        {
            List<Course> courses = coursesService.GetAll();
            CourseListVM courseListVM = new CourseListVM();
            courseListVM.Courses = courses;

            return View(courseListVM);
        }

        [AuthenticationFilter]
        [AuthorizationFilter]
        public ActionResult MyCourses()
        {
            List<Course> courses = coursesService.GetMyCourses(AuthenticationService.LoggedUser.ID);
            CourseListVM courseListVM = new CourseListVM();
            courseListVM.Courses = courses;

            return View("List",courseListVM);
        } 

        [AuthenticationFilter]
        [AuthorizationFilter]
        public ActionResult Details(int id)
        {
            return View();
        }

        [AuthenticationFilter]
        [AuthorizationFilter]
        public ActionResult Edit(int? id)
        {
            EditVM model = new EditVM();
            Course course;
            if (id.HasValue)
            {
                course = coursesService.GetByID(id.Value);
                if (course == null)
                {
                    return RedirectToAction("List");
                }
            }
            else
            {
                course = new Course();
            }
            model.Name = course.Name;
            model.Description = course.Description;
            model.ImagePath = course.ImagePath;
            model.ID = course.ID;
            return View(model);
        }

        [AuthenticationFilter]
        [AuthorizationFilter]
        [HttpPost]
        public ActionResult Edit()
        {
            EditVM model = new EditVM();
            TryUpdateModel(model);
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Course course;
            if (model.ID != 0)
            {
                course = coursesService.GetByID(model.ID);
            }
            else
            {
                course = new Course();
            }

            //if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
            //{
            //    var file = Path.GetExtension(model.ImageUpload.FileName);
            //    if (String.IsNullOrEmpty(file) || !file.Equals(".jpg", StringComparison.OrdinalIgnoreCase))
            //    {
            //        ModelState.AddModelError("", "Image format not accepted");
            //    }
            //    else
            //    {
            //        if (!String.IsNullOrEmpty(model.ImagePath))
            //        {
            //            var imagePathOld = Path.Combine(Server.MapPath("/Uploads/"), model.ImagePath);
            //            System.IO.File.Delete(imagePathOld);
            //        }
            //        var uploadDir = "/Uploads/";
            //        var imagePath = Path.Combine(Server.MapPath(uploadDir), model.ImageUpload.FileName);
            //        model.ImagePath = model.ImageUpload.FileName;
            //        model.ImageUpload.SaveAs(imagePath);
            //    }
            //}

            if (course == null)
            {
                return RedirectToAction("List");
            }
            course.ID = model.ID;
            course.Name = model.Name;
            course.Description = model.Description;
            course.ImagePath = model.ImagePath;
            coursesService.Save(course);
            return RedirectToAction("List");
        }

        [AuthenticationFilter]
        [AuthorizationFilter]
        public ActionResult Delete(int? id)
        {

            if (id.HasValue)
            {
                Course course = coursesService.GetByID(id.Value);
                //var imagePath = Path.Combine(Server.MapPath("/Uploads/"), course.ImagePath);
                //System.IO.File.Delete(imagePath);
                coursesService.Delete(id.Value);
            }
            return RedirectToAction("List");
        }

        [AuthenticationFilter]
        public ActionResult Assign(int? id)
        {
            if (id.HasValue)
            {
                UnitOfWork unit = new UnitOfWork();
                coursesService = new CoursesService(unit);
                UsersService userService = new UsersService(unit);

                var user = userService.GetByID(AuthenticationService.LoggedUser.ID);
                Course course = coursesService.GetByID(id.Value);

                course.Users.Add(user);

                coursesService.Save(course);
            }

            return RedirectToAction("List");
        }
    }
}
