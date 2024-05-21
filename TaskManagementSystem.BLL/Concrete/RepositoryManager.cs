using TaskManagementSystem.BLL.Abstract;
using TaskManagementSystem.DAL.Context;

namespace TaskManagementSystem.BLL.Concrete
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly TaskerApplicationDbContext _context;

        public RepositoryManager(TaskerApplicationDbContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}

