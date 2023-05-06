using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TatBlog.Core.DTO;
using TatBlog.Services.Blogs;

namespace TatBlog.WebApi.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserEndpoints : ControllerBase
    {
        //public static WebApplication MapUserEndpoints(
        //this WebApplication app)
        //{
        //    return app;
        //}
        private readonly IUserServiceRepository _userServiceRepository;
        private UserEndpoints(IUserServiceRepository userServiceRepository)
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
                return BadRequest("Username or Password is incorrect. ");
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

    }

}
