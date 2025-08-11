using System.Text.Json.Serialization;

namespace TaskService.Data.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }

        [JsonIgnore]
        public ICollection<TaskModel> Tasks { get; set; }
            
        
        

    }
}
