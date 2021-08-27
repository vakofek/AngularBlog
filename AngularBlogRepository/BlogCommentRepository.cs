﻿using AngularBlog.Models.BlogComment;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularBlogRepository
{
    class BlogCommentRepository : IBlogCommentRepository
    {
        private readonly IConfiguration _config;
        public BlogCommentRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<int> DeleteAsync(int blogCommentId)
        {
            int affectedRows = 0;

            using (var connection = new SqlConnection(_config.GetConnectionString("DefualtConnection")))
            {
                await connection.OpenAsync();

                affectedRows = await connection.ExecuteAsync("BlogComment_Delete", new { BlogCommentId = blogCommentId },
                commandType: CommandType.StoredProcedure);
            }

            return affectedRows;
        }

        public async Task<List<BlogComment>> GetAllAsync(int blogCommentId)
        {
            IEnumerable<BlogComment> blogComment;

            using (var connection = new SqlConnection(_config.GetConnectionString("DefualtConnection")))
            {
                await connection.OpenAsync();

                blogComment = (IEnumerable<BlogComment>)await connection.QueryAsync("BlogComment_GetAll", 
                    new { BlogId = blogCommentId },
                commandType: CommandType.StoredProcedure);

            }
            return blogComment.ToList();
        }

        public async Task<BlogComment> GetAsync(int blogCommentId)
        {
            BlogComment blogComment;

            using (var connection = new SqlConnection(_config.GetConnectionString("DefualtConnection")))
            {
                await connection.OpenAsync();

                blogComment = await connection.QueryFirstOrDefaultAsync("BlogComment_Get",
                    new { BlogCommentId = blogCommentId },
                commandType: CommandType.StoredProcedure);

            }
            return blogComment;
        }

        public async Task<BlogComment> UpsertAsync(BlogCommentCreate blogCommentCreate, int applicationUserId)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("BlogCommentId", typeof(int));
            dataTable.Columns.Add("ParentBlogCommentId", typeof(int));
            dataTable.Columns.Add("BlogId", typeof(int));
            dataTable.Columns.Add("Content", typeof(string));

            dataTable.Rows.Add(
                blogCommentCreate.BlogCommentId, blogCommentCreate.ParentBlogCommentId, blogCommentCreate.Content, blogCommentCreate.BlogId);

            int? newBlogCommentId;

            using (var connection = new SqlConnection(_config.GetConnectionString("DefualtConnection")))
            {
                await connection.OpenAsync();

                newBlogCommentId = await connection.ExecuteScalarAsync<int?>("BlogComment_Upsert",
                    new { BlogComment = dataTable.AsTableValuedParameter("dbo.BlogCommentType")},
                commandType: CommandType.StoredProcedure);
            }
            newBlogCommentId = newBlogCommentId ?? blogCommentCreate.BlogCommentId;

            return await GetAsync(newBlogCommentId.Value);
        }
    }
}
