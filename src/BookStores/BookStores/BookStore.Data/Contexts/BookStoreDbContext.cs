
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BookStore.Core.Entities;
using BookStore.Data.Mappings;


namespace BookStore.Data.Contexts;

public class BookStoreDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Tag> Tags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Chú ý thay chuổi kết nối cho phù hợp
        //optionsBuilder.UseSqlServer(@"Server =LAPTOP-GEIT9Q0O;Database=BookStore;
        //                Trusted_Connection=True;MultipleActiveResultSets=true");
        optionsBuilder.UseSqlServer(@"Server=LAPTOP-GEIT9Q0O;TrustServerCertificate=True;Database=BookStore;
                Trusted_Connection=True;MultipleActiveResultSets=true");

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(CategoryMap).Assembly);
    }
}
// còn lệnh "Add-Migration InitialCreate" Phần 4 Trang 11 
