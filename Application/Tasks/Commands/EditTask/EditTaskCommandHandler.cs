using MediatR;
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
            var task = _applicationContext.Tasks.Where(a => a.ID == request.ID).FirstOrDefault(); ;

            if (task == null)
            {
                return default;
            }
            else
            {
                task.IsDone = request.IsDone;
                task.TaskDescription = request.TaskDescription;
                task.DateDone = request.DateDone;
                task.DateAdded = request.DateAdded;
                task.DateEnding = request.DateEnding;
                await _applicationContext.SaveChangesAsync();
                return new EditTaskDTO(task.ID);
            }
        }
    }
}
