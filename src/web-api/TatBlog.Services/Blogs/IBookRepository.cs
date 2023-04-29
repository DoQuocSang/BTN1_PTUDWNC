using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Contracts;
using TatBlog.Core.DTO;
using TatBlog.Core.Entities;
using TatBlog.Services.Extensions;

namespace TatBlog.Services.Blogs
{
    public interface IBookRepository
    {
        Task<IPagedList<T>> GetPagedBooksConvertBookItemAsync<T>(
           BookQuery condition,
           IPagingParams pagingParams,
           Func<IQueryable<Book>, IQueryable<T>> mapper);
    }
}
