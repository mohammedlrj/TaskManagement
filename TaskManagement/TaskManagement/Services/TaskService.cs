using TaskManagement.DTO;
using TaskManagement.Models;
using TaskManagement.Repositories;

namespace TaskManagement.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<MyTask> CreateTaskAsync(CreateTaskDTO dto)
        {
            var task = new MyTask
            {
                Name = dto.Name,
                Description = dto.Description,
                Type = dto.Type,
                Status = Enums.Status.New,
                Created = DateTime.UtcNow
            };

            return await _taskRepository.CreateTaskAsync(task);
        }

        public async Task<MyTask> UpdateTaskAsync(string id, CreateTaskDTO dto)
        {
            var existingTask = await _taskRepository.GetTaskByIdAsync(id);
            if (existingTask == null)
            {
                return null;
            }
            existingTask.Name = dto.Name;
            existingTask.Description = dto.Description;
            existingTask.Type = dto.Type;
            existingTask.Status = dto.Status;

            return await _taskRepository.UpdateTaskAsync(existingTask);
        }

        public async Task<IEnumerable<MyTask>> GetAllTasksAsync()
        {
            return await _taskRepository.GetAllTasksAsync();
        }

        public async Task<bool> DeleteTaskAsync(string id)
        {
            return await _taskRepository.DeleteTaskAsync(id);
        }

        public async Task<MyTask> GetTaskByIdAsync(string id)
        {
            return await _taskRepository.GetTaskByIdAsync(id);
        }
    }
}
