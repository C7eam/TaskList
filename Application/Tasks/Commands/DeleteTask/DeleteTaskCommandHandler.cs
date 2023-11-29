using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskList.Domain.DTO.Responses.Task;

namespace TaskList.Application.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, string>
    {
        private readonly ApplicationContext _applicationContext;

        public DeleteTaskCommandHandler(ApplicationContext applicationContext)
        {
            this._applicationContext = applicationContext;
        }

        public async Task<string> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var task = (_applicationContext.Tasks.FirstOrDefaultAsync(x => x.Id == request.Id));
                
                    await _applicationContext.Tasks.Where(p => p.Id == request.Id).ExecuteDeleteAsync(cancellationToken);                   
            }
                 
            catch (Exception exp)
            {
                throw (new ApplicationException(exp.Message));
            }
            
              return "Task has been deleted";
            
        }
    }
}