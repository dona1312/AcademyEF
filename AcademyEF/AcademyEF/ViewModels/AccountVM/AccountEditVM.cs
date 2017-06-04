using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AcademyEF.ViewModels.AccountVM
{
    public class AccountEditVM
    {
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Required field")]
        [StringLength(20, ErrorMessage = "Max 20 symbols")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Required field")]
        [StringLength(20, ErrorMessage = "Max 20 symbols")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required field")]
        [StringLength(20, ErrorMessage = "Max 20 symbols")]
        public string Username { get; set; }

        
        public string Password { get; set; }

        [Required(ErrorMessage = "Required field")]
        [StringLength(30, ErrorMessage = "Max 20 symbols")]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}