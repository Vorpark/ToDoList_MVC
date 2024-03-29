﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ToDoList.Domain.Entity;

namespace ToDoList.Domain.ViewModels
{
    public class TaskVM
    {
        [ValidateNever]
        public TaskEntity Task { get; set; }

        [ValidateNever]
        public DayEntity Day { get; set; }

        [ValidateNever]
        public IEnumerable<TaskEntity> TaskUnDoneList { get; set; }

        [ValidateNever]
        public IEnumerable<TaskEntity> TaskDoneList { get; set; }
    }
}
