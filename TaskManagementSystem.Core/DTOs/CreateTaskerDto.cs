namespace TaskManagementSystem.Core.DTOs
{
    public class CreateTaskerDto
    {
        public string UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
