using FOA_BE.DTOs;
using FOA_BE.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FOA_BE.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDto userDto)
        {
            var result = await _userService.CreateUser(userDto);

            return Ok(result);
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userService.GetUserById(id);

            if (user is null)
            {
                NotFound("User not found");
            }

            return Ok(user);
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> GetMe()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (userId is null)
            {
                return Unauthorized();
            }

            var user = await _userService.GetUserById(Guid.Parse(userId.ToString()));

            return Ok(user);
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _userService.GetAllUsers());
        }



    }
}
