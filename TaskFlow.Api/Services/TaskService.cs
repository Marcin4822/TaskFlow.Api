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

        public TaskItem CreateTask(string name, string description)
        {
            var taskItem = new TaskItem(name, description);
            _repository.Add(taskItem);

            // ten task item ma już id?
            return taskItem;
        }

        //public void UpdateTask(int id, string name, string description, short effort, TaskState state)
        //{
        //}
       
    }
}
