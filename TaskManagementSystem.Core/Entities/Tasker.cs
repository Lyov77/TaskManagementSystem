using System.ComponentModel.DataAnnotations;
using TaskManagementSystem.Core.Entities.Base;

namespace TaskManagementSystem.Core.Entities
{
    public class Tasker : EntityBase
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public required string UserId { get; set; }
    }
}
