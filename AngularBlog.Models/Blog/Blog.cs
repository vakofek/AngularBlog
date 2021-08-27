using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularBlog.Models.Blog
{
    public class Blog : BlogCreate
    {
        public string  UserName { get; set; }
        public int ApplicationUserId { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
