namespace WebApplication1.Models
{
    public class Teachers
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Patronomical {  get; set; }
        public int? DegreeId { get; set; }
        public int? PostId { get; set; }
        public int? FacultyId { get; set; }
        public string? PhoneNumber { get; set; }
        public Posts? Posts { get; set; }
        public AcademicDegrees? AcademicDegrees { get; set; }
        public Facultys? Facultys { get; set; }
    }
}
