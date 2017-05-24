using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AcademyEF.Models
{   
    public class User:BaseEntity
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsAdmin { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}