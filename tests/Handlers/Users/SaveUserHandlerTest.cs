using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using AutoMapper;
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
    public class SaveUserHandlerTest
    {

        private readonly Mock<ILogger<SaveUserHandler>> logger;

        private readonly Mock<IUserRepository> mockUserRepository;

        private readonly Mock<IMapper> mockMapper;

        private readonly SaveUserHandler handler;

        public SaveUserHandlerTest()
        {
            logger = new Mock<ILogger<SaveUserHandler>>();
            mockUserRepository = new Mock<IUserRepository>();
            mockMapper = new Mock<IMapper>();
            handler = new SaveUserHandler(logger.Object, mockUserRepository.Object, mockMapper.Object);
        }


        [Theory, AutoFixtureNoRecursion]
        public async Task Handle_SaveUser_Success(User user, SaveUserRequest request)
        {
           
            //Arrange
            mockMapper.Setup(x => x.Map<User>(request.CreateUserDTO)).Returns(user);
            mockUserRepository.Setup(x => x.SaveUser(It.IsAny<User>())).Returns(Task.CompletedTask);
            

            //Act
            var result = await handler.Handle(request,CancellationToken.None);
          
            
                
            
            //Assert
            result.IsSaved.Should().BeTrue();
            result.ResponseMsg.Should().Be("User Saved Successfully");

       
            //Verify
            mockMapper.Verify(x => x.Map<User>(request.CreateUserDTO),Times.Once());
            mockUserRepository.Verify(x => x.SaveUser(It.IsAny<User>()), Times.Once());

        }
        
       
       
    }
}
