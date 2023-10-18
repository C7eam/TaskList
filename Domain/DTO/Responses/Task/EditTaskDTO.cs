using System.ComponentModel.DataAnnotations;

namespace TaskList.Domain.DTO.Responses.Task
{
    public class EditTaskDTO
    {
        public EditTaskDTO(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
        public EditTaskDTO(Entities.Task.Task task)
        {
        }

        
    }
}