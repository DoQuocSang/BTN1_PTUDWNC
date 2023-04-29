using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Contracts;
using TatBlog.Core.DTO;
using TatBlog.Core.Entities;
using TatBlog.Data.Contexts;
using TatBlog.Services.Extensions;
using static System.Net.Mime.MediaTypeNames;
using SlugGenerator;
using Microsoft.Extensions.Caching.Memory;

namespace TatBlog.Services.Blogs
{
    public class BookRepository : IBookRepository
    {
        private readonly BlogDbContext _context;
        private readonly IMemoryCache _memoryCache;

        public BookRepository(BlogDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }

        private IQueryable<Book> FilterBooks(BookQuery condition)
        {
            IQueryable<Book> books = _context.Set<Book>()
                .Include(x => x.Category)
                .Include(x => x.Author);

            if (condition.CategoryId > 0)
            {
                books = books.Where(x => x.CategoryId == condition.CategoryId);
            }

            if (!string.IsNullOrWhiteSpace(condition.CategorySlug))
            {
                books = books.Where(x => x.Category.UrlSlug == condition.CategorySlug);
            }

            if (condition.AuthorId > 0)
            {
                books = books.Where(x => x.AuthorId == condition.AuthorId);
            }

            if (!string.IsNullOrWhiteSpace(condition.AuthorSlug))
            {
                books = books.Where(x => x.Author.UrlSlug == condition.AuthorSlug);
            }

            if (!string.IsNullOrWhiteSpace(condition.BookSlug))
            {
                books = books.Where(x => x.UrlSlug == condition.BookSlug);
            }

            if (!string.IsNullOrWhiteSpace(condition.Keyword))
            {
                books = books.Where(x => x.Title.Contains(condition.Keyword) ||
                                         x.ShortDescription.Contains(condition.Keyword) ||
                                         x.Description.Contains(condition.Keyword) ||
                                         x.Category.Name.Contains(condition.Keyword));
            }

            if (condition.Year > 0)
            {
                books = books.Where(x => x.ReleasedDate.Year == condition.Year);
            }

            if (condition.Month > 0)
            {
                books = books.Where(x => x.ReleasedDate.Month == condition.Month);
            }

            if (!string.IsNullOrWhiteSpace(condition.TitleSlug))
            {
                books = books.Where(x => x.UrlSlug == condition.TitleSlug);
            }

            return books;
        }

        public async Task<IPagedList<T>> GetPagedBooksConvertBookItemAsync<T>(
          BookQuery condition,
          IPagingParams pagingParams,
          Func<IQueryable<Book>, IQueryable<T>> mapper)
        {
            var books = FilterBooks(condition);
            var projectedBooks = mapper(books);
            return await projectedBooks.ToPagedListAsync(
                pagingParams.PageNumber, pagingParams.PageSize,
                nameof(Book.ReleasedDate), "DESC");
        }

    }
}
