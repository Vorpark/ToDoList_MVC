using Microsoft.AspNetCore.Mvc;
using ToDoList.DAL.Repository.IRepository;

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
            return View();
        }
    }
}
