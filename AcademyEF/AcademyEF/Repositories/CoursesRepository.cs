using AcademyEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademyEF.Repositories
{
    public class CoursesRepository : BaseRepository<Course>
    {
        public List<Course> GetMyCourses(int userID)
        {
            AcademyContext ac = new AcademyContext();
            var result = from c in ac.Courses.Where(cr => cr.Users.Any(u => u.ID == userID))
                             select c;

            return result.ToList();

        }
    }
}