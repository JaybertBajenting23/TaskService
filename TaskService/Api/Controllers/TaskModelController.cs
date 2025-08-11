using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using TaskService.Contracts.Command.TaskModel;
using TaskService.Contracts.Query.TaskModel;
using TaskService.Data.Models;

namespace TaskService.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TaskModelController: ControllerBase
    {
            
        private readonly IMediator mediator;


        public TaskModelController(IMediator mediator)
        {
            this.mediator = mediator;
        }

       

        [HttpPost]
        [ProducesResponseType(typeof(SaveTaskModelResponse),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        
        public async Task<ActionResult<SaveTaskModelResponse>> SaveTaskModel([FromBody] SaveTaskModelRequest request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }


        
        [HttpGet("{TaskId}")]
        [ProducesResponseType(typeof(GetTaskByIdResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetTaskByIdResponse>> GetTaskById(Guid TaskId)
        {
            var request = new GetTaskByIdRequest { TaskId = TaskId };
            var result = await mediator.Send(request);
            return result == null ? NotFound(new {Message = "Task Not Found", TaskId = TaskId}): Ok(result);
        }



        [HttpDelete("{taskId}")]
        [ProducesResponseType(typeof(DeleteTaskRespose),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DeleteTaskRespose>> DeletTask(Guid taskId)
        {
            var request = new DeleteTaskRequest { TaskId = taskId };
            var result = await mediator.Send(request);
            return result == null ? NotFound(new {Message = "Task Not Found",  taskId = taskId}) : Ok(result);
        }
        

    }
}
