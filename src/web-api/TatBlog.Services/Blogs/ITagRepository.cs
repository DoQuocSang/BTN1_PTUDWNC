using TatBlog.Core.Contracts;
using TatBlog.Core.DTO;
using TatBlog.Core.Entities;

namespace TatBlog.Services.Blogs;

public interface ITagRepository
{
    Task<IPagedList<TagItem>> GetPagedTagsAsync(
        IPagingParams pagingParams,
        CancellationToken cancellationToken = default);
    Task<TagItem> GetCachedTagItemBySlugAsync(
        string slug, CancellationToken cancellationToken = default);

    Task<TagItem> GetTagItemBySlugAsync(
        string slug, CancellationToken cancellationToken = default);
}