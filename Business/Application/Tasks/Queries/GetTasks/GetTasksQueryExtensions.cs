using MediatR;
using TaskList.Domain.DTO.Responses.Task;
using TaskList.Domain.Entities.Task;

namespace TaskList.Application.Tasks.Queries.GetTasks
{
    public static class GetTasksQueryExtensions
    {
        public static GetTaskDTO MapTo(this Domain.Entities.Task.Task task)
        {
            return new GetTaskDTO
            {
            Id = task.Id,
            TaskDescription = task.TaskDescription,
            DateAdded = task.DateAdded,
            DateEnding = task.DateEnding,
            DateDone = task.DateDone,
            IsDone = task.IsDone
            };
        }
    }
}
