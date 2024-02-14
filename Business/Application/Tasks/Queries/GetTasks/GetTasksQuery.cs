using MediatR;
using TaskList.Domain.DTO.Responses.Task;
using TaskList.Domain.Entities.Task;

namespace TaskList.Application.Tasks.Queries.GetTasks
{
    public class GetTasksQuery : IRequest<IList<GetTaskDTO>>
    {
    }
}
