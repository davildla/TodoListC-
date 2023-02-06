namespace TodoList.API.Models.Domain
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }

        // Navigation Properties
        public User User { get; set; }
    }
}
