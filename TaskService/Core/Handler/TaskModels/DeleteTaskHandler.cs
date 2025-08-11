using AutoMapper;
using MediatR;
using TaskService.Contracts.Command.TaskModel;
using TaskService.Data.Abstract;

namespace TaskService.Core.Handler.TaskModels
{
    public class DeleteTaskHandler: IRequestHandler<DeleteTaskRequest,DeleteTaskRespose>
    {
        private readonly ILogger<DeleteTaskHandler> logger;

        private readonly ITaskModelRepository taskModelRepository;


        public DeleteTaskHandler(ILogger<DeleteTaskHandler> logger, ITaskModelRepository taskModelRepository)
        {
            this.logger = logger;
            this.taskModelRepository = taskModelRepository;

        }

    

        public async Task<DeleteTaskRespose> Handle(DeleteTaskRequest request, CancellationToken cancellationToken)
        {
   
            try
            {
                var task = await taskModelRepository.GetTaskById(request.TaskId);
                if (task == null) return null;
                await taskModelRepository.DeleteTask(task);
                return new DeleteTaskRespose { IsDeleted = true , ResponseMsg = "Task is Deleted!"};

            }catch(Exception ex)
            {
                logger.LogError($"Error with {ex.Message}");
                throw;
            }
        }

    }
}
