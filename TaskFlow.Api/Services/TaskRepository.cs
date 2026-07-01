using Microsoft.EntityFrameworkCore;
using TaskFlow.Api.Data;
using TaskFlow.Api.Models;

namespace TaskFlow.Api.Services
{
    public class TaskRepository
    {
        private readonly TaskDbContext _dbContext;

        public TaskRepository(TaskDbContext context)
        {
            _dbContext = context;
        }

        public Task<List<TaskItem>> GetAllAsync()
        {
            return _dbContext.Tasks.ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(int id)
        {
            return await _dbContext.Tasks.FindAsync(id);
        }

        public async Task AddAsync(TaskItem task)
        {
            _dbContext.Tasks.Add(task);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TaskItem task)
        {
            _dbContext.Tasks.Remove(task);
            await _dbContext.SaveChangesAsync();

        }

        public async Task UpdateAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
