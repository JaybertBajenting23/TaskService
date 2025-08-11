using TaskService.Data.Models;

namespace TaskService.Data.Abstract
{
    public interface ITaskModelRepository
    {


        Task<string> GetAllTasks();
        Task <TaskModel> GetTaskById(Guid id);
        
        Task SaveTask(TaskModel task);   

        Task<string> DeleteTaskById(Guid id);

        Task UpdateTask(TaskModel task);    


        Task<string> UpdateTaskStatus(TaskModel task);  

        Task<string> AssignedTaskToUser(TaskModel task);

        Task DeleteTask(TaskModel taskModel);
                         
    }
}
