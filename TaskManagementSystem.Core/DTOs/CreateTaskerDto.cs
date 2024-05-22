using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Core.DTOs
{
    public class CreateTaskerDto
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(1, ErrorMessage = "Title must not be empty")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MinLength(1, ErrorMessage = "Description must not be empty")]
        public string Description { get; set; }
    }
}
