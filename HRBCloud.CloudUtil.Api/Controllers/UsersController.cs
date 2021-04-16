using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRBCloud.CloudUtil.Data.Entities;
using HRBCloud.CloudUtil.Entity.ViewModels;
using HRBCloud.CloudUtil.Helpers.Helper;
using HRBCloud.CloudUtil.Utility.Interfaces;
using HRBCloud.CloudUtil.Helpers.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRBCloud.CloudUtil.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Get Application User List
        /// </summary>
        /// <returns>All Application User List</returns>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<AppUserDto>>> GetUsers([FromQuery]UserParams userParams)
        {
            //return await _context.tbleUsers.Select(x => (AppUserModel)x).ToListAsync();
            //return Ok(await _unitOfWork.UserRepository.GetUsersAsync(userParams));

            var users = await _unitOfWork.UserRepository.GetUsersAsync(userParams);
            Response.AddPaginationHeader(users.CurrentPage, users.PageSize, users.TotalCount, users.TotalPages);
            return Ok(users);
        }
        /// <summary>
        /// Get Application User by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>user</returns>
        ///api/users/2
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUserDto>> GetUser(long id)
        {
            return await _unitOfWork.UserRepository.GetUserByIdAsync(id);
        }
        /// <summary>
        /// get application user by emailid
        /// </summary>
        /// <param name="emailId"></param>
        /// <returns>user</returns>

        [Authorize]
        [HttpGet("user/{emailId}")]
        public async Task<ActionResult<AppUserDto>> GetUser(string emailId)
        {
            return await _unitOfWork.UserRepository.GetUserByUsernameAsync(emailId);
        }

    }
}