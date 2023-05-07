using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Contracts;
using TatBlog.Core.DTO;

namespace TatBlog.Services.Blogs
{
    public interface IUserServiceRepository
    {
        Task<string> Authencate(LoginRequest request);

        Task<bool> Register(RegisterRequest request);

        Task<IList<AppUserItem>> GeUsersAsync(
           CancellationToken cancellationToken = default);

        Task<IPagedList<AppUserItem>> GetPagedUsersAsync(
           int pageSize,
           int pageNumber,
           CancellationToken cancellationToken = default);
    }
}
