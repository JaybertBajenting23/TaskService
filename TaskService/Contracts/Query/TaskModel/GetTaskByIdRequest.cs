using MediatR;

namespace TaskService.Contracts.Query.TaskModel
{
    public class GetTaskByIdRequest: IRequest<GetTaskByIdResponse>  
    {
        public Guid TaskId { get; set; }    
    }
}
