using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoList.Domain.Enum;

namespace ToDoList.Domain.Entity
{
    public class TaskEntity
    {
        public long TaskEntityId { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым")]
        public string Name { get; set; }

        public bool IsDone { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым")]
        public string Description { get; set; }

        [Required]
        public DateTime CreationTime { get; set; }

        [Required]
        public Priority Priority { get; set; }

        [ValidateNever]
        public int? DayEntityId { get; set; }
        [ForeignKey("DayEntityId")]
        [ValidateNever]
        public DayEntity DayEntity { get; set; }
    }
}
