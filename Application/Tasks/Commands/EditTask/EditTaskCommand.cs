using MediatR;
using TaskList.Domain.DTO.Responses.Task;

namespace TaskList.Application.Tasks.Commands.EditTask
{
    public class EditTaskCommand : IRequest<EditTaskDTO>
    {
        public EditTaskCommand(string taskdescription,
            DateTime dateadded,
            DateTime dateending,
            DateTime datedone,
            bool isdone)
        {
            TaskDescription = taskdescription;
            DateAdded = dateadded;
            DateEnding = dateending;
            DateDone = datedone;
            IsDone= isdone;
        }
        public Guid ID { get; set; }
        public string? TaskDescription { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateEnding { get; set; }

        public DateTime DateDone { get; set; }

        public bool IsDone { get; set; }
    }
}


