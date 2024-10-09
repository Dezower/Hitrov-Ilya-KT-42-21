using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Database.Helpers;
using WebApplication1.Models;

namespace WebApplication1.Database.Configuration
{
    public class AcademicDegreesConfigure : IEntityTypeConfiguration<AcademicDegrees>
    {
        private const string TableName = "cd_academicDegrees";

        public void Configure(EntityTypeBuilder<AcademicDegrees> builder)
        {
            builder.HasKey(x => x.Id).HasName($"PK_{TableName}_degrees_id");

            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired().HasColumnName("Degree_Name")
                .HasColumnType(ColumnType.String).HasMaxLength(100);
        }
    }
}
