﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularBlog.Models.Account
{
    public class ApplicationUser
    {
        public int ApplicationUserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public int MyProperty { get; set; }
        public string Email { get; set; }

        public string Token { get; set; }

    }
}
