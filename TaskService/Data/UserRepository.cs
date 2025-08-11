using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using TaskService.Api.Controllers;
using TaskService.Data.Abstract;
using TaskService.Data.Db;
using TaskService.Data.Models;

namespace TaskService.Data
{
    public class UserRepository : IUserRepository
    {


        private readonly TaskContext taskContext;

        public UserRepository(TaskContext taskContext)
        {
            this.taskContext = taskContext;
        }





        public async Task DeleteUser(User user)
        {
            taskContext.Users.Remove(user);
            await taskContext.SaveChangesAsync();
        }



        public async Task SaveUser(User user)
        {
            await taskContext.Users.AddAsync(user);

            await taskContext.SaveChangesAsync();

        }

        public async Task UpdateUser(User user)
        {
            taskContext.Users.Update(user);
            await taskContext.SaveChangesAsync();
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await taskContext.Users.FindAsync(id);
        }


        public async Task<IQueryable<User>> GetAllUsers()
        {
            return taskContext.Users;
        }


    }
}
