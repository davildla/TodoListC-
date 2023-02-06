using TodoList.API.Models.Domain;

namespace TodoList.API.Models.DTO
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }

    }
}
