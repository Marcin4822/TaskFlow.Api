using TaskFlow.Api.Models;

namespace TaskFlow.Api.Services
{
    public class TaskRepository
    {
        private readonly List<TaskItem> _tasks = [];

        // IEnumerable or IReadOnlyList
        public List<TaskItem> GetAll()
        {
            return [.._tasks];
        }

        public TaskItem? GetById(int id)
        {
            return _tasks.Find((task) => task.Id == id);
        }

        public void Add(TaskItem task)
        {
            _tasks.Add(task);
        }

        public void Delete(TaskItem task)
        {
            _tasks.Remove(task);

        }
    }
}
