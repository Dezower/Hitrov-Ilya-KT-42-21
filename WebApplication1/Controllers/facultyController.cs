using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.filters.FacultysFilters;
using WebApplication1.Interfaces.FacultyInterfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class facultyController : ControllerBase
    {
        private readonly ILogger<facultyController> _logger;
        private readonly IFacultyServices _facultyServices;

        public facultyController(ILogger<facultyController> logger, IFacultyServices facultyServices)
        {
            _logger = logger;
            _facultyServices = facultyServices;
        }

        [HttpPost(Name = "GetFacultysByName")]
        public async Task<IActionResult> GetFacultysByNameAsync(FacultesNameFilter filter, CancellationToken cancellationToken = default)
        {
            var facultys = await _facultyServices.GetFacultysByNameAsync(filter, cancellationToken);

            return Ok(facultys);
        }
    }
}
