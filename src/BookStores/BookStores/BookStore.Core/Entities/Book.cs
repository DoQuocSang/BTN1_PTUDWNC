﻿using BookStore.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Entities
{
    public class Book : IEntity
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
        // Nhà cung cấp
        public string Supplier { get; set; }
        // Nhà xuất bản
        public string PublishCompany { get; set; }
        // Tác giả
        // Hình thức bìa
        public string CoverForm { get; set; }
        // Số sao đánh
        public int StarNumber { get; set; }
        // Số sao trung bình
        public int AverageStar { get; set; }
        // Gía
        public int Price { get; set; }
        // Ngày giờ đăng
        public DateTime PostedDate { get; set; }
        // Ngày cập nhật lần cuối
        public DateTime? ModifiedDate { get; set; }
        // Mã chuyên mục
        public int CategoryId { get; set; }

        // Mã tác giả bài viết
        public int AuthorId { get; set; }

        // Chuyên mục bài viết
        public Category Category { get; set; }
        // Tác giả bài viết
        public Author Author { get; set; }
    }
}
