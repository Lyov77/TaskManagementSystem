namespace TaskManagementSystem.BLL.Repositories.Base
{
    public interface IRepositoryManager
    {
        int Commit();
        Task<int> CommitAsync();
    }
}
