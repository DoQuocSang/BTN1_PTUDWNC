using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TatBlog.Core.Entities;

namespace TatBlog.WebApi.Models
{
    public class BookEditModel
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string UrlSlug { get; set; }
        public string Supplier { get; set; }
        public string PublishCompany { get; set; }
        public string CoverForm { get; set; }
        public int StarNumber { get; set; }
        public int ReviewNumber { get; set; }
        public int Price { get; set; }
    }
}
