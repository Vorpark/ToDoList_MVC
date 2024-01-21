using Microsoft.AspNetCore.Mvc;
using ToDoList.DAL.Repository.IRepository;
using ToDoList.Domain.Entity;

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
            return View();
        }
        [HttpPost]
        public IActionResult Create(TaskEntity obj)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.Task.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Задача успешно создана.";
                return RedirectToAction("Index", "Task");
            }
            return View();
        }
    }
}
