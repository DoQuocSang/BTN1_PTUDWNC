namespace TatBlog.WebApi.Models
{
    public class BookFilterModel : PagingModel
    {
        public string Title { get; set; }
        public string AuthorSlug { get; set; }
        public string CategorySlug { get; set; }

    }
}
