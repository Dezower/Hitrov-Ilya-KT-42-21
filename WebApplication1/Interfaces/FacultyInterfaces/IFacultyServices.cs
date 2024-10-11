using Microsoft.EntityFrameworkCore;
using WebApplication1.Database;
using WebApplication1.filters.FacultysFilters;
using WebApplication1.Models;

namespace WebApplication1.Interfaces.FacultyInterfaces
{
    public interface IFacultyServices
    {
        public Task<Facultys[]> GetFacultysByNameAsync(FacultesNameFilter filter, CancellationToken cancellationToken);
    }

    public class FacultyServices : IFacultyServices
    {
        private readonly TeacherDbContext _dbcontext;

        public FacultyServices(TeacherDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public Task<Facultys[]> GetFacultysByNameAsync(FacultesNameFilter nameFilter, CancellationToken cancellationToken)
        {
            var facultys = _dbcontext.Set<Facultys>().Where(w=>w.Name==nameFilter.Name).ToArrayAsync(cancellationToken);

            return facultys;
        }
    }
}
