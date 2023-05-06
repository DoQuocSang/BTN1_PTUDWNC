using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TatBlog.WebApi.Models
{
    public class PostEditModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Meta { get; set; }
        public string UrlSlug { get; set; }
        public string ImageUrl { get; set; }
        public bool Published { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public string SelectedTags { get; set; }
        public IEnumerable<SelectListItem> AuthorList { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public List<string> GetSelectedTags()
        {
            return (SelectedTags ?? "")
            .Split(new[] { ',', ';', '\r', '\n' },
           StringSplitOptions.RemoveEmptyEntries)
            .ToList();
        }

        public static async ValueTask<PostEditModel> BindAsync(
            HttpContext context)
        {
            var form = await context.Request.ReadFormAsync();
            return new PostEditModel()
            {
                //ImageFile = form.Files["ImageFile"],
                Id = int.Parse(form["Id"]),
                Title = form["Title"],
                ShortDescription = form["ShortDescription"],
                Description = form["Description"],
                Meta = form["Meta"],
                Published = form["Published"] != "false",
                CategoryId = int.Parse(form["CategoryId"]),
                AuthorId = int.Parse(form["AuthorId"]),
                SelectedTags = form["SelectedTags"]
            };
        }
    }
}
