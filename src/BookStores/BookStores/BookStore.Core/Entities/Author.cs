using BookStore.Core.Contracts;


namespace BookStore.Core.Entities;

public class Author : IEntity
{
    public int Id { get; set; }
    public string FullName { get; set; }
    // Tên định danh để tạo URL
    public string UrlSlug { get; set; }

    //public string ImageUrl { get; set; }
    // Ngày bắt đầu
    //public DateTime JoinedDate { get; set; }
    //public string Email { get; set; }

    // Ghi chú
    public string Notes { get; set; }
    // Danh sách bài viết của tác giả
    public IList<Post> Posts { get; set; }
    public IList<Book> Books { get; set; }
}
