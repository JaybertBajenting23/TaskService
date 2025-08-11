using AutoMapper;
using MediatR;
using TaskService.Contracts.Command.User;
using TaskService.Data.Abstract;
using TaskService.Data.Models;

namespace TaskService.Core.Handler.Users
{

    public class SaveUserHandler : IRequestHandler<SaveUserRequest, SaveUserResponse>
    {

        private readonly ILogger<SaveUserHandler> logger;

        private readonly IUserRepository userRepository;

        private readonly IMapper mapper;

        public SaveUserHandler(ILogger<SaveUserHandler> logger, IUserRepository userRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.userRepository = userRepository;
        }



        public async Task<SaveUserResponse> Handle(SaveUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = mapper.Map<User>(request.CreateUserDTO);
                await userRepository.SaveUser(user);
                return new SaveUserResponse { IsSaved = true, ResponseMsg = "User Saved Successfully" };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while saving user");
                throw;
            }

        }
    }

}
