using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularBlog.Models.Account
{
    public class ApplicationUserCreate : ApplicationUserLogin
    {
        [MinLength(5, ErrorMessage = "Must be  10-30 chars")]
        [MaxLength(20, ErrorMessage = "Must be 10-30 chars")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [MaxLength(5, ErrorMessage = "Can be at most 30 chars")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

    }
}
