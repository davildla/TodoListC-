namespace TodoList.API.Models.Domain
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public Guid UrgencyId { get; set; }


        // Navigation Properties
        public User User { get; set; }
        public Urgency Urgency { get; set; }
    }
}
