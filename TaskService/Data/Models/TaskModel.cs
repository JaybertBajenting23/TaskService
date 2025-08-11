using TaskService.Contracts.Enums;
using TaskStatus = TaskService.Contracts.Enums.TaskStatus;

namespace TaskService.Data.Models
{
    public class TaskModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public TaskPriority Priority { get; set; }
        public TaskStatus Status { get; set; }

        public Guid? AssignedUserId { get; set; }

        public User AssignedUser { get; set; }

        public DateTime CreatedAt { get; set; } 
        public DateTime? CompletedAt { get; set; }
    }
}
