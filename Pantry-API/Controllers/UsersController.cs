using Microsoft.AspNetCore.Mvc;
using Business.UsersService;
using Common.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pantry_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var results = await _usersService.GetAllUsersAsync();
            return StatusCode(200, results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var result = await _usersService.GetUserByIdAsync(id);
            return StatusCode(200, result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserDto createUserDto)
        {
            var result = await _usersService.CreateUserAsync(createUserDto);
            return StatusCode(201, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {   var result = await _usersService.DeleteUserAsync(id);
            return StatusCode(200, result);
        }
    }
}
