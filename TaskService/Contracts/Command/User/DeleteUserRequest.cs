using MediatR;

namespace TaskService.Contracts.Command.User
{
    public class DeleteUserRequest: IRequest<DeleteUserResponse>
    {
        public Guid UserId { get; set; }    
    }
}




