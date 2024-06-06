using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Core.ViewModel
{
    public class TaskerViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsCompleted { get; set; }

    }
}
