using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Core.ViewModel
{
    public class TaskerViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        [Required]
        public bool IsCompleted { get; set; }

    }
}
