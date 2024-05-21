using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.DAL.Entities.Base
{
    public abstract class EntityBase : IEntityBase
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    }
}
