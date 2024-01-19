namespace ToDoList.DAL.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ITaskRepository Task {  get; }
        void Save();
    }
}
