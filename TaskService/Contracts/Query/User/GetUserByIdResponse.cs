using TaskService.Contracts.Entities;

namespace TaskService.Contracts.Query.User
{
    public class GetUserByIdResponse
    {
        public UserDTO User { get; set; }

        public bool isSuccess {  get; set; }    
    }
}
