using TaskService.Data.Models;

namespace TaskService.Data.Abstract
{
    

    public interface IUserRepository
    {
        Task<IQueryable<User>> GetAllUsers();
        Task<User> GetUserById(Guid id);

        Task SaveUser(User user);

        Task UpdateUser(User user);

        Task DeleteUser(User user);
    
        
         
    }
}


