using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskService.Contracts.Command.User;
using TaskService.Contracts.Query.User;
using TaskService.Data.Models;

namespace TaskService.Api.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {


        private readonly IMediator mediator;


        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

    
        
       
        [HttpPost]
        [ProducesResponseType(typeof(SaveUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SaveUserResponse>> SaveUser([FromBody] SaveUserRequest request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }

        
        
        
            
         
       
        [HttpDelete("{UserId}")]
        [ProducesResponseType(typeof(DeleteUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DeleteUserResponse>> DeleteUser(Guid UserId)
        {
            var request = new DeleteUserRequest { UserId = UserId };
            var result = await mediator.Send(request);
            return result == null ? NotFound(new { Message = "User Not Found", UserId = UserId }) : Ok(result);
        }



        [HttpGet("{UserId}")]
        [ProducesResponseType(typeof(GetUserByIdResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetUserByIdResponse>> GetUserById(Guid UserId)
        {
            var result = await mediator.Send(new GetUserByIdRequest { UserId = UserId });
            return result == null ? NotFound(new {Message = "User Not Found", UserId = UserId}) : Ok(result);
        }




        [HttpGet("GetAllUsers")]
        [ProducesResponseType(typeof(GetAllUsersResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetAllUsersResponse>> GetAllUsers()
        {
            var result = await mediator.Send(new GetAllUsersRequest());
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(typeof(UpdateUserResponse),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UpdateUserResponse>> UpdateUser([FromBody] UpdateUserRequest request)
        {
            var result = await mediator.Send(request);
            return result == null ? NotFound(new { Message = "User Not Found", UserId = request.UserId}) : Ok(result);
        }



       
    }
}
