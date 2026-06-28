using Microsoft.AspNetCore.Mvc;
using TaskFlow.Api.Contracts.Requests;
using TaskFlow.Api.Models;
using TaskFlow.Api.Services;

namespace TaskFlow.Api.Controllers
{
    [ApiController]
    [Route("tasks")]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }


        [HttpGet]
        public List<TaskItem> GetTasks()
        {
            return _taskService.GetTasks();
        }

        [HttpGet("{id:int}")]
        public TaskItem? GetTask(int id)
        {
            return _taskService.GetTask(id);
        }

        [HttpPost]
        public void CreateTask(CreateTaskRequest request)
        {
            _taskService.CreateTask(
                request.Name, 
                request.Description
             );
        }


    }
}
