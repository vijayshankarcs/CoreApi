
using HRBCloud.CloudUtil.Data.Entities;
using HRBCloud.CloudUtil.Entity.ViewModels;
using HRBCloud.CloudUtil.Helpers.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRBCloud.CloudUtil.Utility.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUserDto user);
        //Task<bool> SaveAllAsync();
        Task<PageList<AppUserDto>> GetUsersAsync(UserParams userParams);
        Task<AppUserDto> GetUserByIdAsync(long id);
        Task<AppUserDto> GetUserByUsernameAsync(string username);
    }
}
