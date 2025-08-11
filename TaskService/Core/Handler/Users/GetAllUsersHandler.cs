using System.Runtime.CompilerServices;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskService.Contracts.Entities;
using TaskService.Contracts.Query.User;
using TaskService.Data.Abstract;

namespace TaskService.Core.Handler.Users
{
    public class GetAllUsersHandler: IRequestHandler<GetAllUsersRequest,GetAllUsersResponse>
    {
        

        
        private readonly ILogger<GetAllUsersHandler> logger;

        private readonly IMapper mapper;

        private readonly IUserRepository userRepository;

            
        
        public GetAllUsersHandler(ILogger<GetAllUsersHandler> logger, IMapper mapper, IUserRepository userRepository)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.userRepository = userRepository;
        }
    
        
      
   
        
        public async Task<GetAllUsersResponse> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            try
            {
                
                var queryable = await userRepository.GetAllUsers();

                var users = await queryable.ProjectTo<UserDTO>(mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
        
                return new GetAllUsersResponse { Users = users, IsSuccess = true };
            }
            catch (Exception ex)
            {
                logger.LogError($"Error with error {ex.Message}");
                throw;
            }

        }

      
    }
}
