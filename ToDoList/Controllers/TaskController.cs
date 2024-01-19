using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            //Реализация создания задачи
            return RedirectToAction("Index", "Task");
        }
    }
}
