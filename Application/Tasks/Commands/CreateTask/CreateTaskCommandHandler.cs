using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskList.Domain.DTO.Responses.Task;

namespace TaskList.Application.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandHandler :IRequestHandler<CreateTaskCommand, CreateTaskDTO>
    {
        private readonly ApplicationContext _applicationContext;

        public CreateTaskCommandHandler(ApplicationContext applicationContext)
        {
            this._applicationContext = applicationContext;
        }

        public async Task<CreateTaskDTO> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = request.CreateTask();
            await _applicationContext.Tasks.AddAsync(task);
            await _applicationContext.SaveChangesAsync();

            return new CreateTaskDTO(task.ID);
        }
    }
}
