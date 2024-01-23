using ToDoList.Domain.Entity;

namespace ToDoList.DAL.Repository.IRepository
{
    public interface IDayRepository : IRepository<DayEntity>
    {
        void Update(DayEntity day);
    }
}
