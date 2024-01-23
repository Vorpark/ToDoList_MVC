using ToDoList.DAL.Data;
using ToDoList.DAL.Repository.IRepository;
using ToDoList.Domain.Entity;

namespace ToDoList.DAL.Repository
{
    public class DayRepository : Repository<DayEntity>, IDayRepository
    {
        private readonly ApplicationDbContext _db;
        public DayRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(DayEntity day)
        {
            _db.Days.Update(day);
        }
    }
}
