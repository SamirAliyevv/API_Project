using ApiTask.core.Entities;
using ApiTask.Service.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Api_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;


        public AuthController( RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _configuration = configuration;
            
        }

        //[HttpGet]
        //[Route("createrole")]

        //public async Task<IActionResult> CreateRole()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole("Admin"));
        //    await _roleManager.CreateAsync(new IdentityRole("Member"));
        //    return Ok();
        //}

        [HttpGet]
        [Route("login")]


        public async Task<IActionResult> Login(AdminLoginDto logindto)
        {


            AppUser admin = await _userManager.FindByNameAsync(logindto.UserName);
            if (admin == null)
            {
                return BadRequest();
            }

            if (!await _userManager.CheckPasswordAsync(admin, logindto.Password))
            {
                return BadRequest();
            }

            List<Claim> claims = new List<Claim>
            {
                new Claim( ClaimTypes.NameIdentifier,admin.Id),
                    new Claim( ClaimTypes.Name,admin.UserName),
                    new Claim( ClaimTypes.Email,admin.Email),
                    new Claim( "FullName",admin.FullName)


            };
            var roleClaims = (await _userManager.GetRolesAsync(admin)).Select(x => new Claim(ClaimTypes.Role, x)).ToList();
            claims.AddRange(roleClaims);

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:Secret").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);


            var token = new JwtSecurityToken(
              signingCredentials: creds,
            claims: claims,
              expires: DateTime.UtcNow.AddDays(3),
              issuer: _configuration.GetSection("JWT:Issuer").Value,
              audience: _configuration.GetSection("JWT:Audience").Value
           );
            var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new { token = tokenStr });


        }

    }
}
