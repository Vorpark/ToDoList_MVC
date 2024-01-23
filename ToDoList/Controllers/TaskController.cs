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
            IEnumerable<TaskEntity> taskList = _unitOfWork.Task.GetAll().Where(x => x.DayEntityId == null);
            TaskVM taskVM = new()
            {
                Task = new TaskEntity(),
                TaskUnDoneList = taskList.Where(x => x.IsDone == false),
                TaskDoneList = taskList.Where(x => x.IsDone == true)
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
        public IActionResult Perform(int? id)
        {
            var taskToBePerform = _unitOfWork.Task.Get(x => x.TaskEntityId == id);
            taskToBePerform.IsDone = true;
            if (taskToBePerform != null)
            {
                _unitOfWork.Task.Update(taskToBePerform);
                _unitOfWork.Save();
                TempData["success"] = "Задача успешно выполнена.";
            }
            else
            {
                TempData["error"] = "Ошибка во время выполнения задачи.";
            }
            return RedirectToAction("Index", "Task");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var taskToBeDeleted = _unitOfWork.Task.Get(x => x.TaskEntityId == id);
            if(taskToBeDeleted != null)
            {
                _unitOfWork.Task.Remove(taskToBeDeleted);
                _unitOfWork.Save();
                TempData["success"] = "Задача успешно удалена.";
            }
            else
            {
                TempData["error"] = "Ошибка во время удаления задачи.";
            }
            return RedirectToAction("Index", "Task");
        }

        [HttpPost]
        public IActionResult EndDay(TaskVM obj)
        {
            //if (ModelState.IsValid)
            //{
            //    var day = new DayEntity()
            //    {
            //        Notes = obj.Day.Notes,
            //        TaskDoneList = obj.TaskDoneList
            //    };
            //}
            
            return RedirectToAction("Index", "Task");
        }
    }
}
