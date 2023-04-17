using BookStore.Core.Contracts;


namespace BookStore.Core.Entities;

// Chuyên mục chủ đề
public class Category : IEntity
{
   
    public int Id { get; set; }
    public string Name { get; set; }
    // Định danh dùng để tạo URL
    public string UrlSlug { get; set; }
    public string Description { get; set; }
    // Đánh dấu chuyên mục được hiển thị trên Menu
    public bool ShowOnMenu { get; set; }
    // Danh sách bài viết thuộc chuyên mục
    public IList<Post> Posts { get; set; }

}
