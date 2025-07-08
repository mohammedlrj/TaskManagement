using TaskManagement.DTO;
using TaskManagement.Models;

namespace TaskManagement.Services
{
    public interface ITaskService
    {
        Task<MyTask> CreateTaskAsync(CreateTaskDTO dto);
        Task<IEnumerable<MyTask>> GetAllTasksAsync();
        Task<MyTask> UpdateTaskAsync(string id, CreateTaskDTO dto);
        Task<bool> DeleteTaskAsync(string id);
        Task<MyTask> GetTaskByIdAsync(string id);
    }
}
