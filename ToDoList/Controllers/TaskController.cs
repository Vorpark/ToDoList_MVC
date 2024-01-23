using Microsoft.AspNetCore.Mvc;
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
                TempData["success"] = "������ ������� �������.";
                return RedirectToAction("Index", "Task");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Perform(int? id)
        {
            //���������� ���������� ������
            return RedirectToAction("Index", "Task");
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            //���������� ���������� ������
            return RedirectToAction("Index", "Task");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var taskToBeDeleted = _unitOfWork.Task.Get(x => x.Id == id);
            if(taskToBeDeleted != null)
            {
                _unitOfWork.Task.Remove(taskToBeDeleted);
                _unitOfWork.Save();
                TempData["success"] = "������ ������� �������.";
            }
            else
            {
                TempData["error"] = "������ �� ����� �������� ������.";
            }
            return RedirectToAction("Index", "Task");
        }

        [HttpPost]
        public IActionResult EndDay(TaskVM obj)
        {
            //���������� ��������� ���
            return RedirectToAction("Index", "Task");
        }
    }
}
