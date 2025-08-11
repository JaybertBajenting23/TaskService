namespace TaskService.Contracts.Entities
{
    public class CreateUserDTO
    {
        public string Name {  get; set; }
        public string Email { get; set; }
        public DateTime CreateadAt { get; set; }
    }
}
