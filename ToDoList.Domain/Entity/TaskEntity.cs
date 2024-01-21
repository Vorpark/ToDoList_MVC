using System.ComponentModel.DataAnnotations;
using ToDoList.Domain.Enum;

namespace ToDoList.Domain.Entity
{
    public class TaskEntity
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым")]
        public string Name { get; set; }

        public bool IsDone { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым")]
        public string Description { get; set; }

        [Required]
        public DateTime CreationTime { get; set; } = DateTime.Now;

        [Required]
        public Priority Priority { get; set; }
    }
}
