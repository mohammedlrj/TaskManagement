using TaskManagement.Enums;

namespace TaskManagement.Models
{
    public class MyTask
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime? Created { get; set; }
        public Status Status { get; set; }
    }
}
