


namespace TaskFlow.Api.Models
{
    public class TaskItem
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public short? Effort { get; private set; }
        public TaskState State { get; private set; }


        public TaskItem(string name, string? description)
        {
            Name = name;
            Description = description;
            State = TaskState.ToDo;
        }

        public void Update(string name, string? description, short? effort, TaskState state)
        {
            Name = name;
            Description = description;
            Effort = effort;
            State = state;
        }
    }
}
