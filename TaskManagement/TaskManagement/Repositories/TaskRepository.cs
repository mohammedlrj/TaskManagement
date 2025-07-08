using Microsoft.EntityFrameworkCore;
using TaskManagement.Models;

namespace TaskManagement.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<MyTask> CreateTaskAsync(MyTask task)
        {
            _context.MyTasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<MyTask> UpdateTaskAsync(MyTask task)
        {
            _context.MyTasks.Update(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<MyTask> GetTaskByIdAsync(string id)
        {
            return await _context.MyTasks.FindAsync(id);
        }

        public async Task<IEnumerable<MyTask>> GetAllTasksAsync()
        {
            return await _context.MyTasks.ToListAsync();
        }

        public async Task<bool> DeleteTaskAsync(string id)
        {
            var task = await _context.MyTasks.FindAsync(id);
            if (task == null)
            {
                return false;
            }

            _context.MyTasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
