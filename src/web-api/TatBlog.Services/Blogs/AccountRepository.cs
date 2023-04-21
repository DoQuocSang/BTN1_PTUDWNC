using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.DTO;
using TatBlog.Core.Entities;
using TatBlog.Data.Contexts;

namespace TatBlog.Services.Blogs
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BlogDbContext _context;
        private readonly IMemoryCache _memoryCache;

        public AccountRepository(BlogDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }

        // Lấy Thông Tin Account có Type là False (False là người dùng)
        public async Task<IQueryable<AccountItem>> GetAccountsAsync()
        {
            return await Task.FromResult(_context.Accounts
                .Where(a => a.Type == false)
                .Select(a => new AccountItem
                {
                    Id = a.Id,
                    NameAccount = a.NameAccount,
                    EmailAccount = a.EmailAccount,
                    Pass = a.Pass,
                    Type = a.Type
                }));
        }

        
    }
}
