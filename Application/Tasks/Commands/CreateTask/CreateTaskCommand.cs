﻿using MediatR;
using TaskList.Domain.DTO.Responses.Task;

namespace TaskList.Application.Tasks.Commands.CreateTask
{
    public class CreateTaskCommand : IRequest<CreateTaskDTO>
    {
        public CreateTaskCommand(string taskDescription, DateTime dateAdded, DateTime dateEnding)
        {
            TaskDescription = taskDescription;
            DateAdded = dateAdded;
            DateEnding = dateEnding;
        }

        public string TaskDescription { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime? DateEnding { get; set; }

        public DateTime? DateDone { get; set; }

        public bool IsDone { get; set; } = false;
    }
}