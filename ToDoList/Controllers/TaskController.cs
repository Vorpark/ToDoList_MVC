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
            //���������� �������� ������
            return RedirectToAction("Index", "Task");
        }
    }
}
