﻿using MediatR;
using TaskList.Domain.DTO.Responses.Task;

namespace TaskList.Application.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommand : IRequest<DeleteTaskDTO>
    {
        public DeleteTaskCommand(Guid id) 
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
