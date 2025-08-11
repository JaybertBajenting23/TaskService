using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Logging;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using TaskService.Contracts.Command.User;
using TaskService.Core.Handler.Users;
using TaskService.Data.Abstract;
using TaskService.Data.Models;

namespace tests.Handlers.Users
{
    public class DeleteUserHandlerTests
    {
        private readonly Mock<ILogger<DeleteUserHandler>> mockLogger;
        private readonly Mock<IUserRepository> mockUserRepository;

        private readonly DeleteUserHandler handler;
            
      

        
       

        public DeleteUserHandlerTests()
        {
            mockLogger = new Mock<ILogger<DeleteUserHandler>>();
            mockUserRepository = new Mock<IUserRepository>();
            handler = new DeleteUserHandler(mockLogger.Object,mockUserRepository.Object);
        }
    
        [Theory,AutoFixtureNoRecursion]
        public async Task Handle_With_Delete_Success(User user)
        {
            
            //Arrange
        
            var request = new DeleteUserRequest { UserId = user.Id };
            mockUserRepository.Setup(x => x.GetUserById(user.Id)).ReturnsAsync(user);
            mockUserRepository.Setup(x => x.DeleteUser(It.IsAny<User>())).Returns(Task.CompletedTask);
            
            
            
            //Act
            var result = await handler.Handle(request,CancellationToken.None);
                


            //Assert
            result.IsDeleted.Should().BeTrue();
            result.ResponseMsg.Should().Be("User Deleted");
            

            //Verify            
            mockUserRepository.Verify(x => x.GetUserById(user.Id),Times.Once());
            mockUserRepository.Verify(x => x.DeleteUser(It.IsAny<User>()), Times.Once());

        }
           
    }
}
