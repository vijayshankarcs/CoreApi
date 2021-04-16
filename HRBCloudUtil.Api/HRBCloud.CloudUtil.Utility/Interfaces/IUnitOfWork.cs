using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRBCloud.CloudUtil.Utility.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}
