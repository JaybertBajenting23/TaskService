using AutoMapper;
using MediatR;
using TaskService.Contracts.Command.User;
using TaskService.Data.Abstract;

namespace TaskService.Core.Handler.Users
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
    {

        private readonly ILogger<DeleteUserHandler> logger;

        private readonly IUserRepository userRepository;

        

        public DeleteUserHandler(ILogger<DeleteUserHandler> logger, IUserRepository userRepository)
        {
            this.logger = logger;
            this.userRepository = userRepository;
        }
             
       public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await userRepository.GetUserById(request.UserId);
                if (user == null) return null;
                await userRepository.DeleteUser(user);

                return new DeleteUserResponse { IsDeleted = true, ResponseMsg = "User Deleted"};
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to Delete with Error {ex.Message}");
                throw;
            }
        }
    }
}


