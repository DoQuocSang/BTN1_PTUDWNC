using BookStore.Core.Contracts;

namespace BookStore.Core.Entities;

public class Post : IEntity
{
    public int Id { get; set; }
    // Tiêu đề bài viết
    public string Title { get; set; }
    // Mô tả ngắn về nội dung
    public string ShortDescription { get; set; }
    // Nội dung chi tiết của bài viết
    public string Description { get; set; }
    public string Meta { get; set; }
    public string UrlSlug { get; set; }
    public string ImageUrl { get; set; }
    // Số Lượt xem
    public int ViewCount { get; set; }
    // Trạng thái bài viét
    public bool Published { get; set; }

    // Ngày giờ đăng
    public DateTime PostedDate { get; set; }
    // Ngày cập nhật lần cuối
    public DateTime? ModifiedDate { get; set; }
    // Mã Sách

    // Mã chuyên mục
    public int CategoryId { get; set; }

    // Mã tác giả bài viết
    public int AuthorId { get; set; }

    // Chuyên mục bài viết
    public Category Category { get; set; }
    // Tác giả bài viết
    public Author Author { get; set; }

    // Danh sách từ khóa bài viết
    public IList<Tag> Tags { get; set; }
  
}
