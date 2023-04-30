using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Entities;

namespace TatBlog.Core.DTO
{
    public class BookItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Meta { get; set; }
        public string UrlSlug { get; set; }
        public string ImageUrl { get; set; }
        public string Supplier { get; set; }
        public string PublishCompany { get; set; }
        public string CoverForm { get; set; }
        public int StarNumber { get; set; }
        public int ReviewNumber { get; set; }
        public int Price { get; set; }
        public DateTime ReleasedDate { get; set; }
        public string CategoryName { get; set; }
        public string AuthorName { get; set; }
    }
}
