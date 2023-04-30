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

        Task<IPagedList<BookItem>> GetRandomBooksAsync(
            int numBooks,
            int pageSize = 30,
            int pageNumber = 1,
            CancellationToken cancellationToken = default);

        Task<Book> GetCachedBookByIdAsync(int bookId);

        Task<Book> GetBookByIdAsync(
          int bookId, bool includeDetails = false,
          CancellationToken cancellationToken = default);
    }
}
