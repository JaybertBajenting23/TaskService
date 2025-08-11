using AutoMapper;
using MediatR;
using TaskService.Contracts.Entities;
using TaskService.Contracts.Query.TaskModel;
using TaskService.Data.Abstract;

namespace TaskService.Core.Handler.TaskModels
{
    public class GetTaskByIdHandler: IRequestHandler<GetTaskByIdRequest,GetTaskByIdResponse>
    {

        private readonly ILogger<GetTaskByIdHandler> logger;
       
        private readonly ITaskModelRepository taskModelRepository;

        private readonly IMapper mapper;

        public GetTaskByIdHandler(ILogger<GetTaskByIdHandler> logger, ITaskModelRepository taskNodelRepository, IMapper mapper)
        {
            this.logger = logger;
            this.taskModelRepository = taskNodelRepository;
            this.mapper = mapper;
        }
        

        public async Task<GetTaskByIdResponse> Handle(GetTaskByIdRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var task = await taskModelRepository.GetTaskById(request.TaskId);
                if (task == null) return null;
                var taskDTO = mapper.Map<TaskModelDTO>(task);
                return new GetTaskByIdResponse { Task =  taskDTO , IsSuccess = true};
            }
            catch (Exception ex)
            {
                logger.LogError($"Error with message {ex.Message}");
                throw;
            }
        }


    }
}
