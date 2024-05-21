using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManagementSystem.DAL.Entities.Base;

namespace TaskManagementSystem.DAL.Entities
{
    public class Tasker : EntityBase
    {
        [Required]
        public string Title {  get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public bool IsCompleted { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User? User { get; set; }

    }
}
