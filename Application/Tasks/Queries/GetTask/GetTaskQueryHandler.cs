using MediatR;
using TaskList.Domain.DTO.Responses.Task;
using Microsoft.EntityFrameworkCore;
using TaskList.Domain.Entities.Task;
using TaskList.Application.Tasks.Queries.GetTasks;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace TaskList.Application.Tasks.Queries.GetTask
{
    public class GetTaskQueryHandler : IRequestHandler<GetTaskQuery, GetTaskDTO>
    {
        private readonly ApplicationContext _context;
        private readonly IDistributedCache _cache;

        public GetTaskQueryHandler(ApplicationContext context, IDistributedCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<GetTaskDTO> Handle(GetTaskQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Task.Task? task= null;
            var taskString = await _cache.GetStringAsync(request.Id.ToString(), cancellationToken);
            if (taskString != null) task = JsonSerializer.Deserialize<Domain.Entities.Task.Task>(taskString);

            if (task == null)
            {
                task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
                if (task != null)
                {                    
                    taskString = JsonSerializer.Serialize(task);                    
                    await _cache.SetStringAsync(task.Id.ToString(), taskString, new DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
                    });
                }
            }                   
                return task.MapTo();
        }
    }
}