using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularBlog.Models.Account
{
    public class ApplicationUserLogin
    {
        [Required(ErrorMessage = "UserName is required")]
        [MinLength(5,ErrorMessage ="Must be 5-20 chars" )]
        [MaxLength(20,ErrorMessage = "Must be 5-20 chars")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(5, ErrorMessage = "Must be 10-50 chars")]
        [MaxLength(20, ErrorMessage = "Must be  10-50 chars")]
        public string Password { get; set; }

    }
}
