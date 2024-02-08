using MediatR;
using TaskList.Application.Tasks.Commands.CreateTask;
using TaskList.Domain.DTO.Request.Task;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskList.Application.Tasks.Queries.GetTasks;
using TaskList.Application.Tasks.Queries.GetTask;
using TaskList.Application.Tasks.Commands.DeleteTask;
using TaskList.Domain.DTO.Responses.Task;
using TaskList.Application.Tasks.Commands.EditTask;
using Microsoft.AspNetCore.Authorization;

namespace TaskList.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<TaskController> _logger;

        public TaskController(IMediator mediator, ILogger<TaskController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasksAsync()
        {
            var tasks = await _mediator.Send(new GetTasksQuery());

            if (tasks != null)
            {
                return Ok(tasks);
            }

            return NotFound("No tasks in database. Please add a task first.");
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetTaskAsync(Guid id)
        {
            var task = await _mediator.Send(new GetTaskQuery(id));

            if (task != null)
            {
                return Ok(task);
            }

            return NotFound($"No task in database with ID: {id}.");

        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskAsync([FromBody] CreateTaskRequest request)
        {
            var task = await _mediator.Send(new CreateTaskCommand(
            request.TaskDescription,
            request.DateEnding
            ));

            return Ok(task);
        }

        [HttpDelete("/{id}")]
        public async Task<IActionResult> DeleteTaskAsync(DeleteTaskDTO request)
        {
            await _mediator.Send(new DeleteTaskCommand(request.Id));

            return Ok();
        }

        [HttpPut("/{id}")]
        public async Task<IActionResult> EditTaskAsync([FromBody] EditTaskRequest request, Guid id)
        {
            var task = await _mediator.Send(new EditTaskCommand(
            id,
            request.TaskDescription,
            request.DateEnding,
            request.DateDone,
            request.IsDone));
            return Ok(task);
        }
    }
}
