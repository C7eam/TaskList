using System.ComponentModel.DataAnnotations;

namespace TaskList.Domain.Entities.Task
{
    public class Task
    {
        public Task() { }

        public Task(Guid id)
        {
            Id = id;
        }

        public Task(string taskDescription, DateTime? dateEnding)
        {
            TaskDescription = taskDescription;
            DateEnding = dateEnding;
        }

        public Task(string taskDescription, DateTime dateAdded, DateTime? dateEnding)
        {
            TaskDescription = taskDescription;
            DateAdded = dateAdded;
            DateEnding = dateEnding;
        }

        public Task(string taskDescription, DateTime? dateEnding, DateTime? dateDone, bool isDone)
        {
            TaskDescription = taskDescription;
            DateEnding = dateEnding;
            DateDone = dateDone;
            IsDone = isDone;
        }

        public Task(string taskDescription, DateTime dateAdded, DateTime? dateEnding, DateTime? dateDone, bool isDone)
        {
            TaskDescription = taskDescription;
            DateAdded = dateAdded;
            DateEnding = dateEnding;
            DateDone = dateDone;
            IsDone = isDone;
        }
        
        public Guid Id { get; set; }
        [Required, StringLength(250)]
        public string TaskDescription { get; set; }
        [Required]
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;

        public DateTime? DateEnding { get; set; }

        public DateTime? DateDone { get; set; }

        public bool? IsDone { get; set; } = false;
    }
}
