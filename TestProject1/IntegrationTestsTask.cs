using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using TaskList.Application.Tasks.Commands.CreateTask;
using TaskList.Domain.Entities.Task;
using System.Net;
using TaskList;
using TaskList.Application.Tasks.Queries.GetTask;
using TaskList.Application.Tasks.Queries.GetTasks;
using TaskList.Application.Tasks.Commands.EditTask;

namespace TestProject1
{
    public class IntegrationTestsTask
    {
        public IntegrationTestsTask(WF factory) : base(factory)
        {
        }
        private WF _factory = null!;
        private ApplicationContext _context = null!;
        private HttpClient _client = null!;

        [Fact]
        public async System.Threading.Tasks.Task Expect_Create_Task()
        {
            var command = new CreateTaskCommand()
            { TaskDescription = "test",
                DateAdded = DateTime.UtcNow,
                DateEnding = DateTime.UtcNow,
            };

            var response = await _client.PostAsync("api/TaskController", command);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async System.Threading.Tasks.Task Get_AllTasks_ReturnsOk()
        {               
            var response = await _client.GetAsync("api/TaskController", new GetTasksQuery());

            response.StatusCode.Should().NotBeNull();           
        }

        
        [Fact]
        public async System.Threading.Tasks.Task GetById_ExistingTask_ReturnsOk()
        {
            var response = await _client.GetAsync("/api/TaskController/824a7a65-b769-4b70-bccb-91f880b6ddf1");
           
            response.Should().NotBeNull();
            response.Id.Should().NotBe(Task.Empty);
            response.TaskDescription.Should().NotBeNull();
            response.DateAdded.Should().NotBeNull();
        }

        [Fact]
        public async System.Threading.Tasks.Task Update_Task_Returns_Ok()
        {

            var newTask = new EditTaskCommand()
            {
                TaskDescription = "testttttt",              

            };
            var response = await _client.PutAsync("/api/TaskController/824a7a65-b769-4b70-bccb-91f880b6ddf1", new EditTaskCommand());
          
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }


    }
    }