using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.DAL.Entities;

namespace TaskManagementSystem.Core.ViewModel
{
    public class UserViewModel
    {
        [Required]
        public string Login { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;

        public virtual ICollection<Tasker> Tasks { get; set; } = [];
    }
}
