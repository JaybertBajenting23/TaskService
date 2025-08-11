using System.Runtime.CompilerServices;
using AutoMapper;
using MediatR;
using TaskService.Contracts.Entities;
using TaskService.Contracts.Query.User;
using TaskService.Data.Abstract;

namespace TaskService.Core.Handler.Users
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
    {

        private readonly ILogger<GetUserByIdHandler> logger;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        public GetUserByIdHandler(ILogger<GetUserByIdHandler> logger, IUserRepository userRepository, IMapper mapper) 
        {
            this.logger = logger;
            this.userRepository = userRepository;
            this.mapper = mapper;   
        }

       

        public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await userRepository.GetUserById(request.UserId);
                if (user == null) return null;
                var userDTO = mapper.Map<UserDTO>(user);
                return new GetUserByIdResponse { User = userDTO, isSuccess = true };
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to Fetch User with Message {ex.Message}");
                throw;
            }

        }

    }
}
