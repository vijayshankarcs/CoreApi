using System.Threading.Tasks;
using HRBCloud.CloudUtil.Data.Data;
using HRBCloud.CloudUtil.Data.Entities;
using HRBCloud.CloudUtil.Entity.ViewModels;
using HRBCloud.CloudUtil.Utility.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRBCloud.CloudUtil.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;

        public AccountController(DataContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }
        /// <summary>
        /// Resgister new user 
        /// </summary>
        /// <param name="registerDto"></param>
        /// <returns>user details</returns>
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.EmailId)) return BadRequest("EmailId Exists");

            var user = new Users
            {
                EmailId = registerDto.EmailId.ToLower(),
                UserName = registerDto.Username.ToLower()
            };
            _context.tbleUsers.Add(user);
            await _context.SaveChangesAsync();

            return new UserDto
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }
        /// <summary>
        ///User Login
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns>Token</returns>
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _context.tbleUsers
                .SingleOrDefaultAsync(x => x.EmailId == loginDto.EmailId);

            if (user == null) return Unauthorized("Invalid Username");

            return new UserDto
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }
        private async Task<bool> UserExists(string EmailId)
        {
            return await _context.tbleUsers.AnyAsync(x => x.EmailId == EmailId.ToLower());
        }
        //private async Task<IEnumerable<ApplicationInfo>> BuildApplicationInfoAsync(UserAssertion userAssertion)
        //{
        //    //_logger.LogDebugStart();
        //    var appRoles = await _graphServiceClient.Me
        //                        .AppRoleAssignments
        //                        .Request()
        //                        .GetAsync()
        //                        .ConfigureAwait(false);

        //    var applications = new List<ApplicationInfo>();
        //    if (applications == null)
        //    {
        //        //_logger.LogWarning($"Not able to get applications for current user.");
        //        //_logger.LogDebugEnd();
        //        return applications;
        //    }

        //    foreach (AppRoleAssignment assignment in appRoles.CurrentPage)
        //    {
        //        var appInfo = BuildApplicationInfo(assignment);
        //        applications.Add(appInfo);
        //    }
        //    //_logger.LogDebugEnd();
        //    return applications;
        //}
    }
}