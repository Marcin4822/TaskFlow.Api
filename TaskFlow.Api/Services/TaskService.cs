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

        public List<TaskItem> GetTasks()
        {
            return _repository.GetAll();
        }

        public TaskItem? GetTask(int id)
        {
            return _repository.GetById(id);
        }

        public TaskItem CreateTask(string name, string? description)
        {
            var taskItem = new TaskItem(name, description);
            _repository.Add(taskItem);

            return taskItem;
        }

        public void UpdateTaskPartially(int id, string? name, string? description, short? effort, TaskState? state)
        {
            var task = _repository.GetById(id);

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
        }

        public void UpdateTask(int id, string name, string? description, short? effort, TaskState state)
        {
            var task = _repository.GetById(id);

            if (task == null)
            {
                throw new TaskNotFoundException(id);
            }

            task.Update(name, description, effort, state);
        }

        public void DeleteTask(int id)
        {
            var task = _repository.GetById(id);

            if (task == null)
            {
                throw new TaskNotFoundException(id);
            }

            _repository.Delete(task);
        }
       
    }
}
