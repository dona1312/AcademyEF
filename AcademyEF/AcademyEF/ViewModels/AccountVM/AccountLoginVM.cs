using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcademyEF.ViewModels
{
    public class AccountLoginVM
    {
        [Required(ErrorMessage = "Required field")]
        [StringLength(20, ErrorMessage = "Max 20 symbols")]
        [AllowHtml]
        public string Username { get; set; }

        [Required(ErrorMessage = "Required field")]
        [AllowHtml]
        public string Password { get; set; }
    }
}