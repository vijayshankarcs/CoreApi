using HRBCloud.CloudUtil.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRBCloud.CloudUtil.Entity.ViewModels
{
    public class AppUserDto
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }

        public static explicit operator AppUserDto(Users model)
        {
            return new AppUserDto
            {
                EmailId = model.EmailId,
                Id = model.Id,
                UserName = model.UserName,
            };
        }
    }
}
