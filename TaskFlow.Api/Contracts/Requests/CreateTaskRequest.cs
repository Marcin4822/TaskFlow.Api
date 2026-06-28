using System.ComponentModel.DataAnnotations;

namespace TaskFlow.Api.Contracts.Requests
{
    public class CreateTaskRequest
    {
        [Required(ErrorMessage = "Nie można utworzyć zadania bez nazwy")]
        [MinLength(3, ErrorMessage = "Nazwa nie może mieć mniej niż 3 znaki")]
        [MaxLength(100, ErrorMessage = "Nazwa nie mozę mieć więcej niż 100 znaków")]
        public required string Name { get; set; }

        [MaxLength(1000, ErrorMessage = "Opis nie może mieć więcej niż 1000 znaków")]
        public string? Description { get; set; }
    }
}
