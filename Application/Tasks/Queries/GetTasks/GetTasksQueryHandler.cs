using MediatR;
using TaskList.Domain.DTO.Responses.Task;
using Microsoft.EntityFrameworkCore;
using TaskList.Domain.Entities.Task;
using TaskList.Application.Tasks.Queries.GetTasks;

namespace TaskList.Application.Tasks.Queries.GetTasks
{
    public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, IList<GetTaskDTO>>
    {
        private readonly ApplicationContext _context;

        public GetTasksQueryHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IList<GetTaskDTO>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _context.Tasks.ToListAsync();
            var taskList = new List<GetTaskDTO>();
            foreach (var taskItem in tasks)
            {
                var task = taskItem.MapTo();
                taskList.Add(task);
            }

            return taskList;
        }
    }
}
