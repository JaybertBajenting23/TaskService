using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Logging;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using TaskService.Contracts.Command.TaskModel;
using TaskService.Core.Handler.TaskModels;
using TaskService.Data.Abstract;
using TaskService.Data.Models;

namespace tests.Handlers.TaskModels
{
    public class DeleteTaskHandlerTest
    {


        private readonly Mock<ILogger<DeleteTaskHandler>> mockLogger;

        private readonly Mock<ITaskModelRepository> mockTaskModelRepository;

        private readonly DeleteTaskHandler handler;

        public DeleteTaskHandlerTest()
        {
            mockLogger = new Mock<ILogger<DeleteTaskHandler>>();
            mockTaskModelRepository = new Mock<ITaskModelRepository>();
            handler = new DeleteTaskHandler(mockLogger.Object,mockTaskModelRepository.Object);
        }

        

        
        [Theory,AutoFixtureNoRecursion]
         public async Task Handle_Delete_Task_Success(TaskModel taskModel)
        {
            
            //Arrange
            var request = new DeleteTaskRequest { TaskId = taskModel.Id };
            mockTaskModelRepository.Setup(x => x.GetTaskById(taskModel.Id)).ReturnsAsync(taskModel);
            mockTaskModelRepository.Setup(x => x.DeleteTask(It.IsAny<TaskModel>())).Returns(Task.CompletedTask);

            //Act
            var result = await handler.Handle(request, CancellationToken.None);

            //Assert
            result.IsDeleted.Should().BeTrue();
            result.ResponseMsg.Should().Be("Task is Deleted!");


            //Verify
            mockTaskModelRepository.Verify(x => x.GetTaskById(taskModel.Id), Times.Once());
            mockTaskModelRepository.Verify(x => x.DeleteTask(It.IsAny<TaskModel>()), Times.Once()); 
        }
    }
}
