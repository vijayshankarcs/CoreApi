using HRBCloud.CloudUtil.Data.Data;
using HRBCloud.CloudUtil.Data.Entities;
using HRBCloud.CloudUtil.Entity.ViewModels;
using HRBCloud.CloudUtil.Helpers.Helper;
using HRBCloud.CloudUtil.Utility.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRBCloud.CloudUtil.Utility.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<AppUserDto> GetUserByIdAsync(long id)
        {
            var user = await _context.tbleUsers.FindAsync(id);
            var rtUser = new AppUserDto()
            {
                EmailId = user.EmailId,
                Id = user.Id,
                UserName = user.UserName
            };
            return rtUser;
        }

        public async Task<AppUserDto> GetUserByUsernameAsync(string username)
        {

            var user = await _context.tbleUsers.SingleOrDefaultAsync(x => x.EmailId == username);
            var rtUser = new AppUserDto()
            {
                EmailId = user.EmailId,
                Id = user.Id,
                UserName = user.UserName
            };
            return rtUser;
        }
        public async Task<PageList<AppUserDto>> GetUsersAsync(UserParams userParams)
        {
            var user = (from userlist in await _context.tbleUsers.ToListAsync() select userlist)
                   .Select(p => (AppUserDto)p).ToList().AsQueryable();

            return await PageList<AppUserDto>.CreateAsync(user, userParams.PageNumber, userParams.PageSize);
        }
        public void Update(AppUserDto user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}
