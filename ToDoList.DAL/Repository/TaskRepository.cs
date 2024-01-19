using ToDoList.DAL.Data;
using ToDoList.DAL.Repository.IRepository;
using ToDoList.Domain.Entity;

namespace ToDoList.DAL.Repository
{
    public class TaskRepository : Repository<TaskEntity>, ITaskRepository
    {
        private readonly ApplicationDbContext _db;
        public TaskRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(TaskEntity task)
        {
            _db.Tasks.Update(task);
        }
    }
}
