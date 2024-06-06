using TaskManagementSystem.Core.DTOs;
using TaskManagementSystem.Core.ViewModel;

namespace TaskManagementSystem.Core.Extensions
{
    public static class TaskMapper
    {
        public static TaskerViewModel MapToViewModel(CreateTaskerDto createTaskerDto)
        {

            if (createTaskerDto == null)
            {
                return null;
            }
            return new TaskerViewModel
            {
                Id = Guid.NewGuid(),
                Title = createTaskerDto.Title,
                Description = createTaskerDto.Description,
                IsCompleted = createTaskerDto.IsCompleted,
            };
        }

        public static TaskerViewModel MapToViewModel(TaskerDto taskerDto)
        {
            if (taskerDto == null)
            {
                return null;
            }

            return new TaskerViewModel
            {
                Id = taskerDto.Id,
                Title = taskerDto.Title,
                Description = taskerDto.Description,
                IsCompleted = taskerDto.IsCompleted,
            };
        }
    }
}
