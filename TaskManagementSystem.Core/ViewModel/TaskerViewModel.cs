﻿using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Core.ViewModel
{
    public class TaskerViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public bool IsCompleted { get; set; }
    }
}
