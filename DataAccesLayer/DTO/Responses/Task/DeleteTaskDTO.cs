namespace TaskList.Domain.DTO.Responses.Task
{
    public class DeleteTaskDTO
    {
        public DeleteTaskDTO(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
