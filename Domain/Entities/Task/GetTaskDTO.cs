namespace TaskList.Domain.Entities.Task
{
    public class GetTaskDTO
    {
        public Guid ID { get; set; }

        public string? TaskDescription { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateEnding { get; set; }

        public DateTime DateDone { get; set; }

        public bool IsDone { get; set; }
    }
}
