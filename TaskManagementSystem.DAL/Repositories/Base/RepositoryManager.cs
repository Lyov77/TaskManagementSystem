using TaskManagementSystem.BLL.Repositories.Base;
using TaskManagementSystem.DAL.Context;

namespace TaskManagementSystem.DAL.Repositories.Base
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

        public async Task<int> CommitAsync()
        {
            var count = await _context.SaveChangesAsync();
            return count;
        }
    }
}
