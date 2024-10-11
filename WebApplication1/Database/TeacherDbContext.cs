using Microsoft.EntityFrameworkCore;
using WebApplication1.Database.Configuration;
using WebApplication1.Models;

namespace WebApplication1.Database
{
    public class TeacherDbContext : DbContext
    {
        
        public TeacherDbContext(DbContextOptions<TeacherDbContext> options) : base(options)
        {

        }

        DbSet<AcademicDegrees> AcademicDegrees { get; set; }

        DbSet<Disciplines> Disciplines { get; set; }

        DbSet<Facultys> facultys { get; set; }

        DbSet<Posts> posts { get; set; }

        DbSet<Teachers> teachers { get; set; }

        DbSet<WorkLoads> workLoads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AcademicDegreesConfigure());

            modelBuilder.ApplyConfiguration(new DisciplineConfigure());

            modelBuilder.ApplyConfiguration(new FacultysConfigure());

            modelBuilder.ApplyConfiguration(new PostConfigure());

            modelBuilder.ApplyConfiguration(new TeachersConfigure());

            modelBuilder.ApplyConfiguration(new WorkLoadConfigure());
        }

        
    }
}
