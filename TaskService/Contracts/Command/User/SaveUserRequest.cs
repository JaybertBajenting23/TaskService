using System.ComponentModel.DataAnnotations;
using MediatR;
using TaskService.Contracts.Entities;

namespace TaskService.Contracts.Command.User
{
    public class SaveUserRequest: IRequest<SaveUserResponse>
    {
    
        
            

        
        public CreateUserDTO CreateUserDTO {  get; set; }
            

      
      
        
    }
}
