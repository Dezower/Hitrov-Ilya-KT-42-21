namespace WebApplication1.Models
{
    public class WorkLoads
    {
        public int Id { get; set; }
        public int TeacherId {  get; set; }
        public int DisciplineId { get; set; }
        public int Load {  get; set; }
        public Teachers? Teachers { get; set; }
        public Disciplines? Disciplines { get; set; }
    }
}
