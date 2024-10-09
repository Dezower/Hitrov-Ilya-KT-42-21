using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Database.Configuration
{
    public class WorkLoadConfigure : IEntityTypeConfiguration<WorkLoads>
    {
        private const string TableName = "cd_workload";

        public void Configure(EntityTypeBuilder<WorkLoads> builder)
        {
            builder.HasKey(t => t.Id).HasName($"pk_{TableName}_WorkLoad_id");

            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Load).HasColumnName("Load");

            builder.ToTable(TableName).HasOne(x=>x.Teachers).WithMany().HasForeignKey(x=>x.TeacherId)
                .HasConstraintName("fk_teacher_id");
            builder.ToTable(TableName).HasOne(x => x.Disciplines).WithMany().HasForeignKey(x => x.DisciplineId)
                .HasConstraintName("fk_disciple_id");

            builder.Navigation(x => x.Disciplines).AutoInclude();
            builder.Navigation(x=>x.Teachers).AutoInclude();
        }
    }
}
