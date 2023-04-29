using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Contracts;

namespace TatBlog.Core.Entities
{
    public class Cart : IEntity
    {
        public int Id { get; set; }
        // Id sản phẩm
        public int BookId { get; set; }
        // Giá sản phẩm
        public string Price { get; set; }

        // Danh sách sản phẩm
        public IList<Book> Books { get; set; }

    }
}
