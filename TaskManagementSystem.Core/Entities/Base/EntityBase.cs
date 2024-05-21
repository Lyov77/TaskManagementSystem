using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Core.Entities.Base
{
    public abstract class EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
