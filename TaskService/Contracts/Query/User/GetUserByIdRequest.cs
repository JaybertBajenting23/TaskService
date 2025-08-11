using MediatR;

namespace TaskService.Contracts.Query.User
{
    public class GetUserByIdRequest: IRequest<GetUserByIdResponse>
    {
        public Guid UserId { get; set; }    
    }
}
