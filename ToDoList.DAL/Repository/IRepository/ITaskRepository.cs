using ToDoList.Domain.Entity;

namespace ToDoList.DAL.Repository.IRepository
{
    public interface ITaskRepository : IRepository<TaskEntity>
    {
        void Update (TaskEntity task);
    }
}
