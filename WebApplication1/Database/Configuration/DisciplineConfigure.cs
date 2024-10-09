using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Database.Helpers;
using WebApplication1.Models;

namespace WebApplication1.Database.Configuration
{
    public class DisciplineConfigure : IEntityTypeConfiguration<Disciplines>
    {
        private const string TableName = "cd_Disciplines";

        public void Configure(EntityTypeBuilder<Disciplines> builder)
        {
            builder.HasKey(x => x.Id).HasName($"pk_{TableName}_discipline_id");

            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x=>x.Name).IsRequired().HasColumnName("discipline_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100);
        }
    }
}
