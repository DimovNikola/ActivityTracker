using ActivityBusinessLayer.Interfaces;
using ActivityDataLayer.Models;
using ActivityDataLayer.Roles;
using ActivityTrackerAPI.Responses;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ActivityTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthenticationController(IAuthService authService, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] Login model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var token = await _authService.Login(user);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }
        [Authorize(UserRoles.Admin)]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] Register model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, "User not Created!");

            var result = await _authService.CreateUser(model);

            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, "User not Created!");

            return Ok("User Created!");
        }

        [HttpPost]
        [Route("registerAdmin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] Register model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Admin User not Created!");

            var result = await _authService.CreateAdmin(model);

            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, "Admin User not Created!");

            return Ok("Admin User Created!");
        }
    }
}
