namespace TaskFlow.Api.Exceptions
{
    public class TaskNotFoundException : Exception

    {
        public TaskNotFoundException(int taskId) : base($"task with {taskId} was not found")
        {
            
        }
    }
}
