﻿using FluentValidation;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public static class PostEndpoints
    {
        public static WebApplication MapPostEndpoints(
            this WebApplication app)
        {
            var routeGroupBuilder = app.MapGroup("/api/posts");

            routeGroupBuilder.MapGet("/", GetPosts)
                .WithName("GetPosts")
                .Produces<ApiResponse<PaginationResult<PostItem>>>();

            routeGroupBuilder.MapGet("/featured/{limit}", GetFeaturedPosts)
                .WithName("GetFeaturedPosts")
                .Produces<ApiResponse<PaginationResult<PostItem>>>();

            routeGroupBuilder.MapGet("/random/{limit}", GetRandomPosts)
               .WithName("GetRandomPosts")
               .Produces<ApiResponse<PaginationResult<PostItem>>>();

            //routeGroupBuilder.MapGet("/archives/{limit}", GetPosts)
            //   .WithName("GetPosts")
            //   .Produces<ApiResponse<PaginationResult<PostItem>>>();

            routeGroupBuilder.MapGet("/{id:int}", GetPostDetails)
                .WithName("GetPostById")
                .Produces<ApiResponse<PostItem>>();

            routeGroupBuilder.MapGet(
                    "/byslug/{slug:regex(^[a-z0-9_-]+$)}",
                    GetPostsBySlug)
                .WithName("GetPostsBySlug")
                .Produces<ApiResponse<PaginationResult<PostDto>>>();

            //routeGroupBuilder.MapGet(
            //       "/byslug/category/{slug:regex(^[a-z0-9_-]+$)}",
            //       GetPostsByCategorySlug)
            //   .WithName("GetPostsByCategorySlug")
            //   .Produces<ApiResponse<PaginationResult<PostDto>>>();

            //routeGroupBuilder.MapPost("/", AddPost)
            //    .WithName("AddNewPost")
            //    .AddEndpointFilter<ValidatorFilter<PostEditModel>>()
            //    .RequireAuthorization()
            //    .Produces(401)
            //    .Produces<ApiResponse<PostItem>>();

            //routeGroupBuilder.MapPost("/{id:int}/picture", SetPostPicture)
            //    .WithName("SetPostPicture")
            //    .RequireAuthorization()
            //    .Accepts<IFormFile>("multipart/form-data")
            //    .Produces(401)
            //    .Produces<ApiResponse<string>>();

            //routeGroupBuilder.MapPut("/{id:int}", UpdatePost)
            //    .WithName("UpdateAnPost")
            //    .AddEndpointFilter<ValidatorFilter<PostEditModel>>()
            //    .RequireAuthorization()
            //    .Produces(401)
            //    .Produces<ApiResponse<string>>();

            //routeGroupBuilder.MapDelete("/{id:int}", DeletePost)
            //    .WithName("DeleteAnPost")
            //    .RequireAuthorization()
            //    .Produces(401)
            //    .Produces<ApiResponse<string>>();

            //routeGroupBuilder.MapGet("/get-posts-filter", GetFilteredPosts)
            //      .WithName("GetFilteredPost")
            //      .Produces<ApiResponse<PostDto>>();

            //routeGroupBuilder.MapGet("/get-filter", GetFilter)
            //      .WithName("GetFilter")
            //      .Produces<ApiResponse<PostFilterModel>>();

            //routeGroupBuilder.MapPost("/", AddPost)
            //     .WithName("AddNewPost")
            //     .Accepts<PostEditModel>("multipart/form-data")
            //     .Produces(401)
            //     .Produces<ApiResponse<PostItem>>();

            routeGroupBuilder.MapPost("/", AddPost)
                .WithName("AddPost")
                .AddEndpointFilter<ValidatorFilter<PostEditModel>>()
                .Produces(401)
                .Produces<ApiResponse<PostItem>>();

            return app;
        }

        //private static async Task<IResult> GetPosts(
        //    [AsParameters] PostFilterModel model,
        //    IBlogRepository blogRepository)
        //{
        //    var postsList = await blogRepository
        //        .GetPagedPostsAsync(model, model.Title);

        //    var paginationResult =
        //        new PaginationResult<PostItem>(postsList);

        //    return Results.Ok(ApiResponse.Success(paginationResult));
        //}

        //private static async Task<IResult> GetPosts(
        //    [AsParameters] PostQuery model,
        //    IBlogRepository blogRepository)
        //{
        //    var postsList = await blogRepository
        //        .GetPagedPostsConvertPostItemAsync(model);

        //    var paginationResult =
        //        new PaginationResult<PostItem>(postsList);

        //    return Results.Ok(ApiResponse.Success(paginationResult));
        //}

        private static async Task<IResult> GetPosts(
            [AsParameters] PostFilterModel model,
            IBlogRepository blogRepository,
            IMapper mapper)
        {
            var query = mapper.Map<PostQuery>(model);
            var postsList = await blogRepository
                .GetPagedPostsConvertPostItemAsync(query, model,
                posts => posts.ProjectToType<PostDto>());

            var paginationResult =
                new PaginationResult<PostDto>(postsList);

            return Results.Ok(ApiResponse.Success(paginationResult));
        }

        private static async Task<IResult> GetFeaturedPosts(
        int numPosts,
        IBlogRepository blogRepository)
        {
            var postsList = await blogRepository
                .GetPopularPostsAsync(numPosts);

            var paginationResult =
                new PaginationResult<PostItem>(postsList);

            return Results.Ok(ApiResponse.Success(paginationResult));
        }

        private static async Task<IResult> GetRandomPosts(
        int numPosts,
        IBlogRepository blogRepository)
        {
            var postsList = await blogRepository
                .GetRandomPostsAsync(numPosts);

            var paginationResult =
                new PaginationResult<PostItem>(postsList);

            return Results.Ok(ApiResponse.Success(paginationResult));
        }

        private static async Task<IResult> GetPostDetails(
            int id,
            IBlogRepository blogRepository,
            IMapper mapper)
        {
            //var post = await blogRepository.GetCachedPostByIdAsync(id);
            var post = await blogRepository.GetPostDetailByIdAsync(id);

            return post == null
                ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound,
                $"không tìm thấy bài viết có mã số {id}"))
                : Results.Ok(ApiResponse.Success(mapper.Map<PostItem>(post)));
        }

        private static async Task<IResult> GetPostsBySlug(
            [FromRoute] string slug,
            [AsParameters] PagingModel pagingModel,
            IBlogRepository blogRepository)
        {
            var postQuery = new PostQuery()
            {
                PostSlug = slug,
                PublishedOnly = true
            };
            
            var postsList = await blogRepository.GetPagedPostsAsync(
                postQuery, pagingModel,
                posts => posts.ProjectToType<PostDto>());
            var paginationResult = new PaginationResult<PostDto>(postsList);

            await blogRepository.IncreaseViewCountBySlugAsync(slug);

            return Results.Ok(ApiResponse.Success(paginationResult));
        }

        //private static async Task<IResult> GetPostsByCategorySlug (
        //  [FromRoute] string slug,
        //  [AsParameters] PagingModel pagingModel,
        //  IBlogRepository blogRepository)
        //{
        //    var postQuery = new PostQuery()
        //    {
        //        CategorySlug = slug,
        //        PublishedOnly = true
        //    };

        //    var postsList = await blogRepository.GetPagedPostsAsync(
        //        postQuery, pagingModel,
        //        posts => posts.ProjectToType<PostDto>());
        //    var paginationResult = new PaginationResult<PostDto>(postsList);

        //    return Results.Ok(ApiResponse.Success(paginationResult));
        //}

        private static async Task<IResult> GetFilter(
             IAuthorRepository authorRepository,
             ICategoryRepository categoryRepository)
        {
            var model = new PostFilterModel()
            {
                AuthorList = (await authorRepository.GetAuthorsAsync())
                .Select(a => new SelectListItem()
                {
                    Text = a.FullName,
                    Value = a.Id.ToString()
                }),
                CategoryList = (await categoryRepository.GetCategoriesAsync())
                .Select(c => new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
            };
            return Results.Ok(ApiResponse.Success(model));
        }

        private static async Task<IResult> GetFilteredPosts(
             [AsParameters] PostFilterModel model,
             [AsParameters] PagingModel pagingModel,
             IBlogRepository blogRepository)
        {
            var postQuery = new PostQuery()
            {
                Keyword = model.Keyword,
                CategoryId = model.CategoryId,
                AuthorId = model.AuthorId,
                Year = model.Year,
                Month = model.Month,
            };
            var postsList = await blogRepository.GetPagedPostsAsync(
            postQuery, pagingModel, posts =>
           posts.ProjectToType<PostDto>());
            var paginationResult = new PaginationResult<PostDto>(postsList);
            return Results.Ok(ApiResponse.Success(paginationResult));
        }

        //private static async Task<IResult> AddPost(
        //    AuthorEditModel model,
        //    IValidator<AuthorEditModel> validator,
        //    IAuthorRepository authorRepository,
        //    IMapper mapper)
        //{
        //    if (await authorRepository
        //        .IsAuthorSlugExistedAsync(0, model.UrlSlug))
        //    {
        //        return Results.Ok(ApiResponse.Fail(
        //            HttpStatusCode.Conflict, $"Slug '{model.UrlSlug}' đã được sử dụng"));
        //    }

        //    var author = mapper.Map<Author>(model);
        //    await authorRepository.AddOrUpdateAsync(author);

        //    return Results.Ok(ApiResponse.Success(
        //            mapper.Map<AuthorItem>(author), HttpStatusCode.Created));
        //}

        //private static async Task<IResult> AddPost(
        //     HttpContext context,
        //     IBlogRepository blogRepository,
        //     IMapper mapper,
        //     IMediaManager mediaManager)
        //{
        //    var model = await PostEditModel.BindAsync(context);
        //    var slug = model.Title.GenerateSlug();
        //    if (await blogRepository.IsPostSlugExistedAsync(model.Id, slug))
        //    {
        //        return Results.Ok(ApiResponse.Fail(
        //         HttpStatusCode.Conflict, $"Slug '{slug}' đã được sử dụng cho bài viết khác"));
        //    }
        //    var post = model.Id > 0 ? await
        //        blogRepository.GetPostByIdAsync(model.Id) : null;
        //    if (post == null)
        //    {
        //        post = new Post()
        //        {
        //            PostedDate = DateTime.Now
        //        };
        //    }
        //    post.Title = model.Title;
        //    post.AuthorId = model.AuthorId;
        //    post.CategoryId = model.CategoryId;
        //    post.ShortDescription = model.ShortDescription;
        //    post.Description = model.Description;
        //    post.Meta = model.Meta;
        //    post.Published = model.Published;
        //    post.ModifiedDate = DateTime.Now;
        //    post.UrlSlug = model.Title.GenerateSlug();
        //    //if (model.ImageFile?.Length > 0)
        //    //{
        //    //    string hostname =
        //    //        $"{context.Request.Scheme}://{context.Request.Host}{context.Request.PathBase}/",
        //    //        uploadedPath = await
        //    //        mediaManager.SaveFileAsync(model.ImageFile.OpenReadStream(),
        //    //        model.ImageFile.FileName,
        //    //        model.ImageFile.ContentType);
        //    //    if (!string.IsNullOrWhiteSpace(uploadedPath))
        //    //    {
        //    //        post.ImageUrl = hostname + uploadedPath;
        //    //    }
        //    //}
        //    post.ImageUrl = model.ImageUrl;
        //    await blogRepository.CreateOrUpdatePostAsync(post, model.GetSelectedTags());
        //    return Results.Ok(ApiResponse.Success(
        //    mapper.Map<PostItem>(post), HttpStatusCode.Created));
        //}

        //private static async Task<IResult> AddPost(
        //    PostEditModel model,
        //    IValidator<PostEditModel> validator,
        //    IBlogRepository blogRepository,
        //    IMapper mapper)
        //{
        //    var slug = model.Title.GenerateSlug();
        //    if (await blogRepository.IsPostSlugExistedAsync(model.Id, slug))
        //    {
        //        return Results.Ok(ApiResponse.Fail(
        //         HttpStatusCode.Conflict, $"Slug '{slug}' đã được sử dụng cho bài viết khác"));
        //    }

        //    var post = mapper.Map<Post>(model);
        //    await blogRepository.AddOrUpdateAsync(post);
        //    return Results.Ok(ApiResponse.Success(
        //        mapper.Map<PostItem>(post), HttpStatusCode.Created));
        //}

        private static async Task<IResult> AddPost(
           PostEditModel model,
           IValidator<PostEditModel> validator,
           IBlogRepository blogRepository,
           IMapper mapper)
        {
            if (await blogRepository
                .IsPostSlugExistedAsync(0, model.UrlSlug))
            {
                //return Results.Conflict(
                //    $"Slug '{model.UrlSlug}' đã được sử dụng");

                return Results.Ok(ApiResponse.Fail(
                    HttpStatusCode.Conflict, $"Slug '{model.UrlSlug}' đã được sử dụng"));
            }

            var post = mapper.Map<Post>(model);
            await blogRepository.AddOrUpdateAsync(post);

            //return Results.CreatedAtRoute(
            //    "GetAuthorById", new { author.Id },
            //    mapper.Map<AuthorItem>(author));

            return Results.Ok(ApiResponse.Success(
                    mapper.Map<PostItem>(post), HttpStatusCode.Created));
        }


        private static async Task<IResult> SetPostPicture(
            int id, IFormFile imageFile,
            IAuthorRepository authorRepository,
            IMediaManager mediaManager)
        {
            var imageUrl = await mediaManager.SaveFileAsync(
                imageFile.OpenReadStream(),
                imageFile.FileName, imageFile.ContentType);

            if (string.IsNullOrWhiteSpace(imageUrl))
            {
                return Results.Ok(ApiResponse.Fail(
                   HttpStatusCode.BadRequest, "Không lưu được tập tin"));
            }
            await authorRepository.SetImageUrlAsync(id, imageUrl);

            return Results.Ok(ApiResponse.Success(imageUrl));
        }

        private static async Task<IResult> UpdatePost(
            int id, AuthorEditModel model,
            IValidator<AuthorEditModel> validator,
            IAuthorRepository authorRepository,
            IMapper mapper)
        {
            if (await authorRepository
                    .IsAuthorSlugExistedAsync(id, model.UrlSlug))
            {
                return Results.Ok(ApiResponse.Fail(
                    HttpStatusCode.Conflict,
                    $"Slug '{model.UrlSlug}' đã được sử dụng"));
            }

            var author = mapper.Map<Author>(model);
            author.Id = id;

            return await authorRepository.AddOrUpdateAsync(author)
              ? Results.Ok(ApiResponse.Success("Author is updated",
                            HttpStatusCode.NoContent))
              : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound,
                            "Could not find author"));
        }

        private static async Task<IResult> DeletePost(
            int id, IAuthorRepository authorRepository)
        {
            return await authorRepository.DeleteAuthorAsync(id)
              ? Results.Ok(ApiResponse.Success("Author is deleted",
                            HttpStatusCode.NoContent))
              : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound,
                            "Could not find author"));
        }
    }
}

