using MediatR;
using TaskList.Domain.DTO.Responses.Task;
using Microsoft.EntityFrameworkCore;
using TaskList.Domain.Entities.Task;
using TaskList.Application.Tasks.Queries.GetTasks;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace TaskList.Application.Tasks.Queries.GetTasks
{
    public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, IList<GetTaskDTO>>
    {
        private readonly ApplicationContext _context;
        private readonly IDistributedCache _cache;

        public GetTasksQueryHandler(ApplicationContext context, IDistributedCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<IList<GetTaskDTO>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.Task.Task> tasks = null;
            List<GetTaskDTO> taskList = null;
            var tasksString = await _cache.GetStringAsync(request.ToString(), cancellationToken);
            if (tasksString != null) taskList = JsonSerializer.Deserialize<List<GetTaskDTO>>(tasksString);

            if (tasks == null)
            {
                tasks = await _context.Tasks.ToListAsync(cancellationToken);
                if (tasks != null)                   
                    foreach (var taskItem in tasks)
                    {
                        var task = taskItem.MapTo();
                        taskList.Add(task);
                    }
                else
                {
                    tasksString = JsonSerializer.Serialize(tasks);
                    await _cache.SetStringAsync(taskList.ToString(), tasksString, new DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
                    }, cancellationToken);
                }
            }           
            return taskList;           
        }
    }
}
