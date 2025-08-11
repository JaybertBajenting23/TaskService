using MediatR;
using TaskService.Contracts.Entities;

namespace TaskService.Contracts.Command.TaskModel
{
    public class UpdateTaskRequest: IRequest<UpdateTaskResponse>
    {
           public Guid TaskId { get; set; }
           public UpdateTaskDTO UpdateTaskDTO { get; set; }
    }
}
