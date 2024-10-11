using WebApplication1.Database;

namespace WebApplication1.Models
{
    public class Facultys
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? TeacherId { get; set; }
        public Teachers? Teacher { get; set; }
    }
}
