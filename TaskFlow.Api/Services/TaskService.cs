using TaskFlow.Api.Exceptions;
using TaskFlow.Api.Models;

namespace TaskFlow.Api.Services
{
    public class TaskService
    {
        private readonly TaskRepository _repository;
        public TaskService(TaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TaskItem>> GetTasksAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TaskItem?> GetTaskAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<TaskItem> CreateTaskAsync(string name, string? description)
        {
            var taskItem = new TaskItem(name, description);
            await _repository.AddAsync(taskItem);

            return taskItem;
        }

        public async Task UpdateTaskPartiallyAsync(int id, string? name, string? description, short? effort, TaskState? state)
        {
            var task = await _repository.GetByIdAsync(id);

            if (task == null)
            {
                throw new TaskNotFoundException(id);
            }

            // TODO: Improve PATCH handling to distinguish between omitted properties and explicit null values.
            task.Update(
                name ?? task.Name,
                description ?? task.Description,
                effort ?? task.Effort,
                state ?? task.State);

            await _repository.UpdateAsync();
        }

        public async Task UpdateTaskAsync(int id, string name, string? description, short? effort, TaskState state)
        {
            var task = await _repository.GetByIdAsync(id);

            if (task == null)
            {
                throw new TaskNotFoundException(id);
            }

            task.Update(name, description, effort, state);
            await _repository.UpdateAsync();
        }

        public async Task DeleteTaskAsync(int id)
        {
            var task = await _repository.GetByIdAsync(id);

            if (task == null)
            {
                throw new TaskNotFoundException(id);
            }

            await _repository.DeleteAsync(task);
        }
       
    }
}
