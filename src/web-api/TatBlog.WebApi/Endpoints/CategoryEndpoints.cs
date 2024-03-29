﻿using FluentValidation;
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
    public static class CategoryEndpoints
    {
        public static WebApplication MapCategoryEndpoints(
            this WebApplication app)
        {
            var routeGroupBuilder = app.MapGroup("/api/categories");

            routeGroupBuilder.MapGet("/", GetCategories)
                .WithName("GetCategories")
                .Produces<ApiResponse<PaginationResult<CategoryItem>>>();

            routeGroupBuilder.MapGet("/detail/{id:int}", GetCategoryDetails)
               .WithName("GetCategoryById")
               .Produces<ApiResponse<CategoryItem>>();

            routeGroupBuilder.MapGet(
                   "/{slug:regex(^[a-z0-9_-]+$)}",
                   GetCategoryBySlug)
               .WithName("GetCategoryBySlug")
               .Produces<ApiResponse<PaginationResult<CategoryItem>>>();

            routeGroupBuilder.MapGet(
                   "/{slug:regex(^[a-z0-9_-]+$)}/posts",
                   GetPostsByCategorySlug)
               .WithName("GetPostsByCategorySlug")
               .Produces<ApiResponse<PaginationResult<PostDto>>>();

            routeGroupBuilder.MapPost("/", AddCategory)
               .WithName("AddNewCategory")
               .AddEndpointFilter<ValidatorFilter<CategoryEditModel>>()
               .RequireAuthorization()
               .Produces(401)
               .Produces<ApiResponse<CategoryItem>>();

            routeGroupBuilder.MapPut("/{id:int}", UpdateCategory)
               .WithName("UpdateCategory")
               .AddEndpointFilter<ValidatorFilter<CategoryEditModel>>()
               .RequireAuthorization()
               .Produces(401)
               .Produces<ApiResponse<string>>();

            routeGroupBuilder.MapDelete("/{id:int}", DeleteCategory)
                .WithName("DeleteCategory")
                .RequireAuthorization()
                .Produces(401)
                .Produces<ApiResponse<string>>();

            return app;
        }

        //private static async Task<IResult> GetCategories(
        //    [AsParameters] CategoryFilterModel model,
        //    ICategoryRepository categoryRepository)
        //{
        //    // model kế thừa từ PagingModel
        //    var categories = await categoryRepository.GetPagedCategoriesAsync(model, model.Name);

        //    var paginationResult = new PaginationResult<CategoryItem>(categories);
        //    return Results.Ok(paginationResult);
        //}

        private static async Task<IResult> GetCategories(
         [AsParameters] CategoryFilterModel model,
         ICategoryRepository categoryRepository)
        {
            var categoriesList = await categoryRepository
                .GetPagedCategoriesAsync(model, model.Name);

            var paginationResult =
                new PaginationResult<CategoryItem>(categoriesList);

            //return Results.Ok(paginationResult);
            return Results.Ok(ApiResponse.Success(paginationResult));
        }

        //private static async Task<IResult> GetCategoryBySlug(
        //  string slug,
        //  ICategoryRepository categoryRepository,
        //  IMapper mapper)
        //{
        //    var category = await categoryRepository.GetCachedCategoryBySlugAsync(slug);

        //    return category == null
        //        ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound,
        //        $"không tìm thấy chuyên mục có slug {slug}"))
        //        : Results.Ok(ApiResponse.Success(mapper.Map<CategoryItem>(category)));
        //}

        private static async Task<IResult> GetCategoryBySlug(
          string slug,
          ICategoryRepository categoryRepository,
          IMapper mapper)
        {
            var category = await categoryRepository.GetCachedCategoryItemBySlugAsync(slug);

            return category == null
                ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound,
                $"không tìm thấy chuyên mục có slug {slug}"))
                : Results.Ok(ApiResponse.Success(category));
        }

        private static async Task<IResult> GetCategoryDetails(
          int id,
          ICategoryRepository categoryRepository,
          IMapper mapper)
        {
            //var category = await categoryRepository.GetCachedCategoryByIdAsync(id);
            var category = await categoryRepository.GetCategoryDetailByIdAsync(id);

            return category == null
                ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound,
                $"không tìm thấy chuyên mục có mã số {id}"))
                : Results.Ok(ApiResponse.Success(mapper.Map<CategoryItem>(category)));
        }

        private static async Task<IResult> GetPostsByCategorySlug(
           [FromRoute] string slug,
           [AsParameters] PagingModel pagingModel,
           IBlogRepository blogRepository)
        {
            var postQuery = new PostQuery()
            {
                CategorySlug = slug,
                PublishedOnly = true
            };

            var postsList = await blogRepository.GetPagedPostsAsync(
                postQuery, pagingModel,
                posts => posts.ProjectToType<PostDto>());
            var paginationResult = new PaginationResult<PostDto>(postsList);

            //return Results.Ok(paginationResult);
            return Results.Ok(ApiResponse.Success(paginationResult));
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

            return Results.Ok(ApiResponse.Success(paginationResult));
        }

        private static async Task<IResult> AddCategory(
           CategoryEditModel model,
           IValidator<CategoryEditModel> validator,
           ICategoryRepository categoryRepository,
           IMapper mapper)
        {
            if (await categoryRepository
                .IsCategorySlugExistedAsync(0, model.UrlSlug))
            {
                return Results.Ok(ApiResponse.Fail(
                    HttpStatusCode.Conflict, $"Slug '{model.UrlSlug}' đã được sử dụng"));
            }

            var category = mapper.Map<Category>(model);
            await categoryRepository.AddOrUpdateAsync(category);

            return Results.Ok(ApiResponse.Success(
                    mapper.Map<CategoryItem>(category), HttpStatusCode.Created));
        }

        private static async Task<IResult> UpdateCategory(
            int id, CategoryEditModel model,
            IValidator<CategoryEditModel> validator,
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            if (await categoryRepository
                    .IsCategorySlugExistedAsync(id, model.UrlSlug))
            {

                return Results.Ok(ApiResponse.Fail(
                    HttpStatusCode.Conflict,
                    $"Slug '{model.UrlSlug}' đã được sử dụng"));
            }

            var category = mapper.Map<Category>(model);
            category.Id = id;

            return await categoryRepository.AddOrUpdateAsync(category)
              ? Results.Ok(ApiResponse.Success("Category is updated",
                            HttpStatusCode.NoContent))
              : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound,
                            "Could not find category"));
        }

        private static async Task<IResult> DeleteCategory(
            int id, ICategoryRepository categoryRepository)
        {
            return await categoryRepository.DeleteCategoryAsync(id)
              ? Results.Ok(ApiResponse.Success("Category is deleted",
                            HttpStatusCode.NoContent))
              : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound,
                            "Could not find category"));
        }
    }
}

