using MediatR;
using TaskService.Contracts.Entities;

namespace TaskService.Contracts.Command.User
{
    public class UpdateUserRequest: IRequest<UpdateUserResponse>
    {
        public Guid UserId { get; set; }
        public UpdateUserDTO UpdateUserDTO { get; set; }
    }
}
