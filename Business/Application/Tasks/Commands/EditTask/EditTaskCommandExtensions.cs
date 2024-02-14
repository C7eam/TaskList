using System.Runtime.CompilerServices;
using TaskList.Application.Tasks.Commands.DeleteTask;
using Task = TaskList.Domain.Entities.Task.Task;

namespace TaskList.Application.Tasks.Commands.EditTask
{
    public static class EditTaskCommandExtensions
    {
        public static Task EditTask(this EditTaskCommand command)
        {
            var task = new Task
                (                 
            command.TaskDescription,
            command.DateEnding,
            command.DateDone,
            command.IsDone
                );

            return task;
        }
    }
}
