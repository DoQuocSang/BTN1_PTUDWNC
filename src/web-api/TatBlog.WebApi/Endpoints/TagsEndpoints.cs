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
                .Produces<ApiResponse<PaginationResult<PostItem>>>();

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
        
    }
}

