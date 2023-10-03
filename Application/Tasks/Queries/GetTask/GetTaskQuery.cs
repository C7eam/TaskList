using MediatR;
using TaskList.Domain.Entities.Task;

namespace TaskList.Application.Tasks.Queries.GetTask
{
    public class GetTaskQuery : IRequest<GetTaskDTO>
    {
        public GetTaskQuery(Guid id)
    {
        ID = id;
    }

    public Guid ID { get; set; }
}
}
