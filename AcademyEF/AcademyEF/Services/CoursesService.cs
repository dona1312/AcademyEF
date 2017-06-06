using AcademyEF.Models;
using AcademyEF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademyEF.Services
{
    public class CoursesService : BaseService<Course>
    {
        public CoursesService()
        {

        }

        public CoursesService(UnitOfWork unit):base(unit)
        {

        }
        public List<Course> GetMyCourses(int userID)
        {
            return new CoursesRepository().GetMyCourses(userID);
        }
    }
}