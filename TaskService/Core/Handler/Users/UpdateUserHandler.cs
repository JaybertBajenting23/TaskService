using AutoMapper;
using MediatR;
using TaskService.Contracts.Command.User;
using TaskService.Data.Abstract;

namespace TaskService.Core.Handler.Users
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly ILogger<UpdateUserHandler> logger;
        private readonly IUserRepository userRepository;
      

        public UpdateUserHandler(ILogger<UpdateUserHandler> logger, IUserRepository userRepository)
        {
            this.logger = logger;
            this.userRepository = userRepository;
         
        }



        public async Task<UpdateUserResponse> Handle(UpdateUserRequest command, CancellationToken cancellationToken)
        {

            try
            {
                var user = await userRepository.GetUserById(command.UserId);
                if (user == null) return null;
            
                var updatedUser = command.UpdateUserDTO;

                if (!string.IsNullOrEmpty(updatedUser.Name))
                {
                    user.Name = updatedUser.Name;   
                }
                if (!string.IsNullOrEmpty(updatedUser.Email))
                {
                    user.Email  = updatedUser.Email;
                }

               await userRepository.UpdateUser(user);
               return new UpdateUserResponse { IsSuccess = true , ResponseMsg = "User Updated Successfully"};
                 

            } catch (Exception ex)
            {
                logger.LogError($"Error with message {ex.Message}");
                throw;
            }
        }
    }
}
