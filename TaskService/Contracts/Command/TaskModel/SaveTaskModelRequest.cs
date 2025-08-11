using MediatR;
using TaskService.Contracts.Entities;

namespace TaskService.Contracts.Command.TaskModel
{
    public class SaveTaskModelRequest: IRequest<SaveTaskModelResponse>
    {
        public CreateTaskDTO CreateTaskDTO { get; set; }
    }
}
