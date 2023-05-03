using FluentValidation;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using SlugGenerator;
using System.ComponentModel.DataAnnotations;
using System.Net;
using TatBlog.Core.Collections;
using TatBlog.Core.DTO;
using TatBlog.Core.Entities;
using TatBlog.Services.Blogs;
using TatBlog.Services.Media;
using TatBlog.WebApi.Extensions;
using TatBlog.WebApi.Filters;
using TatBlog.WebApi.Models;

namespace TatBlog.WebApi.Endpoints
{
    public static class TagsEndpoints
    {
        public static WebApplication MapTagEndpoints(
            this WebApplication app)
        {
            var routeGroupBuilder = app.MapGroup("/api/tags");

            routeGroupBuilder.MapGet("/", GetTags)
                .WithName("GetTags")
                .Produces<ApiResponse<PaginationResult<TagItem>>>();

            routeGroupBuilder.MapGet(
                "/{slug:regex(^[a-z0-9_-]+$)}/posts",
                 GetPostsByTagSlug)
                 .WithName("GetPostsByTagSlug")
                 .Produces<ApiResponse<PaginationResult<PostDto>>>();

            routeGroupBuilder.MapGet(
                  "/{slug:regex(^[a-z0-9_-]+$)}",
                  GetTagBySlug)
                  .WithName("GetTagBySlug")
                  .Produces<ApiResponse<PaginationResult<TagItem>>>();

            return app;
        }


        private static async Task<IResult> GetTags(
        [AsParameters] TagFilterModel model,
        ITagRepository tagRepository)
        {
            var tagsList = await tagRepository
                .GetPagedTagsAsync(model);

            var paginationResult =
                new PaginationResult<TagItem>(tagsList);

            //return Results.Ok(paginationResult);
            return Results.Ok(ApiResponse.Success(paginationResult));
        }

        private static async Task<IResult> GetPostsByTagSlug(
         [FromRoute] string slug,
         [AsParameters] PagingModel pagingModel,
         IBlogRepository blogRepository)
        {
            var postQuery = new PostQuery()
            {
                TagSlug = slug,
                PublishedOnly = true
            };

            var postsList = await blogRepository.GetPagedPostsAsync(
                postQuery, pagingModel,
                posts => posts.ProjectToType<PostDto>());
            var paginationResult = new PaginationResult<PostDto>(postsList);

            //return Results.Ok(paginationResult);
            return Results.Ok(ApiResponse.Success(paginationResult));
        }

        private static async Task<IResult> GetTagBySlug(
          string slug,
          ITagRepository tagRepository,
          IMapper mapper)
        {
            var tag = await tagRepository.GetCachedTagItemBySlugAsync(slug);

            return tag == null
                ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound,
                $"không tìm thấy thẻ có slug {slug}"))
                : Results.Ok(ApiResponse.Success(tag));
        }

    }
}

