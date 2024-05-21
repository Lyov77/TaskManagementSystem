using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.BLL.Abstract
{
    public interface IRepositoryManager
    {
        int Commit();
        Task<int> CommitAsync();
    }
}
