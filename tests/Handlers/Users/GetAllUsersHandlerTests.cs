using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Castle.Core.Logging;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using TaskService.Contracts.Query.User;
using TaskService.Core.Handler.Users;
using TaskService.Data.Abstract;
using TaskService.Data.Models;

namespace tests.Handlers.Users
{
    public class GetAllUsersHandlerTests
    {

        private readonly Mock<ILogger<GetAllUsersHandler>> logger;

        private readonly Mock<IMapper> mockMapper;

        private readonly Mock<IUserRepository> mockUserRepository;


        private readonly GetAllUsersHandler handler;


        public GetAllUsersHandlerTests()
        {
            logger = new Mock<ILogger<GetAllUsersHandler>>();
            mockMapper = new Mock<IMapper>();
            mockUserRepository = new Mock<IUserRepository>();

            handler = new GetAllUsersHandler(logger.Object, mockMapper.Object, mockUserRepository.Object);
        }




        //[Theory, AutoFixtureNoRecursion]
        //public async Task Handle_Get_All_Users_Success()
        //{



        //    var users = new List<User> { new User { Id = Guid.NewGuid(), Name ="Jake"},
        //        new User{Id = Guid.NewGuid(), Name = "Jaybert" } }.AsQueryable();

        //    //Arrange
        //    mockUserRepository.Setup(x => x.GetAllUsers()).ReturnsAsync(users);

        //    //Act

        //    var result = await handler.Handle(new GetAllUsersRequest { }, CancellationToken.None);




       

        //    //Assert
        //    result.IsSuccess.Should().BeTrue();
        //    result.Users.Should().NotBeEmpty();

        //    //Verify
        //    mockUserRepository.Verify(x => x.GetAllUsers(), Times.Once());
        //}






    }
}
