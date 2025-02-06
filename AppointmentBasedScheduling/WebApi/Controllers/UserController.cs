using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                return Ok("New user registered successfully!");
            }

            return BadRequest(result.Errors);
        }
    }
}
