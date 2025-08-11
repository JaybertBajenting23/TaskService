using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using AutoMapper;
using Castle.Core.Logging;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using TaskService.Contracts.Entities;
using TaskService.Contracts.Query;
using TaskService.Contracts.Query.User;
using TaskService.Core.Handler.Users;
using TaskService.Data.Abstract;
using TaskService.Data.Models;


namespace tests.Handlers.Users
{
    public class GetUserByIdHandlerTests
    {

        private readonly Mock<ILogger<GetUserByIdHandler>> _loggerMock;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly GetUserByIdHandler _handler;


        public GetUserByIdHandlerTests()
        {
            _loggerMock = new Mock<ILogger<GetUserByIdHandler>>();
            _userRepositoryMock = new Mock<IUserRepository>();
            _mapperMock = new Mock<IMapper>();
            _handler = new GetUserByIdHandler(_loggerMock.Object, _userRepositoryMock.Object, _mapperMock.Object);
        }


        //No [Theory,AutoData]
        //[Fact]
        //public async Task Handle_WithValidUserId_ReturnsUserResponse()
        //{

        //    //Arrange
        //    var userId = Guid.NewGuid();
        //    var request = new GetUserByIdRequest { UserId = userId };
        //    var userEntity = new User { Id =  userId , Name = "Test User"};
        //    var userDto = new UserDTO { Id = userId, Name = "Test User" };



        //    _userRepositoryMock.Setup(x => x.GetUserById(userId)).ReturnsAsync(userEntity);

        //    _mapperMock.Setup(x => x.Map<UserDTO>(userEntity)).Returns(userDto);



        //    //Act

        //    var result = await _handler.Handle(request,CancellationToken.None);


        //    //Assert
        //    result.Should().NotBeNull();
        //    result.User.Should().BeEquivalentTo(userDto);
        //    result.isSuccess.Should().BeTrue();

        //    _userRepositoryMock.Verify(x => x.GetUserById(userId),Times.Once());
        //    _mapperMock.Verify(x => x.Map<UserDTO>(userEntity), Times.Once());  


        //}





        [Theory, AutoFixtureNoRecursion]
        public async Task Handle_WithValidUserId_ReturnsUserResponse(User user, UserDTO userDTO)
        {

            //Arrange
          
            var request = new GetUserByIdRequest { UserId = user.Id };
            
            _userRepositoryMock.Setup(x => x.GetUserById(user.Id)).ReturnsAsync(user);

            _mapperMock.Setup(x => x.Map<UserDTO>(user)).Returns(userDTO);

            //Act

            var result = await _handler.Handle(request, CancellationToken.None);


            //Assert
            result.Should().NotBeNull();
            result.User.Should().BeEquivalentTo(userDTO);
            result.isSuccess.Should().BeTrue();

            _userRepositoryMock.Verify(x => x.GetUserById(user.Id), Times.Once());
            _mapperMock.Verify(x => x.Map<UserDTO>(user), Times.Once());


        }


    }
}
