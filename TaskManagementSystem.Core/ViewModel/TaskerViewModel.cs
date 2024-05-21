using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManagementSystem.DAL.Entities;

namespace TaskManagementSystem.Core.ViewModel
{
    public class TaskerViewModel
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public bool IsCompleted { get; set; }

        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
    }
}
