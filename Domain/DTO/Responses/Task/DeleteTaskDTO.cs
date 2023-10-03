namespace TaskList.Domain.DTO.Responses.Task
{
    public class DeleteTaskDTO
    {
            public DeleteTaskDTO(Guid id)
            {
                ID = id;
            }
            public Guid ID { get; set; }
    }
}
