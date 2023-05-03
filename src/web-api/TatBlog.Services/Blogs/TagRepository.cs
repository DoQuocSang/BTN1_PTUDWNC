using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Linq.Expressions;
using TatBlog.Core.Contracts;
using TatBlog.Core.DTO;
using TatBlog.Core.Entities;
using TatBlog.Data.Contexts;
using TatBlog.Services.Extensions;

namespace TatBlog.Services.Blogs
{
    public class TagRepository : ITagRepository
    {
        private readonly BlogDbContext _context;
        private readonly IMemoryCache _memoryCache;

        public TagRepository(BlogDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }

        public async Task<IPagedList<TagItem>> GetPagedTagsAsync(
            IPagingParams pagingParams,
            CancellationToken cancellationToken = default)
        {
            return await _context.Set<Tag>()
                .AsNoTracking()
                .Select(x => new TagItem()
                {
                    Id = x.Id,
                    Name = x.Name,
                    UrlSlug = x.UrlSlug,
                    PostCount = x.Posts.Count(p => p.Published),
                })
                .ToPagedListAsync(pagingParams, cancellationToken);
        }

        public async Task<TagItem> GetCachedTagItemBySlugAsync(
            string slug, CancellationToken cancellationToken = default)
        {
            return await _memoryCache.GetOrCreateAsync(
                $"tag.by-slug.{slug}",
                async (entry) =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);
                    return await GetTagItemBySlugAsync(slug, cancellationToken);
                });
        }

        public async Task<TagItem> GetTagItemBySlugAsync(
            string slug, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Tag>()
                   .Select(x => new TagItem()
                   {
                       Id = x.Id,
                       Name = x.Name,
                       UrlSlug = x.UrlSlug
                   })
                .FirstOrDefaultAsync(a => a.UrlSlug == slug, cancellationToken);
        }
    }
}
