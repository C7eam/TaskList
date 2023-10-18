using TaskList.Domain.Entities.Task;
using Task = TaskList.Domain.Entities.Task.Task;

namespace TaskList.Application.Tasks.Commands.CreateTask
{
    public static class CreateTaskCommandExtensions
    {
        public static Task CreateTask(this CreateTaskCommand command)
        {
            var task = new Task
                (
                    command.TaskDescription,                   
                    command.DateAdded,
                    command.DateEnding
                );

            return task;
        }
    }
}
