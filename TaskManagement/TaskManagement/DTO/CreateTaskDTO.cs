using TaskManagement.Enums;

namespace TaskManagement.DTO
{
    public class CreateTaskDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public Status Status { get; set; }
    }
}
