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

        public void Add(TaskItem taskItem)
        {
            _tasks.Add(taskItem);
        }

        public void Update(TaskItem taskItem)
        {
            // Intentionally empty.
        }

        public void Delete(int id)
        {
            var taskToRemove = GetById(id);

            if (taskToRemove != null)
            {
                _tasks.Remove(taskToRemove);
            }
        }
    }
}
