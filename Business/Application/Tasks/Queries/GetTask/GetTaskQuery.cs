using MediatR;
using TaskList.Domain.Entities.Task;

namespace TaskList.Application.Tasks.Queries.GetTask
{
    public class GetTaskQuery : IRequest<GetTaskDTO>
    {
        public GetTaskQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}
}
