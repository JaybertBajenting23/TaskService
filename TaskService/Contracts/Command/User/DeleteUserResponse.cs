namespace TaskService.Contracts.Command.User
{
    public class DeleteUserResponse
    {
        public bool IsDeleted {  get; set; }
        public string ResponseMsg {  get; set; }    
    }
}
