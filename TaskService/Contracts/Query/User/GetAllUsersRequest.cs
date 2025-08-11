using MediatR;

namespace TaskService.Contracts.Query.User
{
    public class GetAllUsersRequest: IRequest<GetAllUsersResponse>
    {
    }
}
