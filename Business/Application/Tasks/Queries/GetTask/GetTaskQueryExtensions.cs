using TaskList.Domain.Entities.Task;
using MediatR;
using TaskList.Domain.DTO.Responses.Task;

namespace TaskList.Application.Tasks.Queries.GetTask
{
    public static class GetTaskQueryExtensions
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
