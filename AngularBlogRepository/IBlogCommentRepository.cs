﻿using AngularBlog.Models.BlogComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularBlogRepository
{
    public interface IBlogCommentRepository
    {
        public Task<BlogComment> UpsertAsync(BlogCommentCreate blogCommentCreate, int applicationUserId);
        public Task<List<BlogComment>> GetAllAsync( int blogCommentId);
        public Task<BlogComment> GetAsync(int blogCommentId);
        public Task<int> DeleteAsync(int blogCommentId);


    }
}
