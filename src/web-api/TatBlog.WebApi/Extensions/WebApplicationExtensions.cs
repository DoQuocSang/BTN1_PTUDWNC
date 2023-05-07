﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using TatBlog.Core.Entities;
using TatBlog.Data.Contexts;
using TatBlog.Services.Blogs;
using TatBlog.Services.Media;
using TatBlog.Services.Timing;
using TatBlog.WebApi.Endpoints;

namespace TatBlog.WebApi.Extensions
{
    public static class WebApplicationExtensions
    {
        public static WebApplicationBuilder ConfigureServices(
            this WebApplicationBuilder builder)
        {
            builder.Services.AddMemoryCache();

            builder.Services.AddDbContext<BlogDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration
                        .GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<BlogDbContext>()
                .AddDefaultTokenProviders();

            builder.Services
                .AddScoped<ITimeProvider, LocalTimeProvider>();
            builder.Services
                .AddScoped<IMediaManager, LocalFileSystemMediaManager>();
            builder.Services
                .AddScoped<IBlogRepository, BlogRepository>();
            builder.Services
                .AddScoped<IAuthorRepository, AuthorRepository>();
            builder.Services
               .AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services
              .AddScoped<IBookRepository, BookRepository>();
            builder.Services
            .AddScoped<ITagRepository, TagRepository>(); 
            builder.Services
            .AddScoped<IUserServiceRepository, UserServiceRepository>();
            builder.Services
            .AddScoped<UserManager<AppUser>, UserManager<AppUser>>();
            builder.Services
            .AddScoped<SignInManager<AppUser>, SignInManager<AppUser>>();
            builder.Services
            .AddScoped<RoleManager<AppRole>, RoleManager<AppRole>>();




            return builder;
        }

        public static WebApplicationBuilder ConfigureCors(
            this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("TatBlogApp", policyBuilder => 
                    policyBuilder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });

            return builder;
        }

        public static WebApplicationBuilder ConfigureNLog(
            this WebApplicationBuilder builder)
        {
            builder.Logging.ClearProviders(); 
            builder.Host.UseNLog();

            return builder;
        }

        public static WebApplicationBuilder ConfigureSwaggerOpenApi(
            this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            return builder;
        }

        public static WebApplication SetupRequestPipeline(
            this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseCors("TatBlogApp");

            return app;
        }
    }
}

