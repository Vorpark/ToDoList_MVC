using ToDoList.DAL.Data;
using ToDoList.DAL.Repository.IRepository;

namespace ToDoList.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public ITaskRepository Task {  get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Task = new TaskRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
