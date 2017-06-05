using AcademyEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademyEF.Repositories
{
    public class UsersRepository : BaseRepository<User>
    {
        public UsersRepository()
        {

        }

        public UsersRepository(UnitOfWork unit):base(unit)
        {

        }
    }
}