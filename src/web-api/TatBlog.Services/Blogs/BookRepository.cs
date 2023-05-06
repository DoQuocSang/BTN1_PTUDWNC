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

            if (!condition.HasRelated && !string.IsNullOrWhiteSpace(condition.CategorySlug))
            {
                books = books.Where(x => x.Category.UrlSlug == condition.CategorySlug);
            }

            if (condition.AuthorId > 0)
            {
                books = books.Where(x => x.AuthorId == condition.AuthorId);
            }

            if (!condition.HasRelated && !string.IsNullOrWhiteSpace(condition.AuthorSlug))
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

            if (condition.HasRelated && !string.IsNullOrWhiteSpace(condition.AuthorSlug) && !string.IsNullOrWhiteSpace(condition.CategorySlug))
            {
                books = books.Where(x => x.Author.UrlSlug == condition.AuthorSlug ||
                                         x.Category.UrlSlug == condition.CategorySlug);
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

            if (!string.IsNullOrWhiteSpace(pagingParams.SortColumn) && !string.IsNullOrWhiteSpace(pagingParams.SortOrder))
            {
                return await projectedBooks.ToPagedListAsync(
                pagingParams.PageNumber, pagingParams.PageSize,
                pagingParams.SortColumn, pagingParams.SortOrder);
            }

            return await projectedBooks.ToPagedListAsync(
                pagingParams.PageNumber, pagingParams.PageSize,
                nameof(Book.ReleasedDate), "DESC");
        }

        public async Task<IPagedList<T>> GetPagedBooksRelatedConvertBookItemAsync<T>(
          BookQuery condition,
          IPagingParams pagingParams,
          Func<IQueryable<Book>, IQueryable<T>> mapper)
        {
            var item = await GetBookBySlugAsync(condition.BookSlug);
            
            var BookQuery = new BookQuery()
            {
               AuthorSlug = item.Author.UrlSlug,
               CategorySlug = item.Category.UrlSlug,
               HasRelated = true
            };

            var books = FilterBooks(BookQuery);
            var projectedBooks = mapper(books);
            return await projectedBooks.ToPagedListAsync(
                pagingParams.PageNumber, pagingParams.PageSize,
                nameof(Book.ReleasedDate), "DESC");
        }

        public async Task<IPagedList<BookItem>> GetRandomBooksAsync(
        int numBooks,
        int pageSize = 30,
        int pageNumber = 1,
        CancellationToken cancellationToken = default)
        {
            return await _context.Set<Book>()
                .Include(x => x.Category)
                .Include(x => x.Author)
                .OrderBy(x => Guid.NewGuid())
                .Take(numBooks)
                .AsNoTracking()
                .Select(x => new BookItem()
                {
                    Id = x.Id,
                    Title = x.Title,
                    UrlSlug = x.UrlSlug,
                    Meta = x.Meta,
                    ShortDescription = x.ShortDescription,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    Supplier = x.Supplier,
                    PublishCompany = x.PublishCompany,
                    CoverForm = x.CoverForm,
                    StarNumber = x.StarNumber,
                    ReviewNumber = x.ReviewNumber,
                    Price = x.Price,
                    ReleasedDate = x.ReleasedDate,
                    CategoryName = x.Category.Name,
                    AuthorName = x.Author.FullName,
                    CategorySlug = x.Category.UrlSlug,
                    AuthorSlug = x.Author.UrlSlug
                })
                .ToPagedListAsync(pageNumber, pageSize,
                nameof(Book.ReleasedDate), "DESC",
                cancellationToken);

        }

        public async Task<Book> GetCachedBookByIdAsync(int bookId)
        {
            return await _memoryCache.GetOrCreateAsync(
                $"book.by-id.{bookId}",
                async (entry) =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);
                    return await GetBookByIdAsync(bookId);
                });
        }

        public async Task<BookItem> GetBookDetailByIdAsync(
           int id,
           CancellationToken cancellationToken = default)
        {
            return await _context.Set<Book>()
                .Include(x => x.Category)
                .Include(x => x.Author)
                .AsNoTracking()
                .Select(x => new BookItem()
                {
                    Id = x.Id,
                    Title = x.Title,
                    UrlSlug = x.UrlSlug,
                    ImageUrl = x.ImageUrl,
                    Meta = x.Meta,
                    ShortDescription = x.ShortDescription,
                    Description = x.Description,
                    PublishCompany = x.PublishCompany,
                    Price = x.Price,
                    CoverForm = x.CoverForm,
                    AuthorId = x.Author.Id,
                    CategoryId = x.Category.Id,
                })
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<Book> GetBookByIdAsync(
          int bookId, bool includeDetails = false,
          CancellationToken cancellationToken = default)
        {
            if (!includeDetails)
            {
                return await _context.Set<Book>().FindAsync(bookId);
            }

            return await _context.Set<Book>()
                .Include(x => x.Category)
                .Include(x => x.Author)
                .FirstOrDefaultAsync(x => x.Id == bookId, cancellationToken);
        }

        public async Task<Book> GetBookBySlugAsync(
          string slug,
          CancellationToken cancellationToken = default)
        {
            return await _context.Set<Book>()
                .Include(x => x.Category)
                .Include(x => x.Author)
                .FirstOrDefaultAsync(x => x.UrlSlug == slug, cancellationToken);
        }

    }
}
