namespace TodoList.API.Models.DTO
{
    public class UpdateTodoRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }
    }
}
