using TaskManagement.Enums;

namespace TaskManagement.DTO
{
    public class TaskDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime? Created { get; set; }
        public Status Status { get; set; }
    }
}
