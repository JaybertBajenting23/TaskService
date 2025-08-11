using MediatR;
using TaskService.Contracts.Command.TaskModel;
using TaskService.Data.Abstract;



namespace TaskService.Core.Handler.TaskModels
{
    public class UpdateTaskHandler : IRequestHandler<UpdateTaskRequest, UpdateTaskResponse>
    {

        private readonly ILogger<UpdateTaskHandler> logger;
        private readonly ITaskModelRepository taskModelRepository;

        public UpdateTaskHandler(ILogger<UpdateTaskHandler> logger, ITaskModelRepository taskModelRepository)
        {
            this.logger = logger;
            this.taskModelRepository = taskModelRepository;
        }

        
        public async Task<UpdateTaskResponse> Handle(UpdateTaskRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var task = await taskModelRepository.GetTaskById(request.TaskId);
                if (task == null) return null;

                var updatedTask = request.UpdateTaskDTO;

                if (!string.IsNullOrEmpty(updatedTask.Title))
                    task.Title = updatedTask.Title;

                if (!string.IsNullOrEmpty(updatedTask.Description))
                    task.Description = updatedTask.Description;

                if (updatedTask.DueDate != default)
                    task.DueDate = updatedTask.DueDate;

                if (updatedTask.Priority != default)
                    task.Priority = updatedTask.Priority;

                if (updatedTask.Status != default)
                    task.Status = updatedTask.Status;

                if (updatedTask.AssignedUserId.HasValue)
                    task.AssignedUserId = updatedTask.AssignedUserId.Value;


                if (updatedTask.CompletedAt.HasValue)
                    task.CompletedAt = updatedTask.CompletedAt.Value;

                await taskModelRepository.UpdateTask(task);

                return new UpdateTaskResponse { IsSuccess = true, ResponseMsg = "Task Updated!" };

            }
            catch (Exception ex)
            {
                logger.LogError($"Error with message {ex.Message}");
                throw;
            }
        }

       
        




    }
}
