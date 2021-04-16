using HRBCloud.CloudUtil.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRBCloud.CloudUtil.Utility.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(Users user);
    }
}
