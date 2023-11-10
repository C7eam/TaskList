using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskList.Domain.DTO.Responses.Task;

namespace TaskList.Application.Tasks.Commands.DeleteTask
{   
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, DeleteTaskDTO>
    {
        private readonly ApplicationContext _applicationContext;

        public DeleteTaskCommandHandler(ApplicationContext applicationContext)
        {
            this._applicationContext = applicationContext;
        }

        public async Task<DeleteTaskDTO?> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {            
            await _applicationContext.Tasks.Where(p => p.Id == request.Id).ExecuteDeleteAsync(cancellationToken);
            await _applicationContext.SaveChangesAsync(cancellationToken);
            return default;
        }
    }
}