
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Domain.Entity
{
    public class DayEntity
    {
        public int DayEntityId { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым")]
        public string Notes { get; set; }

        [ValidateNever]
        public IEnumerable<TaskEntity> TaskList { get; set; }
    }
}
