using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Database.Helpers;
using WebApplication1.Models;

namespace WebApplication1.Database.Configuration
{
    public class TeachersConfigure : IEntityTypeConfiguration<Teachers>
    {
        private const string TableName = "Teachers";

        public void Configure( EntityTypeBuilder<Teachers> builder)
        {
            builder.HasKey(p=>p.Id).HasName($"pk_{TableName}_id");

            builder.Property(p=>p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Id).HasColumnName("id").HasComment("Ид преподователя");

            builder.Property(p => p.FirstName).IsRequired().HasColumnName("Teacher_firstname")
                .HasColumnType(ColumnType.String).HasMaxLength(40).HasComment("Имя преподователя");

            builder.Property(p => p.LastName).IsRequired().HasColumnName("Teacher_Lastname")
                .HasColumnType(ColumnType.String).HasMaxLength(40).HasComment("фамилия преподователя");

            builder.Property(p => p.Patronomical).IsRequired().HasColumnName("Teacher_Patronomical")
                .HasColumnType(ColumnType.String).HasMaxLength(40).HasComment("Отчество преподователя");

            builder.Property(p => p.PhoneNumber).IsRequired().HasColumnName("Teacher_phone")
                .HasColumnType(ColumnType.String).HasMaxLength(11).HasComment("Номер преподователя");

            builder.ToTable(TableName).HasOne(p=>p.Posts).WithMany().HasForeignKey(p=>p.PostId)
                .HasConstraintName("FK_Post_id").OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName).HasOne(p => p.AcademicDegrees).WithMany().HasForeignKey(p => p.DegreeId)
                .HasConstraintName("FK_AcademicDegrees_id").OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName).HasOne(p => p.Facultys).WithOne(p=>p.Teacher).HasForeignKey<Facultys>(p => p.TeacherId)
                .HasConstraintName("FK_Facultys_id").OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName).HasIndex(p => p.PostId, $"idx_{TableName}_fk_post_id");
            builder.ToTable(TableName).HasIndex(p => p.DegreeId, $"idx_{TableName}_fk_academicdegree_id");
            builder.ToTable(TableName).HasIndex(p => p.FacultyId, $"idx_{TableName}_fk_faculty_id");

            builder.Navigation(p => p.Posts).AutoInclude();
            builder.Navigation(p => p.AcademicDegrees).AutoInclude();
            builder.Navigation(p => p.Facultys).AutoInclude();
        }
    }
}
