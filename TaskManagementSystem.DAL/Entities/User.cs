using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.DAL.Entities.Base;

namespace TaskManagementSystem.DAL.Entities
{
    public class User : EntityBase
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }

        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }
        public virtual ICollection<Tasker> Tasks { get; set; } = [];
    }
}
