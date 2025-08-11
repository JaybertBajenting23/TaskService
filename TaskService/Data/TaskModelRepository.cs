using TaskService.Data.Abstract;
using TaskService.Data.Db;
using TaskService.Data.Models;

namespace TaskService.Data
{
    public class TaskModelRepository : ITaskModelRepository
    {

    
        
        private readonly TaskContext taskContext;

        public TaskModelRepository(TaskContext taskContext)
        {
            this.taskContext = taskContext;
        }

        public Task<string> AssignedTaskToUser(TaskModel task)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteTask(TaskModel taskModel)
        {
           taskContext.Tasks.Remove(taskModel);
           await taskContext.SaveChangesAsync(); 
        }
        

        public Task DeleteTaskById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetAllTasks()
        {
            throw new NotImplementedException();
        }

        public async Task<TaskModel> GetTaskById(Guid id)
        {
            return await taskContext.Tasks.FindAsync(id);
        }

        public async Task SaveTask(TaskModel task)
        {
            await taskContext.Tasks.AddAsync(task);
            await taskContext.SaveChangesAsync();
        }

       
        public async Task UpdateTask(TaskModel task)
        {
            taskContext.Tasks.Update(task);
            await taskContext.SaveChangesAsync();
        }
        

        public Task<string> UpdateTaskStatus(TaskModel task)
        {
            throw new NotImplementedException();
        }

        Task<string> ITaskModelRepository.DeleteTaskById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
