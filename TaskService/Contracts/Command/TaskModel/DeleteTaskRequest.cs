using MediatR;

namespace TaskService.Contracts.Command.TaskModel
{
    public class DeleteTaskRequest: IRequest<DeleteTaskRespose>
    {
        public Guid TaskId {  get; set; }
    }
}
