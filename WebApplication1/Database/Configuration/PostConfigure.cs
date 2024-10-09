using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Database.Helpers;
using WebApplication1.Models;

namespace WebApplication1.Database.Configuration
{
    public class PostConfigure : IEntityTypeConfiguration<Posts>
    {
        private const string TableName = "cd_posts";

        public void Configure(EntityTypeBuilder<Posts> builder)
        {
            builder.HasKey(t => t.Id).HasName($"pk_{TableName}_post_id");

            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired().HasColumnName("Post_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100);
        }
    }
}
