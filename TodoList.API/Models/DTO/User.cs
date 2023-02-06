namespace TodoList.API.Models.DTO
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }

        // navigation property
        public IEnumerable<Todo> Todos { get; set; }
    }
}
