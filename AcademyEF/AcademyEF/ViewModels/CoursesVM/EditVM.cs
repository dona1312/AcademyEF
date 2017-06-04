using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AcademyEF.ViewModels.CoursesVM
{
    public class EditVM
    {
        [Required]
        [StringLength(100, ErrorMessage = "Up to 100 symbols allowed")]
        public string Name { get; set; }

        [StringLength(100, ErrorMessage = "Up to 100 symbols allowed")]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageUpload { get; set; }

        public int ID { get; set; }
    }
}
