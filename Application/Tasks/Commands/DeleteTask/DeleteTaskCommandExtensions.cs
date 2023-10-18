using TaskList.Application.Tasks.Commands.CreateTask;
using Task = TaskList.Domain.Entities.Task.Task;

namespace TaskList.Application.Tasks.Commands.DeleteTask
{
    public static class DeleteTaskCommandExtensions
    {
        public static Task DeleteTask(this DeleteTaskCommand command)
        {
            var task = new Task
                (
                    command.Id
                );

            return task;
        }
    }
}