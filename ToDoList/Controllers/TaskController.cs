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
                TaskList = _unitOfWork.Task.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }),
                Task = new TaskEntity()
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
    }
}
