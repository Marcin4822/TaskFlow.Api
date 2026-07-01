using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
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
        public async Task<ActionResult<IEnumerable<TaskResponse>>> GetTasks()
        {
            var tasks = await _taskService.GetTasksAsync();

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
        public async Task<ActionResult<TaskResponse>> GetTaskAsync(int id)
        {
            var task = await _taskService.GetTaskAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            var response = new TaskResponse(task.Id, task.Name, task.Description, task.Effort, task.State);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<TaskResponse>> CreateTask(CreateTaskRequest request)
        {
            var task = await _taskService.CreateTaskAsync(
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
                nameof(GetTaskAsync),
                new { id = response.Id },
                response
            );
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult> UpdateTaskPartially(int id, PatchTaskRequest request)
        {
            await _taskService.UpdateTaskPartiallyAsync(id, request.Name, request.Description, request.Effort, request.State);

            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateTask([Range(1, int.MaxValue)] int id, UpdateTaskRequest request)
        {
            await _taskService.UpdateTaskAsync(id, request.Name, request.Description, request.Effort, request.State);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            await _taskService.DeleteTaskAsync(id);

            return NoContent();
        }


    }
}
