using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using TaskService.Contracts.Command;
using TaskService.Contracts.Command.User;
using TaskService.Contracts.Entities;
using TaskService.Core.Handler.Users;
using TaskService.Data.Abstract;
using TaskService.Data.Models;

namespace tests.Handlers.Users
{
    public class UpdateUserHandlerTest
    {

        private readonly Mock<ILogger<UpdateUserHandler>> logger;
        private readonly Mock<IUserRepository> mockRepository;
        private readonly UpdateUserHandler handler;


        public UpdateUserHandlerTest()
        {
            logger = new Mock<ILogger<UpdateUserHandler>>();
            mockRepository = new Mock<IUserRepository>();
            handler = new UpdateUserHandler(logger.Object, mockRepository.Object);
        }


        //No [Theory, AutoData]
        //[Fact]
        //public async Task Handle_With_Valid_Update_Success()
        //{


        //    //Arrange

        //    var userId = Guid.NewGuid();



        //    var user = new User { Id = userId, Name = "Test User", Email = "Test Email" };
        //    var updateUserDTO = new UpdateUserDTO { Name = "UpdatedUser", Email = "Test Email" };
        //    var request = new UpdateUserRequest { UserId = userId, UpdateUserDTO = updateUserDTO };


        //    mockRepository.Setup(x => x.GetUserById(userId)).ReturnsAsync(user);
        //    mockRepository.Setup(x => x.UpdateUser(It.IsAny<User>())).Returns(Task.CompletedTask);
        //    //Act

        //    var result = await handler.Handle(request, CancellationToken.None);



        //    //Assert

        //    result.IsSuccess.Should().BeTrue();
        //    result.ResponseMsg.Should().Be("User Updated Successfully"    ;


        //    //Verify Interactions
        //    mockRepository.Verify(x => x.UpdateUser(It.Is<User>(u =>
        //         u.Id == userId &&
        //         u.Name == "UpdatedUser" &&
        //         u.Email == "updated@email.com"

        //    )), Times.Once());


        //}

   
[Theory, AutoFixtureNoRecursion]
public async Task Handle_WithValidUpdate_ShouldUpdateSuccessfully(
    User user, // Auto-generated
    UpdateUserDTO updateUserDTO) // Auto-generated
{
    // Arrange
    var request = new UpdateUserRequest { UserId = user.Id, UpdateUserDTO = updateUserDTO };
    
    mockRepository.Setup(x => x.GetUserById(user.Id)).ReturnsAsync(user);
    mockRepository.Setup(x => x.UpdateUser(It.IsAny<User>())).Returns(Task.CompletedTask);

    // Act & Assert
    var result = await handler.Handle(request, CancellationToken.None);
    result.IsSuccess.Should().BeTrue();


    

}


    }
}
