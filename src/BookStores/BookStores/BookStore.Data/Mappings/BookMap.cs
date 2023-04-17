using BookStore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Mappings
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(p => p.ShortDescription)
                .HasMaxLength(5000)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(5000)
                .IsRequired();

            builder.Property(p => p.UrlSlug)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.Meta)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(p => p.ImageUrl)
                .HasMaxLength(1000);

            builder.Property(p => p.Supplier)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.PublishCompany)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.CoverForm)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.StarNumber)
             .HasDefaultValue(0)
             .IsRequired();

            builder.Property(p => p.AverageStar)
             .HasDefaultValue(0)
             .IsRequired();

            builder.Property(p => p.PostedDate)
                .HasColumnType("datetime");

            builder.Property(p => p.ModifiedDate)
                .HasColumnType("datetime");

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(p => p.CategoryId)
                .HasConstraintName("FK_Books_Categories")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(p => p.AuthorId)
                .HasConstraintName("FK_Books_Authors")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
