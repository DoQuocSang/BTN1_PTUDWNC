using Mapster;
using TatBlog.Core.DTO;
using TatBlog.Core.Entities;
using TatBlog.WebApi.Models;

namespace TatBlog.WebApi.Mapsters
{
    public class MapsterConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Author, AuthorDto>();
            config.NewConfig<Author, AuthorItem>()
                .Map(dest => dest.PostCount,
                    src => src.Posts == null ? 0 : src.Posts.Count);

            config.NewConfig<AuthorEditModel, Author>();


            config.NewConfig<Category, CategoryDto>();
            config.NewConfig<Category, CategoryItem>()
                .Map(dest => dest.PostCount,
                    src => src.Posts == null ? 0 : src.Posts.Count);

            config.NewConfig<CategoryEditModel, Category>();


            config.NewConfig<Post, PostDto>();
            config.NewConfig<Post, PostItem>();
            config.NewConfig<Post, PostDetail>();
            config.NewConfig<PostEditModel, Post>();
            config.NewConfig<PostFilterModel, PostQuery>();

            config.NewConfig<Book, BookDto>();
            config.NewConfig<Book, BookDetail>();
            config.NewConfig<BookEditModel, Book>();
            config.NewConfig<BookFilterModel, BookQuery>();

            config.NewConfig<Tag, TagDto>();
            config.NewConfig<Tag, BookDetail>();
        }
    }
}
