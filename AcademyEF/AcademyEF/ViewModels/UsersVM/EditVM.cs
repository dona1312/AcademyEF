using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEF.ViewModels.UsersVM
{
    public class EditVM
    {
        [Required]
        [StringLength(50, ErrorMessage = "Up to 50 symbols allowed")]
        public string Username { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Up to 20 symbols allowed")]
        public string Password { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Up to 100 symbols allowed")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Up to 100 symbols allowed")]
        public string LastName { get; set; }

        public bool IsAdmin { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Up to 100 symbols allowed")]
        [EmailAddress]
        public string Email { get; set; }

        public int ID { get; set; }
    }
}
