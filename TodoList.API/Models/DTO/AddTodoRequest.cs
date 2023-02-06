namespace TodoList.API.Models.DTO
{
    public class AddTodoRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public Guid UrgencyId { get; set; }
    }
}
