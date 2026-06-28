using TaskFlow.Api.Models;

namespace TaskFlow.Api.Services
{
    public class TaskRepository
    {
        private readonly List<TaskItem> _tasks = [];

        // Teoretycznie tutaj rozwiązaniem jest IEnumerable albo IReadOnlyList
        public List<TaskItem> GetAll()
        {
            //return _tasks; // zwraca referencję do listy, a nie kopię - co jest problemem bo można zrobić _tasks.Clear() albo coś tego typu
            return [.._tasks]; // zwraca kopię listy, a nie referencję do niej
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
