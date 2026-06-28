


namespace TaskFlow.Api.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public short Effort { get; set; }
        public TaskState State { get; set; }


        public TaskItem(string name, string description)
        {
            Name = name;
            Description = description;
            State = TaskState.ToDo;
        }
    }
}
