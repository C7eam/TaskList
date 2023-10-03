namespace TaskList.Domain.DTO.Request.Task
{
    public class EditTaskRequest
    {
        public EditTaskRequest(string? taskDescription, DateTime dateAdded, DateTime dateEnding, DateTime dateDone, bool isDone)
        {
            TaskDescription = taskDescription;
            DateAdded = dateAdded;
            DateEnding = dateEnding;
            DateDone = dateDone;
            IsDone = isDone;
        }

        public string? TaskDescription { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateEnding { get; set; }

        public DateTime DateDone { get; set; }

        public bool IsDone { get; set; }
        public Guid ID { get; set; }
    }
}
