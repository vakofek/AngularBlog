using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularBlog.Models.BlogComment
{
    public class BlogComment : BlogCommentCreate
    {
        public string UserName { get; set; }
        public int ApplicationUserId { get; set; }
        public DateTime PublisheDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
