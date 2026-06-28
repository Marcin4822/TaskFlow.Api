using Microsoft.AspNetCore.Mvc;
using TaskFlow.Api.Contracts.Requests;
using TaskFlow.Api.Contracts.Responses;
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
        public ActionResult<IEnumerable<TaskResponse>> GetTasks()
        {
            var tasks = _taskService.GetTasks();

            var response = tasks.Select(task => new TaskResponse(
                task.Id,
                task.Name,
                task.Description,
                task.Effort,
                task.State
                ));

            return Ok(response);

        }

        [HttpGet("{id:int}")]
        public ActionResult<TaskResponse> GetTask(int id)
        {
            var task = _taskService.GetTask(id);

            if (task == null)
            {
                return NotFound();
            }

            var response = new TaskResponse(task.Id, task.Name, task.Description, task.Effort, task.State);

            return Ok(response);
        }

        [HttpPost]
        public ActionResult<TaskResponse> CreateTask(CreateTaskRequest request)
        {
            var task = _taskService.CreateTask(
                request.Name, 
                request.Description
             );

            var response = new TaskResponse(
                task.Id, 
                task.Name, 
                task.Description, 
                task.Effort, 
                task.State
             );

            return CreatedAtAction(
                nameof(GetTask),
                new { id = response.Id },
                response
            );
        }


    }
}
