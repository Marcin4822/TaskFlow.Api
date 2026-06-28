using System.ComponentModel.DataAnnotations;

namespace TaskFlow.Api.Contracts.Requests
{
    public class CreateTaskRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
    }
}
