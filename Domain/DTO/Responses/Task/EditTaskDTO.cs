namespace TaskList.Domain.DTO.Responses.Task
{
    public class EditTaskDTO
    {
        public EditTaskDTO(Guid id)
        {
            ID = id;
        }
        public Guid ID { get; set; }
    }
}
