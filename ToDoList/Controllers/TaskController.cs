using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoList.DAL.Repository.IRepository;
using ToDoList.Domain.Entity;
using ToDoList.Domain.ViewModels;

namespace ToDoList.Controllers
{
    public class TaskController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TaskController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            TaskVM taskVM = new()
            {
                Task = new TaskEntity(),
                TaskList = _unitOfWork.Task.GetAll()
            };
            return View(taskVM);
        }

        [HttpPost]
        public IActionResult Create(TaskVM obj)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.Task.Add(obj.Task);
                _unitOfWork.Save();
                TempData["success"] = "Задача успешно создана.";
                return RedirectToAction("Index", "Task");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            //Реализация обновления задачи
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            //Реализация удаления задачи
            return View();
        }

        [HttpPost]
        public IActionResult EndDay(TaskVM obj)
        {
            //Реализация окончания дня
            return View();
        }
    }
}
