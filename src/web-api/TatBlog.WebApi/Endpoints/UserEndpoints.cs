using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TatBlog.Core.Collections;
using TatBlog.Core.DTO;
using TatBlog.Core.Entities;
using TatBlog.Services.Blogs;
using TatBlog.WebApi.Models;

namespace TatBlog.WebApi.Endpoints
{
    [Route("api/users")]
    [ApiController]
    
    public class UserEndpoints : ControllerBase
    {
        //public static WebApplication MapUserEndpoints(
        //this WebApplication app)
        //{
        //    return app;
        //}
        private readonly IUserServiceRepository _userServiceRepository;
        public UserEndpoints(IUserServiceRepository userServiceRepository)
        {
            _userServiceRepository = userServiceRepository;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromForm] LoginRequest request)
        {
            var resultToken = await _userServiceRepository.Authencate(request);
            if (string.IsNullOrEmpty(resultToken))
            {
                return BadRequest("Username or Password is incorrect.");
            }
            return Ok(new {token = resultToken});
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromForm] RegisterRequest request)
        {
            
            if (!ModelState.IsValid)     
                return BadRequest(ModelState);

                var result = await _userServiceRepository.Register(request);
            
            if (!result)
            {
                return BadRequest("Register is unsuccess");
            }
            return Ok();
        }

        [HttpGet("")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUser([AsParameters] int PageSize, [AsParameters] int PageNumber)
        {
            var result = await GetUserList(_userServiceRepository, PageSize, PageNumber);
            return Ok(result);
        }

        private static async Task<IResult> GetUserList(
            IUserServiceRepository userServiceRepository, int pageSize, int pageNumber)
        {
            var usersList = await userServiceRepository
                .GetPagedUsersAsync(pageSize, pageNumber);

            var paginationResult =
                new PaginationResult<AppUserItem>(usersList);

            //return Results.Ok(paginationResult);
            return Results.Ok(ApiResponse.Success(paginationResult));
        }

    }

}
