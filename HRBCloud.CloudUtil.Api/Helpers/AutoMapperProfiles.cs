using AutoMapper;
using HRBCloud.CloudUtil.Data.Entities;
using HRBCloud.CloudUtil.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRBCloud.CloudUtil.Api.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Users, AppUserDto>().ReverseMap();
        }
    }
}
