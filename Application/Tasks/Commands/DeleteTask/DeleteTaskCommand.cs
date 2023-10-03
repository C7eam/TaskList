using MediatR;
using TaskList.Domain.DTO.Responses.Task;

namespace TaskList.Application.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommand : IRequest<DeleteTaskDTO>
    {
        public DeleteTaskCommand(Guid id) 
        {
            ID = id;
        }
        public Guid ID { get; set; }
    }
}
