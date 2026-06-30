using Microsoft.EntityFrameworkCore;
using TaskFlow.Api.Models;

namespace TaskFlow.Api.Data
{
    // główny punkt kontraktu z bazą danych
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {

        }

        // DbSet to reprezentacja tabeli w bazie danych, w tym przypadku tabeli "Tasks" przechowującej obiekty typu TaskItem
        public DbSet<TaskItem> Tasks { get; set;  }
    }
}
