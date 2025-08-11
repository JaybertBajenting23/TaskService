using TaskService.Contracts.Entities;

namespace TaskService.Contracts.Query.User
{
    public class GetAllUsersResponse
    {

        public List<UserDTO> Users { get; set; }
        public bool IsSuccess {  get; set; }    
    }
}


