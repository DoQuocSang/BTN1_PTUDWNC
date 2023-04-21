using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Entities;

namespace TatBlog.Data.Mappings
{
    public class AccountMap : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.NameAccount)
               .IsRequired()
               .HasMaxLength(100);

            builder.Property(a => a.EmailAccount)
               .IsRequired()
               .HasMaxLength(100);

            builder.Property(a => a.Pass)
               .IsRequired()
               .HasMaxLength(100);

            builder.Property(a => a.Type)
               .IsRequired()
               .HasDefaultValue(false);
        }
    }
}
