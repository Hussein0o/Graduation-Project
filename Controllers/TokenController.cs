using AuroraAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuroraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly medicalContext _context;

        public TokenController(IConfiguration config, medicalContext context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Users _userData)
        {
            if (_userData != null && _userData.User_Email != null) 
            {
                var user = await GetUsers(_userData.User_Email);
                if (user != null)
                {
                    var claims = new[]
                    {
                  new Claim (JwtRegisteredClaimNames.Sub,_configuration["Jwt:Subject"]),
                  new Claim  (JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                  new Claim (JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                  new Claim ("id",user.User_Id.ToString()),
                  new Claim ("FirstName",user.First_Name),
                  new Claim ("LastName",user.Last_Name),
                  new Claim ("Email",user.User_Email),

                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var SignIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var Token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: SignIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(Token));

                }
                else
                {
                    return BadRequest("error!");
                }
            }
            else
            {
                return BadRequest();
            }
                       
        }
        private async Task<Users> GetUsers(string User_Email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.User_Email == User_Email);
        }
    }
} 

