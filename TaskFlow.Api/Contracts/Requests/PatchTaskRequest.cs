using System.ComponentModel.DataAnnotations;
using TaskFlow.Api.Models;

namespace TaskFlow.Api.Contracts.Requests
{
    public class PatchTaskRequest
    {
        [MinLength(3)]
        [MaxLength(100)]
        public string? Name { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }
        public short? Effort { get; set; }
        public TaskState? State { get; set; }

    }
}
