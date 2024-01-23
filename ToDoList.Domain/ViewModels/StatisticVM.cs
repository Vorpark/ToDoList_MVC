using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ToDoList.Domain.Entity;

namespace ToDoList.Domain.ViewModels
{
    public class StatisticVM
    {
        [ValidateNever]
        public IEnumerable<TaskEntity> TaskList { get; set; }

        [ValidateNever]
        public IEnumerable<DayEntity> DayList { get; set; }
    }
}
