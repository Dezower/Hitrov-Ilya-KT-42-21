using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Database.Helpers;
using WebApplication1.Models;

namespace WebApplication1.Database.Configuration
{
    public class FacultysConfigure : IEntityTypeConfiguration<Facultys>
    {
        private const string TableName = "cd_Facultys";

        public void Configure(EntityTypeBuilder<Facultys> builder)
        {
            builder.HasKey(x => x.Id).HasName($"pk_{TableName}_faculty_id");

            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired().HasColumnName("Facultys_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100);

            builder.ToTable(TableName).HasOne(x => x.Teacher).WithOne(y => y.Facultys).HasForeignKey<Teachers>(x=>x.FacultyId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName).HasIndex(x => x.TeacherId,$"idx_{TableName}_fk_teacher_id");

            builder.Navigation(p => p.Teacher).AutoInclude();

        }
    }
}
