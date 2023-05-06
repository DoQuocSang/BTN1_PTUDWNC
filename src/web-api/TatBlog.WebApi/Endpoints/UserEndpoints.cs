using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TatBlog.Core.DTO;
using TatBlog.Services.Blogs;

namespace TatBlog.WebApi.Endpoints
{
    public class UserEndpoints
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
        //public async Task<IActionResult> Authenticate([FromBody]LoginRequest request)
        //{
            
        //}

    }

}
