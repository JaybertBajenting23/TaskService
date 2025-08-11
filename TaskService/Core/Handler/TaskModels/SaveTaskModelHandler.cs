using AutoMapper;
using MediatR;
using TaskService.Contracts.Command.TaskModel;
using TaskService.Data.Abstract;
using TaskService.Data.Models;

namespace TaskService.Core.Handler.TaskModels
{
    public class SaveTaskModelHandler : IRequestHandler<SaveTaskModelRequest, SaveTaskModelResponse>

    {

        private readonly ILogger<SaveTaskModelHandler> logger;

        private readonly IMapper mapper;

        private readonly ITaskModelRepository taskModelRepository;


        public SaveTaskModelHandler(ILogger<SaveTaskModelHandler> logger, IMapper mapper, ITaskModelRepository taskModelRepository)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.taskModelRepository = taskModelRepository;

        }

        public async Task<SaveTaskModelResponse> Handle(SaveTaskModelRequest request, CancellationToken cancellationToken)
        {
            try
            {

                var taskModel = mapper.Map<TaskModel>(request.CreateTaskDTO);
                await taskModelRepository.SaveTask(taskModel);
                return new SaveTaskModelResponse { IsSuccess = true, ResponseMsg = "Task Added Successfully" };
            }
            catch (Exception ex)
            {
                logger.LogError($"Error with {ex.Message}");
                throw;
            }

        }
    }
}
