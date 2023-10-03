using MediatR;
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

        public async Task<DeleteTaskDTO> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = _applicationContext.Tasks.FirstOrDefault(p => p.ID == request.ID);

            if (task is null)
                return default;

            _applicationContext.Remove(task);
            await _applicationContext.SaveChangesAsync();
            return new DeleteTaskDTO(task.ID);
        }
    }
}