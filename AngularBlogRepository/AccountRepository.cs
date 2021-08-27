﻿using AngularBlog.Models.Account;
using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AngularBlogRepository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IConfiguration _config;
        public AccountRepository(IConfiguration config)
        {
            _config = config;
        }
        public async Task<IdentityResult> CreateAsync(ApplicationUserIdentity user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var dataTable = new DataTable();
            dataTable.Columns.Add("UserName", typeof(string));
            dataTable.Columns.Add("NormalizedUserName", typeof(string));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Columns.Add("NormalizedEmail", typeof(string));
            dataTable.Columns.Add("FullName", typeof(string));
            dataTable.Columns.Add("PasswordHash", typeof(string));

            dataTable.Rows.Add(
                user.UserName, user.NormalizedUserName, user.Email, user.NormalizedEmail, user.FullName, user.PasswordHash);

            using (var connection = new SqlConnection(_config.GetConnectionString("DefualtConnection")))
            {
                await connection.OpenAsync(cancellationToken);

                await connection.ExecuteAsync("Account_Insert",
                    new { Account = dataTable.AsTableValuedParameter("dbo.AccountType") },
                    commandType: CommandType.StoredProcedure);
            }

            return IdentityResult.Success;
        }

        public async Task<ApplicationUserIdentity> GetByUsernameAsync(string normalizedUsername, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ApplicationUserIdentity applicationUser;

            using (var connection = new SqlConnection(_config.GetConnectionString("DefualtConnection")))
            {
                await connection.OpenAsync(cancellationToken);

                applicationUser = await connection.QuerySingleOrDefaultAsync<ApplicationUserIdentity>(
                    "Account_GetByUserName", new { NormalizedUsername = normalizedUsername },
                    commandType: CommandType.StoredProcedure );
            }
            return applicationUser;
        }


    }
}
