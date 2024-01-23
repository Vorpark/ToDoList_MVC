namespace ToDoList.DAL.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ITaskRepository Task {  get; }
        IDayRepository Day { get; }
        void Save();
    }
}
