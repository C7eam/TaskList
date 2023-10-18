using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskList.Application.Tasks.Commands.DeleteTask;
using TaskList.Domain.DTO.Responses.Task;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TaskList.Application.Tasks.Commands.EditTask
{
    public class EditTaskCommandHandler : IRequestHandler<EditTaskCommand, EditTaskDTO>
    {
        private readonly ApplicationContext _applicationContext;

        public EditTaskCommandHandler(ApplicationContext applicationContext)
        {
            this._applicationContext = applicationContext;
        }

        public async Task<EditTaskDTO> Handle(EditTaskCommand request, CancellationToken cancellationToken)
        {
            var task = _applicationContext.Tasks.FirstOrDefault(t => t.Id == request.Id);

            if (task is null)
            {
                return default;
            }
            else
            {                             
                await _applicationContext.Tasks
                    .Where(p => p.Id == request.Id)
                    .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.TaskDescription, request.TaskDescription)
                    .SetProperty(b => b.DateDone, b => request.DateDone)
                    .SetProperty(b => b.DateEnding, b => request.DateEnding)
                    .SetProperty(b => b.IsDone, b => request.IsDone), cancellationToken);
                await _applicationContext.SaveChangesAsync(cancellationToken);
                return new EditTaskDTO(task);
            }
        }
    }
}
