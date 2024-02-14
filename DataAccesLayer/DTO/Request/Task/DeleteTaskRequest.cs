namespace TaskList.Domain.DTO.Request.Task
{
    public class DeleteTaskRequest
    {
        public string? TaskDescription { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateEnding { get; set; }

        public DateTime DateDone { get; set; }

        public bool IsDone { get; set; }
    }
}
