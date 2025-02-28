using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.Data;
using WebApi.Models;
using WebApi.Models.DTOs;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<User> userManager, 
            SignInManager<User> signInManager, 
            IConfiguration configuration,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterNewUserAccount([FromBody] UserRegisterModel userRegisterModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User
            {
                UserName = userRegisterModel.Email,
                Email = userRegisterModel.Email,
                FirstName = userRegisterModel.FirstName,
                LastName = userRegisterModel.LastName,
                Organisation = userRegisterModel.Organisation
            };
            var result = await _userManager.CreateAsync(user, userRegisterModel.Password);
            var roleResult = await _userManager.AddToRoleAsync(user, "User");

            if (result.Succeeded && roleResult.Succeeded)
            {
                return Ok("New user registered successfully!");
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserModel loginUserModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(loginUserModel.Email);
            if (user == null) return Unauthorized("Invalid credentials.");

            var result = await _userManager.CheckPasswordAsync(user, loginUserModel.Password);
            if (!result) return Unauthorized("Invalid credentials.");

            // Create JWT token if credentials are valid
            var token = GenerateJwtToken(user);

            return Ok(new { token });
        }

        private async Task<string> GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
            new Claim(ClaimTypes.Email, user.Email),
        };

            var roles = await _userManager.GetRolesAsync(user);
            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpGet("getCurrentUser")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("Invalid token: User ID not found.");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            if (userRoles == null)
            {
                return NotFound("User Roles not found.");
            }

            return Ok(new
            {
                user.Id,
                user.UserName,
                user.Email,
                user.FirstName,
                user.LastName,
                Roles = userRoles
            });
        }

        [HttpGet("admin/getAllUsers")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = _userManager.Users.ToList();
            
            var usersList = users.Select(user => new
            {
                user.Id,
                user.UserName,
                user.Email,
            }).ToList();

            return Ok(usersList);
        }

        [HttpPost("admin/assignRole")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignRole([FromBody] UserRolePairModel userRolePairModel)
        {
            var user = await _userManager.FindByIdAsync(userRolePairModel.UserId);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            var result = await _userManager.AddToRoleAsync(user, userRolePairModel.RoleName);
            if (result.Succeeded)
            {
                return Ok("Role assigned successfully");
            }
            return BadRequest(result.Errors);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("admin/getAllRoles")]
        public IActionResult GetAllRoles()
        {
            var roles = _roleManager.Roles.Select(r => new { r.Id, r.Name }).ToList();

            return Ok(roles);
        }

    }
}
