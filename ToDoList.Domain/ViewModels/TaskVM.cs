using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoList.Domain.Entity;

namespace ToDoList.Domain.ViewModels
{
    public class TaskVM
    {
        public TaskEntity Task { get; set; }
        [ValidateNever]
        public IEnumerable<TaskEntity> TaskUnDoneList { get; set; }
        [ValidateNever]
        public IEnumerable<TaskEntity> TaskDoneList { get; set; }
    }
}
