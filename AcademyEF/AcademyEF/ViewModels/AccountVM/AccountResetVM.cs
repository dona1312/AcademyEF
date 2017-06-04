using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AcademyEF.ViewModels.AccountVM
{
    public class AccountResetVM
    {
        [Required(ErrorMessage = "Required field")]
        [StringLength(30, ErrorMessage = "Max 30 symbols")]
        [EmailAddress]
        public string Email { get; set; }
    }
}