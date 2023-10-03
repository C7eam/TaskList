using MediatR;
using TaskList.Domain.DTO.Responses.Task;
using Microsoft.EntityFrameworkCore;
using TaskList.Domain.Entities.Task;
using TaskList.Application.Tasks.Queries.GetTasks;

namespace TaskList.Application.Tasks.Queries.GetTask
{
    public class GetTaskQueryHandler : IRequestHandler<GetTaskQuery, GetTaskDTO>
    {
        private readonly ApplicationContext _context;

        public GetTaskQueryHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<GetTaskDTO> Handle(GetTaskQuery request, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks.Where(x => x.ID == request.ID).FirstOrDefaultAsync();

            if (task != null)
            {
                var taskItem = task.MapTo();
                return taskItem;
            }
            return null;
        }
    }
}