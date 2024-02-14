namespace TaskList.Domain.DTO.Responses.Task
{
    public class CreateTaskDTO
    {
        public CreateTaskDTO(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
