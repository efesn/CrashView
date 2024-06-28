namespace CrashView.Data
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
