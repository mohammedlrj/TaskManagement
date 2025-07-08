using TaskManagement.Models;

namespace TaskManagement.Repositories
{
    public interface ITaskRepository
    {
        Task<MyTask> CreateTaskAsync(MyTask task);
        Task<IEnumerable<MyTask>> GetAllTasksAsync();
        Task<MyTask> GetTaskByIdAsync(string id);
        Task<MyTask> UpdateTaskAsync(MyTask task);
        Task<bool> DeleteTaskAsync(string id);
    }
}
