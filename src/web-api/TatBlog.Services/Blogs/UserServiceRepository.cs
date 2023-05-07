using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Contracts;
using TatBlog.Core.DTO;
using TatBlog.Core.Entities;
using TatBlog.Data.Contexts;
using TatBlog.Services.Extensions;

namespace TatBlog.Services.Blogs
{
    public class UserServiceRepository : IUserServiceRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;
        public readonly UserManager<AppUser> userManager;
        private readonly BlogDbContext _context;

        public UserServiceRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            RoleManager<AppRole> roleManager, IConfiguration config, BlogDbContext context) 
        {
            _userManager = userManager;
            this.userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
            _context = context;
        }
        public async Task<string> Authencate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) return null;

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);

            if (!result.Succeeded)
            {
                return null;
            }

            var roles = _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName,user.FirstName),
                new Claim(ClaimTypes.Role, string.Join(";",roles))
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> Register(RegisterRequest request)
        {
            //var user1 = new AppUser()
            //{
            //    Dob = new DateTime(2020, 4, 19),
            //    Email = "asd",
            //    FirstName = "asd",
            //    LastName = "sad",
            //    UserName = "dsda",
            //    PhoneNumber = "091239812",
            //    Password = "0234asdA.",
            //};
            //await _userManager.CreateAsync(user1, request.Password);

            var user = new AppUser()
            {
                Dob = request.Dob,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }

        public async Task<IList<AppUserItem>> GeUsersAsync(
           CancellationToken cancellationToken = default)
        {
            return await _context.Set<AppUser>()
                .OrderBy(a => a.LastName)
                .Select(x => new AppUserItem()
                {
                    LastName = x.LastName,
                    FirstName = x.FirstName,
                    Username = x.UserName,
                    Email = x.Email
                })
                .ToListAsync(cancellationToken);
        }

        public async Task<IPagedList<AppUserItem>> GetPagedUsersAsync(
            int pageSize,
            int pageNumber,
           CancellationToken cancellationToken = default)
        {
            return await _context.Set<AppUser>()
                .AsNoTracking()
                .Select(x => new AppUserItem()
                {
                    LastName = x.LastName,
                    FirstName = x.FirstName,
                    Username = x.UserName,
                    Email = x.Email
                })
                .ToPagedListAsync(pageNumber, pageSize,
                nameof(AppUser.LastName), "ASC",
                cancellationToken);
        }
    }
}
