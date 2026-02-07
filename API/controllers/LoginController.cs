using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using BookingSystem;
using System.Collections.Generic;

namespace API.controllers
{
    [ApiController]
    [Route("api/auth/login")]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly TokenService _tokenService;

        public LoginController(UserManager<ApplicationUser> userManager, TokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }
        
        [HttpPost] //POST /api/auth/login
        public async Task<IActionResult> authorizeLogin([FromBody] authorizeLoginDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.username) || string.IsNullOrWhiteSpace(dto.password))
            {
                return BadRequest(new { error = "Username and password are required" });
            }

            var user = await _userManager.FindByNameAsync(dto.username);
            if (user == null)
            {
                return Unauthorized();
            }

            var valid = await _userManager.CheckPasswordAsync(user, dto.password);
            if (!valid)
            {
                return Unauthorized();
            }

            var roles = await _userManager.GetRolesAsync(user);
            var token = _tokenService.GenerateToken(user, roles);

            return Ok(new { token, username = user.UserName, roles });
        }
    }
}