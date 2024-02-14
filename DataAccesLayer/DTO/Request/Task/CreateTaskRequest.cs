namespace TaskList.Domain.DTO.Request.Task
{
    public class CreateTaskRequest
    {
        public string? TaskDescription { get; set; }

        public DateTime DateEnding { get; set; }

    }
}
