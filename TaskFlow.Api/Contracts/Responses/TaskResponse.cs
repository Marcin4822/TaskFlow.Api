using TaskFlow.Api.Models;

namespace TaskFlow.Api.Contracts.Responses
{
    public class TaskResponse
    {
        public string Name { get; }
        public string Description { get; }
        public short Effort { get; }
        public TaskState State { get; }
        public int Id { get; }

        public TaskResponse(
            int id, 
            string name, 
            string description, 
            short effort, 
            TaskState state)
        {
            Id = id;
            Name = name;
            Description = description;
            Effort = effort;
            State = State;
        }
    }
}
