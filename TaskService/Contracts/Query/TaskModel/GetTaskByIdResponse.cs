using TaskService.Contracts.Entities;

namespace TaskService.Contracts.Query.TaskModel
{
    public class GetTaskByIdResponse
    {
        public TaskModelDTO Task {  get; set; }
        public bool IsSuccess {  get; set; }
    }
}
 