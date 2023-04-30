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
    public static class BookEndpoints
    {
        public static WebApplication MapBookEndpoints(
            this WebApplication app)
        {
            var routeGroupBuilder = app.MapGroup("/api/books");

            routeGroupBuilder.MapGet("/", GetBooks)
                .WithName("GetBooks")
                .Produces<ApiResponse<PaginationResult<BookDto>>>();

            //routeGroupBuilder.MapGet("/featured/{limit}", GetFeaturedBooks)
            //    .WithName("GetFeaturedBooks")
            //    .Produces<ApiResponse<PaginationResult<BookItem>>>();

            routeGroupBuilder.MapGet("/random/{limit}", GetRandomBooks)
               .WithName("GetRandomBooks")
               .Produces<ApiResponse<PaginationResult<BookItem>>>();

            //routeGroupBuilder.MapGet("/archives/{limit}", GetBooks)
            //   .WithName("GetBooks")
            //   .Produces<ApiResponse<PaginationResult<BookItem>>>();

            routeGroupBuilder.MapGet("/{id:int}", GetBookDetails)
                .WithName("GetBookById")
                .Produces<ApiResponse<BookItem>>();

            //routeGroupBuilder.MapGet(
            //        "/byslug/{slug:regex(^[a-z0-9_-]+$)}",
            //        GetBooksBySlug)
            //    .WithName("GetBooksBySlug")
            //    .Produces<ApiResponse<PaginationResult<BookDto>>>();

            //routeGroupBuilder.MapBook("/", AddBook)
            //    .WithName("AddNewBook")
            //    .AddEndpointFilter<ValidatorFilter<BookEditModel>>()
            //    .RequireAuthorization()
            //    .Produces(401)
            //    .Produces<ApiResponse<BookItem>>();

            //routeGroupBuilder.MapBook("/{id:int}/picture", SetBookPicture)
            //    .WithName("SetBookPicture")
            //    .RequireAuthorization()
            //    .Accepts<IFormFile>("multipart/form-data")
            //    .Produces(401)
            //    .Produces<ApiResponse<string>>();

            //routeGroupBuilder.MapPut("/{id:int}", UpdateBook)
            //    .WithName("UpdateAnBook")
            //    .AddEndpointFilter<ValidatorFilter<BookEditModel>>()
            //    .RequireAuthorization()
            //    .Produces(401)
            //    .Produces<ApiResponse<string>>();

            //routeGroupBuilder.MapDelete("/{id:int}", DeleteBook)
            //    .WithName("DeleteAnBook")
            //    .RequireAuthorization()
            //    .Produces(401)
            //    .Produces<ApiResponse<string>>();

            return app;
        }

        //private static async Task<IResult> GetBooks(
        //    [AsParameters] BookFilterModel model,
        //    IBlogRepository blogRepository)
        //{
        //    var BooksList = await blogRepository
        //        .GetPagedBooksAsync(model, model.Title);

        //    var paginationResult =
        //        new PaginationResult<BookItem>(BooksList);

        //    return Results.Ok(ApiResponse.Success(paginationResult));
        //}

        //private static async Task<IResult> GetBooks(
        //    [AsParameters] BookQuery model,
        //    IBlogRepository blogRepository)
        //{
        //    var BooksList = await blogRepository
        //        .GetPagedBooksConvertBookItemAsync(model);

        //    var paginationResult =
        //        new PaginationResult<BookItem>(BooksList);

        //    return Results.Ok(ApiResponse.Success(paginationResult));
        //}

        private static async Task<IResult> GetBooks(
            [AsParameters] BookFilterModel model,
            IBookRepository bookRepository,
            IMapper mapper)
        {
            var query = mapper.Map<BookQuery>(model);
            var booksList = await bookRepository
                .GetPagedBooksConvertBookItemAsync(query, model,
                books => books.ProjectToType<BookDto>());

            var paginationResult =
                new PaginationResult<BookDto>(booksList);

            return Results.Ok(ApiResponse.Success(paginationResult));
        }

        //private static async Task<IResult> GetFeaturedBooks(
        //int numBooks,
        //IBlogRepository blogRepository)
        //{
        //    var BooksList = await blogRepository
        //        .GetPopularBooksAsync(numBooks);

        //    var paginationResult =
        //        new PaginationResult<BookItem>(BooksList);

        //    return Results.Ok(ApiResponse.Success(paginationResult));
        //}

        private static async Task<IResult> GetRandomBooks(
        int numBooks,
        IBookRepository bookRepository)
        {
            var booksList = await bookRepository
                .GetRandomBooksAsync(numBooks);

            var paginationResult =
                new PaginationResult<BookItem>(booksList);

            return Results.Ok(ApiResponse.Success(paginationResult));
        }

        private static async Task<IResult> GetBookDetails(
            int id,
            IBookRepository bookRepository,
            IMapper mapper)
        {
            var Book = await bookRepository.GetCachedBookByIdAsync(id);

            return Book == null
                ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound,
                $"không tìm thấy sách có mã số {id}"))
                : Results.Ok(ApiResponse.Success(mapper.Map<BookItem>(Book)));
        }

        //private static async Task<IResult> GetBooksBySlug(
        //    [FromRoute] string slug,
        //    [AsParameters] PagingModel pagingModel,
        //    IBlogRepository blogRepository)
        //{
        //    var BookQuery = new BookQuery()
        //    {
        //        BookSlug = slug,
        //        PublishedOnly = true
        //    };

        //    var BooksList = await blogRepository.GetPagedBooksAsync(
        //        BookQuery, pagingModel,
        //        Books => Books.ProjectToType<BookDto>());
        //    var paginationResult = new PaginationResult<BookDto>(BooksList);

        //    return Results.Ok(ApiResponse.Success(paginationResult));
        //}

        //private static async Task<IResult> AddBook(
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

        //private static async Task<IResult> SetBookPicture(
        //    int id, IFormFile imageFile,
        //    IAuthorRepository authorRepository,
        //    IMediaManager mediaManager)
        //{
        //    var imageUrl = await mediaManager.SaveFileAsync(
        //        imageFile.OpenReadStream(),
        //        imageFile.FileName, imageFile.ContentType);

        //    if (string.IsNullOrWhiteSpace(imageUrl))
        //    {
        //        return Results.Ok(ApiResponse.Fail(
        //           HttpStatusCode.BadRequest, "Không lưu được tập tin"));
        //    }
        //    await authorRepository.SetImageUrlAsync(id, imageUrl);

        //    return Results.Ok(ApiResponse.Success(imageUrl));
        //}

        //private static async Task<IResult> UpdateBook(
        //    int id, AuthorEditModel model,
        //    IValidator<AuthorEditModel> validator,
        //    IAuthorRepository authorRepository,
        //    IMapper mapper)
        //{
        //    if (await authorRepository
        //            .IsAuthorSlugExistedAsync(id, model.UrlSlug))
        //    {
        //        return Results.Ok(ApiResponse.Fail(
        //            HttpStatusCode.Conflict,
        //            $"Slug '{model.UrlSlug}' đã được sử dụng"));
        //    }

        //    var author = mapper.Map<Author>(model);
        //    author.Id = id;

        //    return await authorRepository.AddOrUpdateAsync(author)
        //      ? Results.Ok(ApiResponse.Success("Author is updated",
        //                    HttpStatusCode.NoContent))
        //      : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound,
        //                    "Could not find author"));
        //}

        //private static async Task<IResult> DeleteBook(
        //    int id, IAuthorRepository authorRepository)
        //{
        //    return await authorRepository.DeleteAuthorAsync(id)
        //      ? Results.Ok(ApiResponse.Success("Author is deleted",
        //                    HttpStatusCode.NoContent))
        //      : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound,
        //                    "Could not find author"));
        //}
    }
}

