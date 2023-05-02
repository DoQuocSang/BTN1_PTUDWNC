using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TatBlog.Core.DTO
{
    public class BookQuery
    {
        public int? CategoryId { get; set; }
        public int? AuthorId { get; set; }
        public string AuthorSlug { get; set; }
        public string BookSlug { get; set; }
        public string TitleSlug { get; set; }
        public string CategorySlug { get; set; }
        public string Keyword { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }
        public bool HasRelated { get; set; } = false;

    }
}
