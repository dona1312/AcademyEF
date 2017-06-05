using AcademyEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademyEF.Repositories
{
    public class CoursesRepository : BaseRepository<Course>
    {
        public CoursesRepository()
        {

        }

        public CoursesRepository(UnitOfWork unit):base(unit)
        {

        }
    }
}