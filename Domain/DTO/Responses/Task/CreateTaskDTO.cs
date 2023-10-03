namespace TaskList.Domain.DTO.Responses.Task
{
    public class CreateTaskDTO
    {
        public CreateTaskDTO(Guid id) 
        {
            ID = id;
        }
        public Guid ID { get; set; }
    }
}
