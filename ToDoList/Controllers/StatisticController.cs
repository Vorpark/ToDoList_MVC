using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoList.DAL.Repository.IRepository;
using ToDoList.Domain.ViewModels;

namespace ToDoList.Controllers
{
    public class StatisticController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public StatisticController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var taskList = _unitOfWork.Task.GetAll().Where(x => x.DayEntityId != null);
            var dayList = _unitOfWork.Day.GetAll();
            StatisticVM statisticVM = new()
            {
                TaskList = taskList,
                DayList = dayList
            };
            return View(statisticVM);
        }
    }
}
