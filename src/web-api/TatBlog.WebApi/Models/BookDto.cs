using TatBlog.Core.Entities;

namespace TatBlog.WebApi.Models
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string UrlSlug { get; set; } 
        public string ImageUrl { get; set; }
        public string Supplier { get; set; }
        public string PublishCompany { get; set; }
        public string CoverForm { get; set; }
        public int StarNumber { get; set; }
        public int ReviewNumber { get; set; }
        public int Price { get; set; }
        public DateTime ReleasedDate { get; set; }
        public CategoryDto Category { get; set; }
        public AuthorDto Author { get; set; }
    }
}
