using MediatR;
using TaskList.Application.Tasks.Commands.CreateTask;
using TaskList.Domain.DTO.Request.Task;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using TaskList.Application.Tasks.Queries.GetTasks;
using TaskList.Application.Tasks.Queries.GetTask;
using TaskList.Application.Tasks.Commands.DeleteTask;
using TaskList.Domain.DTO.Responses.Task;
using TaskList.Application.Tasks.Commands.EditTask;

namespace TaskList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await _mediator.Send(new GetTasksQuery());

            if (tasks != null)
            {
                return Ok(tasks);
            }

            return NotFound("No tasks in database. Please add a task first.");
        }

        [HttpGet("/gettasks/{id}")]
        public async Task<IActionResult> GetTask(Guid id)
        {
            var task = await _mediator.Send(new GetTaskQuery(id));

            if (task != null)
            {
                return Ok(task);
            }

            return NotFound($"No task in database with ID: {id}.");

        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskRequest request)
        {
            var task = await _mediator.Send(new CreateTaskCommand(
            request.TaskDescription,
            request.DateAdded,
            request.DateEnding,
            request.DateDone,
            request.IsDone));

            return Ok(task);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTask(DeleteTaskDTO request)
        {
            var task = await _mediator.Send(new DeleteTaskCommand(request.ID));

            if (task != null)
            {
                return Ok(DeleteTask(request));
            }
            return NotFound($"No task in database with ID: {request.ID}.");
        }

        [HttpPatch("/edittask/{id}")]
        public async Task<IActionResult> EditTask([FromBody] EditTaskRequest request)
        {
            var task = await _mediator.Send(new EditTaskCommand(
            request.TaskDescription,
            request.DateAdded,
            request.DateEnding,
            request.DateDone,
            request.IsDone));
            return Ok(task);
        }
    }
}
